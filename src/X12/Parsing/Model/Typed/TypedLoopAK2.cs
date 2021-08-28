namespace X12.Parsing.Model.Typed
{
  public class TypedLoopAK2 : TypedLoop
  {
    public TypedLoopAK2() : base("AK2") { }

    public string AK201_TransactionSetIdentifierCode
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public string AK202_TransactionSetControlNumber
    {
      get => this._loop.GetElement(2);
      set => this._loop.SetElement(2, value);
    }

    public string AK203_ImplementationConventionReference
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }
  }
}