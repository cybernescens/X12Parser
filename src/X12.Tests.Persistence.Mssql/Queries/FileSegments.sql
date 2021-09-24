select s.*, i.SegmentTerminator
from X12.[Segment] s
inner join X12.[Interchange] i on i.Id = s.InterchangeId
inner join X12.[File] f on f.Id = i.FileId
where f.Filehash = @hash
order by s.InterchangeId, s.PositionInInterchange