//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static char decode(C src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char decode(S src)
            => src;

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<C> src, Span<char> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = decode(skip(src,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<S> src, Span<char> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = decode(skip(src,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (char)skip(src,i);
            return (uint)count;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci2 src)
        {
            var storage = 0u;
            ref var dst = ref @as<uint,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            return sys.cover(dst, 2);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci4 src)
        {
            var storage = 0ul;
            ref var dst = ref @as<ulong,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            seek(dst, 2) = (char)(byte)(src.Storage >> 16);
            seek(dst, 3) = (char)(byte)(src.Storage >> 24);
            return slice(sys.cover(dst, asci4.Size),0, src.Length);
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci16 src, ref char dst)
        {
           var decoded = vpack.vinflate256x16u(src.Storage);
           cpu.vstore(decoded, ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(N16 n, ReadOnlySpan<byte> src, Span<char> dst)
            => cpu.vstore(vpack.vinflate256x16u(cpu.vload(w128,src)), ref @as<ushort>(core.first(dst)));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci16 src)
            => slice(recover<char>(core.bytes(vpack.vinflate256x16u(src.Storage))),0, src.Length);

        [MethodImpl(Inline), Op]
        public static void decode(N48 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = cpu.vload(w256, src);
            var offset = z8;
            cpu.vstore(vpack.vinflatelo256x16u(v), ref target);
            offset+=16;
            cpu.vstore(vpack.vinflatehi256x16u(v), ref seek(target,offset));
            offset+=16;
            decode(n16, core.slice(src,offset), core.slice(dst,offset));
        }

        [MethodImpl(Inline), Op]
        public static Vector128<ushort> decode(ulong src)
            => cpu.vlo(vpack.vinflate256x16u(cpu.v8u(cpu.vscalar(src))));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> decode(Vector128<byte> src)
            => vpack.vinflate256x16u(src);

        [MethodImpl(Inline), Op]
        public static Vector512<ushort> decode(Vector256<byte> src)
            => cpu.vparts(w512, vpack.vinflatelo256x16u(src), vpack.vinflatehi256x16u(src));

        [MethodImpl(Inline), Op]
        public static ref string decode(ReadOnlySpan<byte> src, out string dst)
        {
            Span<char> buffer = stackalloc char[src.Length];
            decode(src, buffer);
            dst = sys.@string(buffer);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static void decode(N32 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = cpu.vload(w256, src);
            cpu.vstore(vpack.vinflatelo256x16u(v), ref target);
            cpu.vstore(vpack.vinflatehi256x16u(v), ref seek(target,16));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci32 src)
        {
            var lo = vpack.vinflatelo256x16u(src.Storage);
            var hi = vpack.vinflatehi256x16u(src.Storage);
            return slice(recover<char>(core.bytes(new V256x2(lo,hi))), 0, src.Length);
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci32 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 16));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci64 src)
        {
            var x = src.Storage;
            var x0 = vpack.vinflatelo256x16u(x.Lo);
            var x1 = vpack.vinflatehi256x16u(x.Lo);
            var x2 = vpack.vinflatelo256x16u(x.Hi);
            var x3 = vpack.vinflatehi256x16u(x.Hi);
            return slice(recover<char>(core.bytes(new V256x4(x0, x1, x2, x3))),0, src.Length);
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci64 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 32));
        }

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
            return sys.cover(dst, ByteBlock4.Size);
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
            var chars = recover<char>(sys.bytes(new V256x4(x0, x1, x2, x3)));
            var length = text.index(chars, '\0');
            if(length == NotFound)
                return chars;
            else
                return slice(chars, 0, length);
        }
    }
}