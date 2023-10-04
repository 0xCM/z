//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class PolyBits
{
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack<A>(A a, uint offset, Span<byte> dst)
        where A : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst, offset)) = a;
        i += size<A>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack<A>(A a, Span<byte> dst)
        where A : unmanaged
            => pack(a,0,dst);

    [MethodImpl(Inline)]
    public static uint pack<A,B>(A a, B b, uint offset, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst,i)) = a;
        i += size<A>();
        @as<B>(seek(dst, i)) = b;
        i += size<B>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline)]
    public static uint pack<A,B>(A a, B b, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
            => pack(a,b,0u,dst);

    [MethodImpl(Inline)]
    public static uint pack<A,B,C>(A a, B b, C c, uint offset, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst,i)) = a;
        i += size<A>();
        @as<B>(seek(dst, i)) = b;
        i += size<B>();
        @as<C>(seek(dst, i)) = c;
        i += size<C>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline)]
    public static uint pack<A,B,C>(A a, B b, C c, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
            => pack(a,b,c,0u,dst);

    [MethodImpl(Inline)]
    public static uint pack<A,B,C,D>(A a, B b, C c, D d, uint offset, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst,i)) = a;
        i += size<A>();
        @as<B>(seek(dst, i)) = b;
        i += size<B>();
        @as<C>(seek(dst, i)) = c;
        i += size<C>();
        @as<D>(seek(dst, i)) = d;
        i += size<D>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline)]
    public static uint pack<A,B,C,D>(A a, B b, C c, D d, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged
            => pack(a,b,c,d,0u,dst);
}
