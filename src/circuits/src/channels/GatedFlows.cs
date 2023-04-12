//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = NativeChannels;

    [ApiHost]
    public readonly partial struct GatedFlows
    {
        const NumericKind Closure = Integers;

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit u1<T>(T src)
            where T : unmanaged
                => @as<T,bit>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static T u1<T>(bit src)
            => @as<bit,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T and<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.and(u1(a), u1(b))) : gmath.and(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T or<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.or(u1(a), u1(b))) : gmath.or(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T xor<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.xor(u1(a),u1(b))) : gmath.xor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T nand<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.nand(u1(a),u1(b))) : gmath.nand(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T nor<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.nor(u1(a),u1(b))) : gmath.nor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T xnor<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.xnor(u1(a),u1(b))) : gmath.xnor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T mux<T>(T a, T b, T c)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.select(u1(a),u1(b), u1(c))) : gmath.select(a,b,c);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Pair<T> demux<T>(T a, T b)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T not<T>(T a)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.not(u1(a))) : gmath.not(a);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2,W8> channel(N2 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N3,W8> channel(N3 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4,W8> channel(N4 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N5,W8> channel(N5 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N6,W8> channel(N6 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N7,W8> channel(N7 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W8> channel(N8 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1,W16> channel(N1 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2,W16> channel(N2 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N3,W16> channel(N3 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4,W16> channel(N4 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N5,W16> channel(N5 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N6,W16> channel(N6 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N7,W16> channel(N7 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W8> channel(N16 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W8> channel(N32 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W8> channel(N64 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W8> channel(N128 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W8> channel(N256 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W8> channel(N512 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W8> channel(N1024 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W8> channel(N2048 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W8> channel(N4096 n, W8 w)
            => api.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W16> channel(N8 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W16> channel(N16 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W16> channel(N32 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W16> channel(N64 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W16> channel(N128 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W16> channel(N256 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W16> channel(N512 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W16> channel(N1024 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W16> channel(N2048 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W16> channel(N4096 n, W16 w)
            => api.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W32> channel(N8 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W32> channel(N16 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W32> channel(N32 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W32> channel(N64 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W32> channel(N128 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W32> channel(N256 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W32> channel(N512 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W32> channel(N1024 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W32> channel(N2048 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W32> channel(N4096 n, W32 w)
            => api.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W64> channel(N8 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W64> channel(N16 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W64> channel(N32 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W64> channel(N64 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W64> channel(N128 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W64> channel(N256 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W64> channel(N512 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W64> channel(N1024 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W64> channel(N2048 n, W64 w)
            => api.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W64> channel(N4096 n, W64 w)
            => api.channel(n,w64);
    }
}