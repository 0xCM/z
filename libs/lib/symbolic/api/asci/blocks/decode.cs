//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;
    using static Scalars;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct AsciBlocks
    {
        [MethodImpl(Inline), Op]
        public static uint decode<N>(in AsciBlock<N> src, Span<char> dst)
            where N : unmanaged, ITypeNat
                => decode(src.Codes,dst);

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<C> src, Span<char> dst, bool stopOnNull = true)
        {
            var count = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                if(code == 0 && stopOnNull)
                    break;

                seek(dst,i) = (char)code;
                counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<S> src, Span<char> dst, bool stopOnNull = true)
            => decode(recover<S,C>(src), dst, stopOnNull);

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<byte> src, Span<char> dst, bool stopOnNull = true)
            => decode(recover<byte,C>(src), dst, stopOnNull);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock4 src)
        {
            var storage = 0ul;
            ref var dst = ref sys.@as<ulong,char>(storage);
            ref readonly var input = ref sys.@as<byte,uint>(src.First);
            sys.seek(dst, 0) = (char)(byte)(input >> 0);
            sys.seek(dst, 1) = (char)(byte)(input >> 8);
            sys.seek(dst, 2) = (char)(byte)(input >> 16);
            sys.seek(dst, 3) = (char)(byte)(input >> 24);
            return Algs.cover(dst, ByteBlock4.Size);
        }

        [MethodImpl(Inline), Op]
        public static void decode(in AsciBlock8 src, ref char dst)
        {
            var decoded = vpack.vinflate256x16u(cpu.vbytes(w128, src));
            cpu.vstore(decoded.GetLower(), ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in AsciBlock16 src, ref char dst)
        {
           var decoded = vpack.vinflate256x16u(src.First);
           cpu.vstore(decoded, ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in AsciBlock32 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref sys.seek(dst, 16));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock16 src)
        {
            var dst = CharBlock16.Null;
            decode(src, ref dst.First);
            var length = text.index(dst.Data, '\0');
            if(length == NotFound)
                return dst.Data;
            else
                return slice(dst.Data, 0, length);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock32 src)
        {
            var dst = CharBlock32.Null;
            decode(src, ref dst.First);
            var length = text.index(dst.Data, '\0');
            if(length == NotFound)
                return dst.Data;
            else
                return slice(dst.Data, 0, length);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock64 src)
        {
            ref var storage = ref src.First;
            var v1 = cpu.vload(w256, storage);
            var v2 = cpu.vload(w256, sys.seek(storage, 32));
            var x0 = vpack.vinflatelo256x16u(v1);
            var x1 = vpack.vinflatehi256x16u(v1);
            var x2 = vpack.vinflatelo256x16u(v2);
            var x3 = vpack.vinflatehi256x16u(v2);
            var chars = recover<char>(bytes(new V256x4(x0, x1, x2, x3)));
            var length = text.index(chars, '\0');
            if(length == NotFound)
                return chars;
            else
                return slice(chars, 0, length);
        }
    }
}