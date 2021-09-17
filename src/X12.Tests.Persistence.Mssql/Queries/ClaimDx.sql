select 
	cd.ClaimLoopId,
	ClaimKey = ch.ClaimNumber,
	Dx = 
		case
			when len(Code) <= 3 then Code
			when cd.Qual in ('BK','BF','BJ','PR','BN') and len(Code) > 3 then
				case when substring(Code,1,1) = 'E' and len(Code) > 4 then substring(Code,1,4) + '.' + substring(Code, 5, 2)
					 when substring(Code,1,1) <> 'E' and len(Code) > 3 then substring(Code,1,3) + '.' + substring(Code, 4, 2)
					 else Code 
				end
			else -- ICD-10 Format 
				substring(Code,1,3) + '.' + substring(Code,4,4) 
		end, 
	Sequence = 
		case 
			when cd.Qual in ('ABK','BK') then 1
			when cd.Qual in ('ABF','BF') then cd.Precedence + 1
			when cd.Qual in ('ABJ','BJ') then -1
			when cd.Qual in ('APR','PR') then -1 - cd.Precedence
			when cd.Qual in ('ABN','BN') then -5 - cd.Precedence
			else Precedence 
		end,
	Poa
from Claims.ClaimCodes cd
inner join Claims.ClaimHeader ch on ch.ClaimLoopId = cd.ClaimLoopId
inner join (values 
	('ABK'), ('BK'), -- Principal Diagnosis
	('ABF'), ('BF'), -- Other Diagnoses
	('ABJ'), ('BJ'), -- Admitting Diagnosis
	('APR'), ('PR'), -- Patient Reason
	('ABN'), ('BN')  -- External Cause of Injury
) as t(Qual) on t.Qual = cd.Qual
where cd.ClaimLoopId > @currentClaimLoopId
