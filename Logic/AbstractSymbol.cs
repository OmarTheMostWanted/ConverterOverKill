namespace RomanConverter.Logic;

public abstract class AbstractSymbol : IComparable<AbstractSymbol>
{
    public int Val { get; init; }
    public char S { get; init; }

    // public AbstractSymbol(int val, char s)
    // {
    //     Val = val;
    //     S = s;
    // }

    public int CompareTo(AbstractSymbol? other)
    {
        if (other != null) return this.Val.CompareTo(other.Val);
        else throw new NullReferenceException();
    }

    public override int GetHashCode()
    {
        return Val;
    }
}