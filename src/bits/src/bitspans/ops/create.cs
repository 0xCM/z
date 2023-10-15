//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitSpans
{
    [Op, Closures(Closure)]
    public static BitSpan create<T>(T src)
        where T : unmanaged
            => gpack.unpack(src);

    [Op, Closures(Closure)]
    public static BitSpan create<T>(ReadOnlySpan<T> src)
        where T : unmanaged
            => gpack.unpack(src);

    [Op, Closures(Closure)]
    public static BitSpan create<T>(Span<T> src)
        where T : unmanaged
            => gpack.unpack(src.ReadOnly());

    [Op, Closures(Closure)]
    public static BitSpan create<T>(ReadOnlySpan<T> src, Span<bit> buffer)
        where T : unmanaged
    {
        gpack.unpack(src, buffer);
        return buffer;
    }
}
