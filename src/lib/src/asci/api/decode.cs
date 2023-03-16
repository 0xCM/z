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

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static char decode(C src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char decode(S src)
            => src;

        [MethodImpl(Inline), Op]
        public static string decode(asci2 src)
        {
            var storage = 0u;
            ref var dst = ref @as<uint,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            return sys.@string(sys.cover(dst, 2));
        }

        [MethodImpl(Inline), Op]
        public static string decode(asci4 src)
        {
            var storage = 0ul;
            ref var dst = ref @as<ulong,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            seek(dst, 2) = (char)(byte)(src.Storage >> 16);
            seek(dst, 3) = (char)(byte)(src.Storage >> 24);
            return sys.@string(slice(sys.cover(dst, asci4.Size),0, src.Length));
        }

        [MethodImpl(Inline), Op]
        public static void decode(asci16 src, ref char dst)
        {
           var decoded = vpack.vinflate256x16u(src.Storage);
           cpu.vstore(decoded, ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(N16 n, ReadOnlySpan<byte> src, Span<char> dst)
            => vcpu.vstore(vpack.vinflate256x16u(vcpu.vload(w128,src)), ref @as<ushort>(sys.first(dst)));

        [MethodImpl(Inline), Op]
        public static string decode(asci16 src)
            => sys.@string(slice(recover<char>(sys.bytes(vpack.vinflate256x16u(src.Storage))),0, src.Length));

        [MethodImpl(Inline), Op]
        public static void decode(N48 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = vload(w256, src);
            var offset = z8;
            vstore(vpack.vinflatelo256x16u(v), ref target);
            offset+=16;
            vstore(vpack.vinflatehi256x16u(v), ref seek(target,offset));
            offset+=16;
            decode(n16, sys.slice(src,offset), sys.slice(dst,offset));
        }

        [MethodImpl(Inline), Op]
        public static Vector128<ushort> decode(ulong src)
            => vlo(vpack.vinflate256x16u(v8u(vscalar(src))));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> decode(Vector128<byte> src)
            => vpack.vinflate256x16u(src);

        [MethodImpl(Inline), Op]
        public static Vector512<ushort> decode(Vector256<byte> src)
            => vparts(w512, vpack.vinflatelo256x16u(src), vpack.vinflatehi256x16u(src));

        [MethodImpl(Inline), Op]
        public static string decode(ReadOnlySpan<byte> src, out string dst)
        {
            Span<char> buffer = stackalloc char[src.Length];
            AsciSymbols.decode(src, buffer);
            dst = sys.@string(buffer);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static void decode(N32 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = vload(w256, src);
            vstore(vpack.vinflatelo256x16u(v), ref target);
            vstore(vpack.vinflatehi256x16u(v), ref seek(target,16));
        }

        [MethodImpl(Inline), Op]
        public static string decode(asci32 src)
        {
            var lo = vpack.vinflatelo256x16u(src.Storage);
            var hi = vpack.vinflatehi256x16u(src.Storage);
            return new(slice(recover<char>(sys.bytes(new V256x2(lo,hi))), 0, src.Length));
        }

        [MethodImpl(Inline), Op]
        public static void decode(asci32 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 16));
        }

        [MethodImpl(Inline), Op]
        public static string decode(asci64 src)
        {
            var x = src.Storage;
            var x0 = vpack.vinflatelo256x16u(x.Lo);
            var x1 = vpack.vinflatehi256x16u(x.Lo);
            var x2 = vpack.vinflatelo256x16u(x.Hi);
            var x3 = vpack.vinflatehi256x16u(x.Hi);
            return new(slice(recover<char>(sys.bytes(new V256x4(x0, x1, x2, x3))),0, src.Length));
        }

        [MethodImpl(Inline), Op]
        public static void decode(asci64 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 32));
        }

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

        public static unsafe void decode(MemoryFile src, Action<CharBlock32> receiver)
        {
            var size = src.FileSize;
            var blocks = (uint)size/32;
            var remainder = (uint)size%32;
            decode(src, blocks, remainder, receiver);
        }

        public static unsafe void decode(MemoryFile src, uint blocks, uint remainder, Action<CharBlock32> receiver)
        {
            const uint BlockSize = 32;
            var counter = 0u;
            var seg = src.Segment();
            var offset = src.BaseAddress;
            var dst = CharBlock32.Null;
            for(var i=0u; i<blocks; i++)
            {
                decode(offset, BlockSize, out dst);
                receiver(dst);
                offset = offset + BlockSize;
            }
            decode(offset, remainder, out dst);
            receiver(dst);
        }

        public static unsafe void decode(MemoryAddress src, uint size, out CharBlock32 dst)
        {
            var input = sys.cover(src.Pointer<byte>(), size);
            dst = CharBlock32.Null;
            var buffer = recover<ushort>(dst.Data);
            if(size == 32)
                gcpu.vstore(Asci.decode(vcpu.vload(w256, input)), buffer);
            else
            {
                for(var i=0; i<size; i++)
                    seek(buffer,i) = skip(input,i);
            }
        }            
    }
}