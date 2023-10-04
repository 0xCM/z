//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public readonly record struct FlagEffect : IComparable<FlagEffect>
{
    public readonly RFlagBits Flag;

    public readonly FlagEffectKind Kind;

    [MethodImpl(Inline)]
    public FlagEffect(RFlagBits f, FlagEffectKind k)
    {
        Flag = f;
        Kind = k;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Flag == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Flag != 0;
    }

    [MethodImpl(Inline)]
    public int CompareTo(FlagEffect src)
    {
        var result = ((ulong)Flag).CompareTo(src.Flag);
        if(result == 0)
            result = ((byte)Kind).CompareTo(src.Kind);
        return result;
    }
}
