;with uniqueVendors as (
  select VendorKey,
    HitCount = count(distinct ClaimLoopId),
	LatestClaimLoopId = max(ClaimLoopId)
  from Claims.Vendor
  group by VendorKey
), precedence as (
  select VendorKey, LatestClaimLoopId, Precedence = row_number() over (partition by VendorKey order by HitCount desc)
  from uniqueVendors
)
select v.*
from Claims.Vendor v
inner join precedence p on p.LatestClaimLoopId = v.ClaimLoopId and p.Precedence = 1