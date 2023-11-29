//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitGrid
{
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BitGrid<T> create<T>(GridDim<ushort> dim, T src)
        where T : unmanaged
            => new BitGrid<T>(dim,src);

    [MethodImpl(Inline), Op]
    public static BitGrid64<N16,N4,ushort> create(N64 w, N16 m, N4 n,
        ushort x0, ushort x1, ushort x2, ushort x3)
            => first(SpanBlocks.load(w, x0,x1,x2,x3),m, n);

    [MethodImpl(Inline), Op]
    public static BitGrid64<N4,N16,ulong> create(N64 w, N4 m, N16 n, ulong src)
        => new(src);

    [MethodImpl(Inline), Op]
    public static BitGrid128<N8,N16,ushort> create(N128 w, N8 m, N16 n,
        ushort x0, ushort x1, ushort x2, ushort x3,
        ushort x4, ushort x5, ushort x6, ushort x7)
            => first(SpanBlocks.load(w, x0,x1,x2,x3,x4,x5,x6,x7),m,n);

    [MethodImpl(Inline), Op]
    public static BitGrid128<N16,N8,byte> create(N128 w, N16 m, N8 n,
        byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7,
        byte x8, byte x9, byte xA, byte xB, byte xC, byte xD, byte xE, byte xF)
            => first(SpanBlocks.load(w, x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,xA,xB,xC,xD,xE,xF),m,n);

    [MethodImpl(Inline), Op]
    public static BitGrid128<N4,N32,uint> create(N128 w, N4 m, N32 n,
        uint x0, uint x1, uint x2, uint x3)
            => first(SpanBlocks.load(w, x0,x1,x2,x3),m,n);

    [MethodImpl(Inline), Op]
    public static BitGrid128<N2,N64,ulong> create(N128 w, N2 m, N64 n, ulong x0, ulong x1)
        => first(SpanBlocks.load(w, x0,x1),m,n);

    [MethodImpl(Inline), Op]
    public static BitGrid256<N16,N16,ushort> create(N256 w, N16 m, N16 n,
        ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7,
        ushort x8, ushort x9, ushort xA, ushort xB, ushort xC, ushort xD, ushort xE, ushort xF)
            => first(SpanBlocks.load(w, x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,xA,xB,xC,xD,xE,xF),m,n);

    [MethodImpl(Inline), Op]
    public static BitGrid256<N16,N16,uint> create(N256 w, N16 m, N16 n,
        uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7)
            => first(SpanBlocks.load(w, x0,x1,x2,x3,x4,x5,x6,x7),m,n);

    [MethodImpl(Inline), Op]
    public static BitGrid256<N16,N16,ulong> create(N256 w, N16 m, N16 n, ulong x0, ulong x1, ulong x2, ulong x3)
        => first(SpanBlocks.load(w, x0,x1,x2,x3),m,n);
}
