//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public record class CmdVar : ScriptVar<@string>
{
    [MethodImpl(Inline)]
    public CmdVar(string name, object value)
        : base(name, AsciSymbol.Empty, (AsciSymbols.Percent, AsciSymbols.Percent), value?.ToString() ?? EmptyString)
    {
    }

    [MethodImpl(Inline)]
    public CmdVar(string name)
        : this(name, @string.Empty)
    {

    }

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator CmdVar(string id)
        => new CmdVar(id);

    [MethodImpl(Inline)]
    public static implicit operator CmdVar((string id, string value) src)
        => new CmdVar(src.id, src.value);

    [MethodImpl(Inline)]
    public static implicit operator CmdVar(Pair<string> src)
        => new CmdVar(src.Left, src.Right);

    public static CmdVar Empty => new CmdVar(EmptyString);
}
