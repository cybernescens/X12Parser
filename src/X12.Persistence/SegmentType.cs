using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using X12.Parsing.Specification;
using X12.Persistence.Model;

namespace X12.Persistence
{
  public class SegmentType : IEquatable<SegmentType>
  {
    internal static readonly FileSegmentType File = new();
    internal static readonly InterchangeSegmentType Interchange = new();
    internal static readonly FunctionGroupSegmentType FunctionGroup = new();
    internal static readonly TransactionSetSegmentType TransactionSet = new();
    internal static readonly LoopSegmentType Loop = new();
    internal static readonly SegmentSegmentType Segment = new();
    internal static readonly ParsingErrorSegmentType ParsingError = new();
    internal static readonly IndexSegmentSegmentType IndexedSegment = new();

    public static readonly SegmentType[] Ordered =
      { File, Interchange, FunctionGroup, TransactionSet, Loop, Segment, ParsingError };

    protected SegmentType(Type entityType, int priority)
    {
      EntityType = entityType;
      Priority = priority;
      Id = entityType.GetCustomAttribute<TableAttribute>()!.Name;
    }

    protected SegmentType(Type entityType, int priority, string id)
    {
      EntityType = entityType;
      Id = id;
      Priority = priority;
    }

    public string Id { get; }
    public int Priority { get; }
    public Type EntityType { get; }

    public bool Equals(SegmentType? other) => GetHashCode() == other?.GetHashCode();

    public override int GetHashCode() => string.GetHashCode(Id);

    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj))
        return false;

      if (ReferenceEquals(this, obj))
        return true;

      return obj.GetType() == GetType() && Equals((SegmentType)obj);
    }
  }

  public class FileSegmentType : SegmentType
  {
    internal FileSegmentType() : base(typeof(FileEntity), 1) { }
  }

  public class InterchangeSegmentType : SegmentType
  {
    internal InterchangeSegmentType() : base(typeof(InterchangeEntity), 2) { }
  }

  public class FunctionGroupSegmentType : SegmentType
  {
    internal FunctionGroupSegmentType() : base(typeof(FunctionalGroupEntity), 3) { }
  }

  public class TransactionSetSegmentType : SegmentType
  {
    internal TransactionSetSegmentType() : base(typeof(TransactionSetEntity), 4) { }
  }

  public class LoopSegmentType : SegmentType
  {
    internal LoopSegmentType() : base(typeof(LoopEntity), 5) { }
  }

  public class SegmentSegmentType : SegmentType
  {
    internal SegmentSegmentType() : base(typeof(SegmentEntity), 6) { }
  }

  public class ParsingErrorSegmentType : SegmentType
  {
    internal ParsingErrorSegmentType() : base(typeof(ParsingErrorEntity), 7) { }
  }

  public class IndexSegmentSegmentType : SegmentType
  {
    internal IndexSegmentSegmentType() : base(typeof(IndexedSegmentEntity), -1000, "base") { }

    public IndexSegmentSegmentType(SegmentSpecification segment, int priority) : 
      base(typeof(IndexedSegmentEntity), priority + 1000, segment.SegmentId)
    {
      Specification = segment ?? throw new ArgumentNullException(nameof(segment));
    }

    internal SegmentSpecification? Specification { get; }
  }
}