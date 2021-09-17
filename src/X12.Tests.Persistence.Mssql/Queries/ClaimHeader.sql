; with PatientClaims as (
	select ClaimLoopId = Claim.LoopId, ProviderLoopId = SubscriberLoop.ParentLoopId, SubscriberLoopId = SubscriberLoop.Id
	from X12.[CLM] Claim
	inner join X12.[Loop] PatientLoop on PatientLoop.Id = Claim.ParentLoopId
	inner join X12.[Loop] SubscriberLoop on SubscriberLoop.Id = PatientLoop.ParentLoopId
)
, SubscriberClaims as (
	select ClaimLoopId = Claim.LoopId, ProviderLoopId = SubscriberLoop.ParentLoopId, SubscriberLoopId = SubscriberLoop.Id
	from X12.[CLM] Claim
	inner join X12.[Loop] SubscriberLoop on SubscriberLoop.Id = Claim.ParentLoopId
)
, ProviderClaims as (
	select ClaimLoopId, ProviderLoopId, SubscriberLoopId
	from PatientClaims
	union
	select ClaimLoopId, ProviderLoopId, SubscriberLoopId
	from SubscriberClaims
)
select FileId = f.Id, 
  InterchangeId = i.Id,
  ClaimLoopId = ClaimLoop.Id, 
  ClaimNumber = Claim.[01], 
  ClaimFormType = case 
    when fg.[Version] like '%X222%' then 'P'
	  when fg.[Version] like '%X223%' then 'I'
	  when fg.[Version] like '%X224%' then 'D'
	  else 'U'
  end, 
  PlaceOfServiceCode = case -- translate from bill type codes
		when substring(Claim.[05], 1, 2) in ('11','12','18','41','42') then '21' -- Inpatient Hospital
		when substring(Claim.[05], 1, 2) in ('13','14','43','85') then '22' -- Outpatient Hospital
		when substring(Claim.[05], 1, 2) in ('21','22') then '31' -- Skilled Nursing Facility
		when substring(Claim.[05], 1, 2) in ('23','28') then '32' -- Nursing Facility
		when substring(Claim.[05], 1, 2) in ('32','33','34','81','82') then '12' -- Home
		when substring(Claim.[05], 1, 2) in ('65') then '54' -- Intermediate Care Facility/Mentally Retarded        
		when substring(Claim.[05], 1, 2) in ('71') then '72' -- Rural Health Clinic
		when substring(Claim.[05], 1, 2) in ('72') then '65' -- ESRD Treatment Facility
		when substring(Claim.[05], 1, 2) in ('73','74','79') then '49' -- Independent Clinic
		when substring(Claim.[05], 1, 2) in ('75') then '62' -- Comprehensive Outpatient Rehabilitation Facility
		when substring(Claim.[05], 1, 2) in ('76') then '53' -- Community Mental Health Center
		when substring(Claim.[05], 1, 2) in ('81','82') then '34' -- Hospice        
		when substring(Claim.[05], 1, 2) in ('83') then '24' -- ambulatory surgical center
		when substring(Claim.[05], 1, 2) in ('84') then '25' -- birthing center        
		else '49' 
  end, 
  NetworkKey = i.Sender,
  PayerIdentifier = sbr.[03]
from X12.[Loop] ClaimLoop
inner join X12.[CLM] Claim on Claim.LoopId = ClaimLoop.Id
inner join ProviderClaims on ProviderClaims.ClaimLoopId = ClaimLoop.Id
inner join X12.[SBR] sbr on sbr.ParentLoopId = ProviderClaims.SubscriberLoopId
inner join X12.[Loop] ProviderLoop on ProviderLoop.Id = ProviderClaims.ProviderLoopId
inner join X12.[TransactionSet] ts on ts.Id = ProviderLoop.TransactionSetId
inner join X12.[FunctionalGroup] fg on fg.Id = ts.FunctionalGroupId
inner join X12.[Interchange] i on i.Id = Claim.InterchangeId
inner join X12.[File] f on f.Id = i.FileId
WHERE f.Filename = @filename
	and ClaimLoop.TransactionSetCode = '837'
	and ClaimLoop.SpecificationLoop = '2300'
	and i.HasError = 0
order by ClaimLoop.Id