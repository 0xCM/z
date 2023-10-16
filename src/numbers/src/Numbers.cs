//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost, Free]
public partial class Numbers
{
    [MethodImpl(Inline), Op]
    public static string bitstring<T>(T src)
        where T : unmanaged, INumber<T>
            => BitRender.gformat(src, BitFormatter.limited(src.PackedWidth, src.PackedWidth));

    [MethodImpl(Inline), Op]
    public static ulong max(byte width)
        => (ulong)Pow2.m1(width);

    /// <summary>
    /// Specifes the number of values covered by an <typeparamref name='N'>-bit number
    /// </summary>
    /// <param name="n">The natural bit width</param>
    /// <typeparam name="N">The natural with type</typeparam>
    [MethodImpl(Inline)]
    public static uint count<N>(N n)
        where N : unmanaged, ITypeNat
            => (uint)Pow2.pow((byte)n.NatValue);
}
