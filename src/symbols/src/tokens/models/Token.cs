//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly record struct Token : IToken, IComparable<Token>
{
    public readonly uint Index;

    public readonly string Group;

    public readonly string Name;

    public readonly string Expr;

    public readonly string Info;
    
    public Token()
    {
        Index = 0;
        Group = EmptyString;
        Name = EmptyString;            
        Expr = EmptyString;
        Info = EmptyString;
    }

    [MethodImpl(Inline)]
    public Token(uint index, string group, string name, string expr, string info)
    {
        Index = index;
        Group = group;
        Name = name;
        Expr = expr;
        Info = info;
    }

    public int CompareTo(Token src)
    {
        var result = Group.CompareTo(src.Group);
        if(result == 0)
        {
            result = Index.CompareTo(src.Index);
        }
        return result;
    }

    string IToken.Group
        => Group;

    uint IToken.Index
        => Index;

    string IToken.Name
        => Name;

    string IToken.Expr
        => Expr;

    string IToken.Info
        => Info;

    public static Token Empty => new ();
}