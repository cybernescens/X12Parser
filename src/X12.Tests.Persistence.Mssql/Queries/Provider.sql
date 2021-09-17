;with allProviders as (
  select ClaimLoopId, ProviderKey, ProviderTaxonomyCode, NamePrefix, FirstName, MiddleName, LastName, NameSuffix, Upin, Npi 
  from Claims.BillingProvider
  union 
  select rp.ClaimLoopId, rp.ProviderKey, rp.ProviderTaxonomyCode, rp.NamePrefix, rp.FirstName, rp.MiddleName, rp.LastName, rp.NameSuffix, rp.Upin, rp.Npi 
  from Claims.RenderingProvider rp
  left join Claims.BillingProvider bp on bp.ClaimLoopId = rp.ClaimLoopId and bp.ProviderKey = rp.ProviderKey
  where bp.ProviderKey is null 
), uniqueProviders as (
  select ProviderKey,
    HitCount = count(distinct ClaimLoopId),
	LatestClaimLoopId = max(ClaimLoopId)
  from allProviders
  group by ProviderKey
), precedence as (
  select ProviderKey, LatestClaimLoopId, Precedence = row_number() over (partition by ProviderKey order by HitCount desc)
  from uniqueProviders
)
select ap.ProviderKey, 
  HcpTaxonomy = ap.ProviderTaxonomyCode, 
  NamePrefix = ap.NamePrefix,
  FirstName = ap.FirstName,
  MiddleName = ap.MiddleName,
  LastName = ap.LastName,
  NameSuffix = ap.NameSuffix,
  Upin = ap.Upin,
  Npi = ap.Npi
from allProviders ap
inner join precedence p on p.LatestClaimLoopId = ap.ClaimLoopId and p.ProviderKey = ap.ProviderKey and p.Precedence = 1
group by ap.ProviderKey, ap.ProviderTaxonomyCode, ap.NamePrefix, ap.FirstName, ap.MiddleName, ap.LastName, ap.NameSuffix, ap.Upin, ap.Npi
