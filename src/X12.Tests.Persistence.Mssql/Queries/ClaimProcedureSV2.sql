declare @pxAndMod table (LineLoopId int, Ref tinyint, Element varchar(10), primary key clustered (LineLoopId, Ref))

insert into @pxAndMod
select LineLoopId = line.LoopId, Ref, Element = left(Element, 10) 
	from Claims.ClaimHeader ch
	inner join LX line ON line.ParentLoopId = ch.ClaimLoopId
	inner join SV2 instLine ON instLine.ParentLoopId = line.LoopId
	inner join Interchange i on i.Id = line.InterchangeId
	cross apply(
	  select line.LoopId, Ref, Element, Precedence = row_number() over (partition by line.LoopId, Ref order by line.LoopId desc) 
	  from dbo.SplitSegment(i.ComponentSeparator, instLine.[02])) sp
	where ch.ClaimLoopId > @currentClaimLoopId 
		and line.LoopId = sp.LoopId and sp.Precedence = 1
		and isnull(Element, '') != ''
	order by line.LoopId, Ref


select
	LineLoopId = line.LoopId,
	ClaimProcedureTransactionKey = coalesce(licn.[02], concat(ch.ClaimNumber, '-', line.[01])),
	ClaimLoopId = ch.ClaimLoopId,
	ClaimKey = ch.ClaimNumber,
	ClaimLineNum = cast(line.[01] as smallint),
	PlaceOfServiceCode = ch.PlaceOfServiceCode,
	RevenueCode = case substring(instLine.[01],1,1) when '0' then 'R' + substring(instLine.[01],2,3) else 'R' + instLine.[01] end,
	ProcedureCode = px.Element,
	Modifier1 = left(mod1.Element, 2),
	Modifier2 = left(mod2.Element, 2),
	Modifier3 = left(mod3.Element, 2),
	Modifier4 = left(mod4.Element, 2),
	DxSequence1 = cast(null as varchar(1)),
	DxSequence2 = cast(null as varchar(1)),
	DxSequence3 = cast(null as varchar(1)),
	DxSequence4 = cast(null as varchar(1)),
	Units = cast(instLine.[05] as numeric(8,2)),
	Charges = cast(instLine.[03]  as numeric(19,4)),
	FromServiceDate = coalesce(linedates.FromServiceDate, claimdates.FromServiceDate),
	ToServiceDate = coalesce(linedates.ToServiceDate, linedates.FromServiceDate, claimdates.ToServiceDate, claimdates.FromServiceDate),
	NetAmount = coalesce(la.AmountPaid, 0), 
	AmountPaid = coalesce(la.AmountPaid, 0),
	WithholdAmount = coalesce(la.WithholdAmount, 0),
	ClaimProcedureStatus = case when d.ParentLoopId is not null then 'DENIED' else 'APPROVED' end,
    ClaimProcedureStatusType = case when d.ParentLoopId is not null then 'DENY' else 'APP' end,
	EobCodes = la.EobCodes, 
	VendorKey = v.VendorKey,
	CheckNumber = cast(i.ControlNumber as varchar(10)), --this seems weird to me
	CheckDate = coalesce(la.CheckDate, claimdates.CheckDate, i.Date)
from [Loop] ClaimLoop
inner join Claims.ClaimHeader ch on ch.ClaimLoopId = claimLoop.Id 
inner join CLM claim on claim.LoopId = claimLoop.Id
inner join Claims.Vendor v on v.ClaimLoopId = claimLoop.Id
inner join LX line ON line.ParentLoopId = ClaimLoop.Id
inner join SV2 instLine ON instLine.ParentLoopId = line.LoopId
inner join Interchange i on claimLoop.InterchangeId = i.Id
left join @pxAndMod px on px.LineLoopId = line.LoopId and px.Ref = 2 
left join @pxAndMod mod1 on mod1.LineLoopId = line.LoopId and mod1.Ref = 3 
left join @pxAndMod mod2 on mod2.LineLoopId = line.LoopId and mod2.Ref = 4  
left join @pxAndMod mod3 on mod3.LineLoopId = line.LoopId and mod3.Ref = 5  
left join @pxAndMod mod4 on mod4.LineLoopId = line.LoopId and mod4.Ref = 6  
left join Claims.ClaimDates claimdates on claimdates.ClaimLoopId = claimLoop.Id
left join Claims.LineDates linedates on linedates.LineLoopId = line.LoopId
left join Claims.LineAdjudication la on la.ClaimLoopId = claimLoop.Id 
  and la.LineLoopId = line.LoopId 
  and la.PayerIdentifier = ch.PayerIdentifier
left join Claims.Denials d on d.ParentLoopId = la.AdjudicationLoopId
left join REF licn on licn.ParentLoopId = line.LoopId and licn.[01] = '6R' 
left join FunctionalGroup fg ON fg.InterchangeId = ClaimLoop.InterchangeId
where claimLoop.Id > @currentClaimLoopId 
order by ch.ClaimLoopId, ch.ClaimNumber, line.LoopId, licn.[02]
