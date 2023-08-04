//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public readonly record struct AsmToken<K,T>
    where K : unmanaged
    where T : unmanaged
{
    public readonly Label Group;

    public readonly K Kind;

    public readonly T Index;

    public readonly Label Name;

    public readonly Label Expression;

    [MethodImpl(Inline)]
    public AsmToken(Label group, K kind, T index, Label name, Label expression)
    {
        Group = group;            
        Kind = kind;
        Index = index;
        Name = name;
        Expression = expression;
    }

    public uint Key
    {
        [MethodImpl(Inline)]
        get => (sys.u32(Kind) << 16) | sys.u32(Index);
    }

    [MethodImpl(Inline)]
    public static implicit operator AsmToken(AsmToken<K,T> src)
        => new AsmToken(src.Key, src.Name, src.Expression);
}
