﻿using System;
using X12.Parsing;
using X12.Parsing.Model;

namespace X12.Repositories
{
  [Obsolete("Use X12.Sql library and namespace")]
  public class RepoSegment<T>
    where T : struct
  {
    public RepoSegment(string segmentString, char segmentTerminator, char elementSeparator, char componentSeparator)
    {
      Segment = new DetachedSegment(
        new X12DelimiterSet(segmentTerminator, elementSeparator, componentSeparator),
        segmentString);
    }

    public T InterchangeId { get; set; }
    public T? FunctionalGroupId { get; set; }
    public T? TransactionSetId { get; set; }
    public T? ParentLoopId { get; set; }
    public T? LoopId { get; set; }
    public int RevisionId { get; set; }
    public int PositionInInterchange { get; set; }
    public string SpecLoopId { get; set; }
    public DetachedSegment Segment { get; }
    public bool Deleted { get; set; }
  }
}