//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public class Evex
{
    public static ReadOnlySeq<EvexField> FieldKinds => Kinds;

    [MethodImpl(Inline)]
    public ref readonly BfInterval<EvexField> field(EvexField index)
        => ref Intervals[(byte)index];

    readonly static ReadOnlySeq<EvexField> Kinds;

    readonly static BfIntervals<EvexField> Intervals;

    static Evex()
    {
        Intervals = Bitfields.intervals<EvexField>();
        Kinds = Symbols.kinds<EvexField>().ToArray();
    }

    [MethodImpl(Inline)]
    public static bit test(ReadOnlySpan<byte> src)
    {
        if(src.Length < 4)
            return false;
        else
            return first(src) == 0x62;
    }

    [MethodImpl(Inline)]
    public static EvexPrefix prefix(byte b1, byte b2, byte b3)
        => new (Bytes.join(0x62, b1, b2, b3));

    [MethodImpl(Inline)]
    public static EvexPrefix prefix(AsmHexCode src)
        => @as<EvexPrefix>(src.Bytes);

    [MethodImpl(Inline)]
    public static EvexPrefix prefix(ReadOnlySpan<byte> src)
    {
        if(src.Length < 4)
            return EvexPrefix.Empty;
        else
            return @as<EvexPrefix>(src);
    }

}