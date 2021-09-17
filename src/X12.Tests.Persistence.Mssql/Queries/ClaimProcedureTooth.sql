select	
	LineLoopId = line.LoopId,
	ClaimProcedureTransactionKey = coalesce(licn.[02], concat(ch.ClaimNumber, '-', line.[01])),
	ClaimLoopId = ch.ClaimLoopId,
	ClaimKey = ch.ClaimNumber,
	ClaimLineNum = cast(line.[01] as smallint),
	ToothCode = cast(tooth.[02] as varchar(2)),
	ToothSurfaces = cast(tooth.[03]	as varchar(9))
from Loop ClaimLoop
inner join Claims.ClaimHeader ch on ClaimLoop.Id = ch.ClaimLoopId 
inner join CLM Claim on ClaimLoop.Id = Claim.LoopId
inner join Interchange i on Claim.InterchangeId = i.Id
inner join LX Line ON Line.ParentLoopId = ClaimLoop.Id
left join REF licn on licn.ParentLoopId = line.LoopId and licn.[01] = '6R'
inner join TOO tooth ON Line.LoopId = tooth.ParentLoopId
where claimLoop.Id > @currentClaimLoopId 
order by ch.ClaimLoopId, ch.ClaimNumber, line.LoopId, licn.[02]