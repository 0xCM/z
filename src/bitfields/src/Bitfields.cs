//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public readonly partial struct Bitfields
{
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline)]
    public static BitSegType segtype(NativeClass @class, ushort total, ushort cell)
        => new (@class, total, cell == 0 ? (ushort)1 : cell);

}
