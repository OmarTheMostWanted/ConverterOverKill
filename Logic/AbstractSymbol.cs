namespace RomanConverter.Logic;

public abstract class AbstractSymbol : IComparable<AbstractSymbol>
{
    
    public int Val { set; get;}
    public char S { set; get; }


    public int CompareTo(AbstractSymbol? other)
    {
        if (other != null) return this.Val.CompareTo(other.Val);
        else throw new NullReferenceException();
    }
}