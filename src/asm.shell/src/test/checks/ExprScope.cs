//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Identifies a context-relative scope
/// </summary>
public readonly struct ExprScope : IEquatable<ExprScope>
{
    const char Sep = Chars.Dot;

    public static ExprScope root(string name)
        => define(name);

    public static ExprScope define(string src)
        => new (src);

    readonly string Data;

    [MethodImpl(Inline)]
    ExprScope(string data)
    {
        Data = data ?? EmptyString;
    }

    public string Text
    {
        [MethodImpl(Inline)]
        get => Data ?? EmptyString;
    }

    public bool IsRoot
        => text.index(Text, Sep) < 0;

    public bool IsEmpty
        => text.empty(Data);

    public bool IsNonEmpty
        => !IsEmpty;

    public uint Hash
    {
        [MethodImpl(Inline)]
        get => sys.hash(Text);
    }

    public string Name
    {
        get
        {
            var i = text.index(Text, Sep);
            var j = text.xedni(Text, Sep);
            if(i > 0 && j > i)
                return text.inside(Text, i, j);
            else if(i != 0)
                return Text;
            else
                return EmptyString;
        }
    }

    public ExprScope Join(ExprScope src)
    {
        if(src.IsEmpty)
            return this;

        if(IsEmpty)
            return src;

        return define(string.Format("{0}{1}{2}", this, Sep, src));
    }

    public ExprScope Ascendant()
    {
        var i = text.index(Text, Sep);
        if(i > 0)
            return define(text.left(Text,i));
        else
            return this;
    }

    public ExprScope Descendant()
    {
        var i = text.index(Text, Sep);
        if(i > 0)
            return define(text.right(Text,Sep));
        else
            return this;
    }

    public bool IsDescendant(ExprScope src)
        => text.contains(Text, src.Text);

    public bool IsAscendant(ExprScope src)
        => text.contains(src.Text, Text);

    public ExprScope Common(ExprScope src)
    {
        if(IsDescendant(src))
            return define(text.left(Text, src.Text));
        else if(IsAscendant(src))
            return define(text.left(src.Text, Text));
        else
            return Empty;
    }

    public string Format()
        => Text;

    public override string ToString()
        => Format();

    public override int GetHashCode()
        => (int)Hash;

    public bool Equals(ExprScope src)
        => Text.Equals(src.Text);

    public override bool Equals(object src)
        => src is ExprScope x && Equals(x);

    public static ExprScope operator +(ExprScope a, ExprScope b)
        => a.Join(b);

    public static bool operator ==(ExprScope a, ExprScope b)
        => a.Equals(b);

    public static bool operator !=(ExprScope a, ExprScope b)
        => !a.Equals(b);

    public static bool operator >(ExprScope a, ExprScope b)
        => b.IsDescendant(a);

    public static bool operator >=(ExprScope a, ExprScope b)
        => b.IsDescendant(a) || a.Equals(b);

    public static bool operator <(ExprScope a, ExprScope b)
        => a.IsDescendant(b);

    public static bool operator <=(ExprScope a, ExprScope b)
        => a.IsDescendant(b) || a.Equals(b);

    public static implicit operator ExprScope(string src)
        => define(src);

    public static ExprScope Empty => define(EmptyString);
}
