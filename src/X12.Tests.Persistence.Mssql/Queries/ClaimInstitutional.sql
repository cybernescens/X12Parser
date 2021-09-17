SELECT	
		ch.ClaimLoopId,
		ClaimKey = Claim.[01],
		BillTypeCode = left(Claim.[05],2) + right(Claim.[05],1),
		AdmissionDate = dates.AdmissionDate,
		AdmissionHourCode = format(datepart(hour, dates.AdmissionDate), '00'),
		AdmissionTypeCode = codes.[01],
		AdmissionSourceCode = codes.[02],
		DischargeHourCode = format(dates.DischargeHour, '00'),
		PatientStatusCode = codes.[03],
		AttendingPhysicianName = rtrim(AttendingProviderName.[03] + ', ' + AttendingProviderName.[04]),
		PrincipalProcedureCode = op1.Code,
		PrincipalProcedureDate = op1.Date,
		OtherProcedureACode = opA.Code,
		OtherProcedureADate = opA.Date,
		OtherProcedureBCode = opB.Code,
		OtherProcedureBDate = opB.Date,
		OtherProcedureCCode = opC.Code,
		OtherProcedureCDate = opC.Date,
		OtherProcedureDCode = opD.Code,
		OtherProcedureDDate = opD.Date,
		OtherProcedureECode = opE.Code,
		OtherProcedureEDate = opE.Date
from Loop ClaimLoop
inner join CLM Claim on ClaimLoop.Id = Claim.LoopId
inner join Claims.ClaimHeader ch on ClaimLoop.Id = ch.ClaimLoopId -- only include the latest claim record
left join Claims.ClaimDates dates on dates.ClaimLoopId = ch.ClaimLoopId
left join DTP AdmissionDate ON AdmissionDate.ParentLoopId = ClaimLoop.Id and AdmissionDate.[01] = '435'
left join DTP DischargeDate ON AdmissionDate.ParentLoopId = ClaimLoop.Id and AdmissionDate.[01] = '096'
left join CL1 codes ON codes.ParentLoopId = ClaimLoop.Id
left join NM1 AttendingProviderName ON AttendingProviderName.ParentLoopId = ClaimLoop.Id and AttendingProviderName.[01] = '71'
left join FunctionalGroup ON FunctionalGroup.InterchangeId = ClaimLoop.InterchangeId
left join Claims.ClaimCodes op1 on op1.ClaimLoopId = ClaimLoop.Id and Qual in ('BBR','BR','CAH')
left join Claims.ClaimCodes opA on opA.ClaimLoopId = ClaimLoop.Id and opA.Qual in ('BBQ','BQ') and opA.Precedence = 1
left join Claims.ClaimCodes opB on opB.ClaimLoopId = ClaimLoop.Id and opB.Qual in ('BBQ','BQ') and opB.Precedence = 2
left join Claims.ClaimCodes opC on opC.ClaimLoopId = ClaimLoop.Id and opC.Qual in ('BBQ','BQ') and opC.Precedence = 3
left join Claims.ClaimCodes opD on opD.ClaimLoopId = ClaimLoop.Id and opD.Qual in ('BBQ','BQ') and opD.Precedence = 4
left join Claims.ClaimCodes opE on opE.ClaimLoopId = ClaimLoop.Id and opE.Qual in ('BBQ','BQ') and opE.Precedence = 5
where ClaimLoop.Id > @currentClaimLoopId 
	and SUBSTRING(FunctionalGroup.Version, 0, 11) = '005010X223'
