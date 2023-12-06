//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;

    using C = AsciCode;
    using S = AsciSymbol;

    [ApiHost]
    public readonly struct AsciBlocks
    {
        const NumericKind Closure = UnsignedInts;

        // internal static string format<B>(in B src)
        //     where B : unmanaged
        // {
        //     var size = sys.size<B>();
        //     Span<char> dst = stackalloc char[(int)size];
        //     var count = AsciSymbols.decode(sys.bytes(src), dst);
        //     return new string(slice(dst,0,count));        
        // }

        // internal static string format(AsciBlock32 src)
        // {
        //     var dst = CharBlock32.Empty;
        //     return new string(decode(src, ref dst));
        // }

        // public static string format<N>(AsciBlock<N> src)
        //     where N : unmanaged, ITypeNat
        // {
        //     var dst = span<char>(src.View.Length);
        //     var count = AsciSymbols.decode(src.View,dst);
        //     return new string(slice(dst,0,count));
        // }

        // [MethodImpl(Inline), Op]
        // public static uint decode<N>(in AsciBlock<N> src, Span<char> dst)
        //     where N : unmanaged, ITypeNat
        //         => AsciSymbols.decode(src.Codes,dst);

        // public static AsciBlock<N> block<N>(Span<S> src, N n = default)
        //     where N : unmanaged, ITypeNat
        //         => new AsciBlock<N>(slice(src,0, sys.min(src.Length, (int)n.NatValue)));

        // public static AsciBlock<N> block<N>(string src, N n = default)
        //     where N : unmanaged, ITypeNat
        // {
        //     var buffer = sys.alloc<S>(Typed.value<N>());
        //     buffer.Clear();
        //     var chars = span(src);
        //     ref var dst = ref first(buffer);
        //     var count = sys.min(buffer.Length, chars.Length);
        //     for(var i=0; i<count; i++)
        //         sys.seek(dst,i) = skip(chars,i);
        //     return new AsciBlock<N>(buffer);
        // }

        // public static AsciBlock<N> block<N>(N n = default)
        //     where N : unmanaged, ITypeNat
        //         => new AsciBlock<N>(sys.alloc<S>(Typed.value<N>()));

        [MethodImpl(Inline)]
        public static T load<T>(ReadOnlySpan<C> src, out T target)
            where T : unmanaged
        {
            var size = sys.size<T>();
            target = default(T);
            var count = min(src.Length,size);
            ref var dst = ref @as<C>(sys.first(sys.bytes(target)));
            for(var i=0; i<count; i++)
                seek(dst, i) = skip(src, i);
            return target;
        }

        [MethodImpl(Inline)]
        public static T load<T>(ReadOnlySpan<S> src, out T target)
            where T : unmanaged
        {
            target = default(T);
            var size = sys.size<T>();
            var count = min(src.Length,size);
            ref var dst = ref @as<S>(sys.first(sys.bytes(target)));
            for(var i=0; i<count; i++)
                seek(dst, i) = skip(src, i);
            return target;
        }

        // public static AsciBlock<N> load<N>(S[] src, N n = default)
        //     where N : unmanaged, ITypeNat
        // {
        //     Require.equal<N>(src.Length);
        //     return new AsciBlock<N>(src);
        // }

        // [MethodImpl(Inline), Op]
        // public static AsciBlock4 encode(string src, out AsciBlock4 dst)
        //     => encode(span(src), out dst);

        // [MethodImpl(Inline), Op]
        // public static AsciBlock8 encode(string src, out AsciBlock8 dst)
        //     => encode(span(src), out dst);

        // [MethodImpl(Inline), Op]
        // public static AsciBlock16 encode(string src, out AsciBlock16 dst)
        //     => encode(span(src), out dst);

        // [MethodImpl(Inline), Op]
        // public static AsciBlock32 encode(string src, out AsciBlock32 dst)
        //     => encode(span(src), out dst);

        // [MethodImpl(Inline), Op]
        // public static AsciBlock64 encode(string src, out AsciBlock64 dst)
        //     => encode(span(src), out dst);

        // [MethodImpl(Inline), Op]
        // public static AsciBlock4 encode(ReadOnlySpan<char> src, out AsciBlock4 dst)
        // {
        //     dst = default;
        //     var count = min(ByteBlock4.N, src.Length);
        //     encode(src, slice(dst.Bytes,0,count));
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static AsciBlock8 encode(ReadOnlySpan<char> src, out AsciBlock8 dst)
        // {
        //     dst = default;
        //     var count = min(ByteBlock8.N, src.Length);
        //     encode(src, slice(dst.Bytes,0,count));
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static AsciBlock16 encode(ReadOnlySpan<char> src, out AsciBlock16 dst)
        // {
        //     dst = default;
        //     var count = min(ByteBlock16.N, src.Length);
        //     encode(src, slice(dst.Bytes,0,count));
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static AsciBlock24 encode(ReadOnlySpan<char> src, out AsciBlock24 dst)
        // {
        //     dst = default;
        //     var count = min(ByteBlock24.N, src.Length);
        //     encode(src, slice(dst.Bytes,0,count));
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static AsciBlock32 encode(ReadOnlySpan<char> src, out AsciBlock32 dst)
        // {
        //     dst = AsciBlock32.Empty;
        //     var count = min(ByteBlock32.N, src.Length);
        //     encode(src, slice(dst.Bytes,0,count));
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static AsciBlock64 encode(ReadOnlySpan<char> src, out AsciBlock64 dst)
        // {
        //     dst = AsciBlock64.Empty;
        //     var count = min(ByteBlock64.N, src.Length);
        //     encode(src, slice(dst.Bytes,0,count));
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static void decode(AsciBlock16 src, ref char dst)
        // {
        //    var decoded = vpack.vinflate256x16u(src.First);
        //    vstore(decoded, ref @as<char,ushort>(dst));
        // }

        // [MethodImpl(Inline), Op]
        // public static ReadOnlySpan<char> decode(AsciBlock16 src, ref CharBlock16 dst)
        // {
        //     decode(src, ref dst.First);
        //     var length = text.index(dst.Data, '\0');
        //     if(length == NotFound)
        //         return dst.Data;
        //     else
        //         return slice(dst.Data, 0, length);
        // }

        // [MethodImpl(Inline), Op]
        // public static void decode(AsciBlock32 src, ref char dst)
        // {
        //     decode(src.Lo, ref dst);
        //     decode(src.Hi, ref sys.seek(dst, 16));
        // }

        // [MethodImpl(Inline), Op]
        // public static ReadOnlySpan<char> decode(AsciBlock32 src, ref CharBlock32 dst)
        // {
        //     decode(src, ref dst.First);
        //     var length = text.index(dst.Data, '\0');
        //     if(length == NotFound)
        //         return dst.Data;
        //     else
        //         return slice(dst.Data, 0, length);
        // }

        // [MethodImpl(Inline), Op]
        // public static string decode(AsciBlock64 src)
        // {
        //     ref var storage = ref src.First;
        //     var v1 = vload(w256, storage);
        //     var v2 = vload(w256, sys.seek(storage, 32));
        //     var x0 = vpack.vinflatelo256x16u(v1);
        //     var x1 = vpack.vinflatehi256x16u(v1);
        //     var x2 = vpack.vinflatelo256x16u(v2);
        //     var x3 = vpack.vinflatehi256x16u(v2);
        //     var chars = recover<char>(sys.bytes(new V256x4(x0, x1, x2, x3)));
        //     var length = text.index(chars, '\0');
        //     if(length == NotFound)
        //         return new(chars);
        //     else
        //         return new (slice(chars, 0, length));
        // }
 
        [MethodImpl(Inline), Op]
        public static int encode(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
            return count;
        }
    }
}