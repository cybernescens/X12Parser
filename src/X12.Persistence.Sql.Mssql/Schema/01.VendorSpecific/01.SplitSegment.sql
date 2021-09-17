
if object_id(N'SplitSegment', N'IF') is not null
    drop function [$x12_schema$].SplitSegment

go

create function [$x12_schema$].SplitSegment
(
 @delimeter varchar(1),
 @segment varchar(8000)
)
returns table with schemabinding as
 return
--===== "Inline" CTE Driven "Tally Table" produces values from 1 up to 10,000...
     -- enough to cover VARCHAR(8000)
  with E1(N) as (select 1 union all select 1 union all select 1 union all
                 select 1 union all select 1 union all select 1 union all
                 select 1 union all select 1 union all select 1 union all select 1),
       E2(N) as (select 1 from E1 a, E1 b), --10E+2 or 100 rows
       E4(N) as (select 1 from E2 a, E2 b), --10E+4 or 10,000 rows max
 cteTally(N) as (--==== This provides the "base" CTE and limits the number of rows right up front
                     -- for both a performance gain and prevention of accidental "overruns"
                 select top (isnull(datalength(@segment), 0)) row_number() over (order by (select null)) from E4),
cteStart(N1) as (--==== This returns N+1 (starting position of each "element" just once for each delimiter)
                 select 1 union all
                 select t.N + 1 from cteTally t where substring(@segment, t.N, 1) = @delimeter),
cteLen(N1,L1) as(--==== Return start and length (for use in substring)
                 select s.N1,
                        isnull(nullif(charindex(@delimeter, @segment, s.N1), 0) - s.N1, 8000)
                   from cteStart s)
--===== Do the actual split. The isnull/nullif combo handles the length for the final element when no delimiter is found.
 select Ref     = row_number() over(order by l.N1),
        Element = substring(@segment, l.N1, l.L1)
   from cteLen l

go