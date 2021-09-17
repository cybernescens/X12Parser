-- add DRGs as a virtual line on the claim
 ;with maxClaimLine as (
	select drg.ClaimLoopId, MaxClaimLineNum = max(lx.[01])
	from Claims.ClaimDrg drg
	inner join LX on lx.ParentLoopId = drg.ClaimLoopId
	group by drg.ClaimLoopId
 )
select 
  LineLoopId = 0, 
  ClaimProcedureTransactionKey = concat(ch.ClaimNumber, '-DRG'),
  ClaimLoopId = ch.ClaimLoopId,
  ClaimKey = ch.ClaimNumber,
  ClaimLineNum = isnull(mcl.MaxClaimLineNum, 0) + 1, -- add to the end of other existing lines
  PlaceOfServiceCode = ch.PlaceOfServiceCode,
  RevenueCode = cast(null as varchar(4)),
  ProcedureCode = 'DRG' + drg.Drg,
  Modifier1 = cast(null as varchar(2)), 
  Modifier2 = cast(null as varchar(2)), 
  Modifier3 = cast(null as varchar(2)),  
  Modifier4 = cast(null as varchar(2)), 
  DxSequence1 = cast(null as smallint), 
  DxSequence2 = cast(null as smallint), 
  DxSequence3 = cast(null as smallint), 
  DxSequence4 = cast(null as smallint), 
  Units = cast(1 as numeric(8,2)), 
  Charges = cast(0 as numeric(19,2)),
  FromServiceDate = dates.FromServiceDate,
  ToServiceDate = dates.ToServiceDate,
  NetAmount = cast(isnull(AMT.[02],0) as numeric(19,4)),
  AmountPaid = cast(isnull(AMT.[02],0) as numeric(19,4)),
  WithholdAmount = cast(0.0 as numeric(19,4)),
  ClaimProcedureStatus = case when d.ParentLoopId is not null then 'DENIED' else 'APPROVED' end,
  ClaimProcedureStatusType = case when d.ParentLoopId is not null then 'DENY' else 'APP' end,
  EobCodes = cast(null as varchar(50)),
  VendorKey = v.VendorKey,
  CheckNumber = cast(i.ControlNumber as varchar(10)),
  CheckDate = coalesce(dates.CheckDate, i.Date)
from [Loop] claimLoop
inner join Claims.ClaimDrg drg on drg.ClaimLoopId = claimLoop.Id
inner join Claims.ClaimHeader ch on ch.ClaimLoopId = claimLoop.Id 
inner join CLM claim on claim.LoopId = claimLoop.Id
inner join Claims.Vendor v on v.ClaimLoopId = claimLoop.Id
inner join Interchange i on claimLoop.InterchangeId = i.Id
left join maxClaimLine mcl on mcl.ClaimLoopId = claimLoop.Id
left join Claims.ClaimDates dates on dates.ClaimLoopId = claimLoop.Id
left join [SBR] ON ClaimLoop.Id = [SBR].ParentLoopId AND [Sbr].[01] = 'P' -- only looking at primary for now
left join Claims.Denials d on d.ParentLoopId = [SBR].LoopId
left join [AMT] ON SBR.LoopId = AMT.ParentLoopID and AMT.[01] = 'D'
where claimLoop.Id > @currentClaimLoopId 
order by ch.ClaimLoopId, ch.ClaimNumber
