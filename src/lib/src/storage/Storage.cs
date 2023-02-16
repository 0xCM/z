//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Bytes;

    [ApiHost]
    public readonly partial struct Storage
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static ref ByteBlock16 copy(ReadOnlySpan<byte> src, ref ByteBlock16 dst)
        {
            const ushort Size = ByteBlock16.Size;
            var w = w128;
            ref var target = ref u8(dst);
            var size = max(src.Length, Size);
            var data = slice(src, 0, size);
            if(size == Size)
                vstore(vload(w, data), ref target);
            else
                Bytes.copy(data,  ref target);

            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock32 copy(ReadOnlySpan<byte> src, ref ByteBlock32 dst)
        {
            const ushort Size = ByteBlock32.Size;
            var w = w256;
            ref var target = ref u8(dst);
            var size = max(src.Length, Size);
            var data = slice(src, 0, size);
            if(size == Size)
                vstore(vload(w, data), ref target);
            else
                Bytes.copy(data,  ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock64 copy(ReadOnlySpan<byte> src, ref ByteBlock64 dst)
        {
            ref var lo = ref @as<ByteBlock64,ByteBlock32>(dst);
            ref var hi = ref seek(lo,1);
            copy(src, ref lo);
            copy(slice(src,32), ref hi);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock128 copy(ReadOnlySpan<byte> src, ref ByteBlock128 dst)
        {
            const ushort Block0 = 0*32;
            const ushort Block1 = 1*32;
            const ushort Block2 = 2*32;
            const ushort Block3 = 3*32;

            var v0 = vload(w256, skip(src,Block0));
            vstore(v0, ref seek(u8(dst), Block0));

            v0 = vload(w256, skip(src, Block1));
            vstore(v0, ref seek(u8(dst), Block1));

            v0 = vload(w256, skip(src, Block2));
            vstore(v0, ref seek(u8(dst), Block2));

            v0 = vload(w256, skip(src, Block3));
            vstore(v0, ref seek(u8(dst), Block3));

            return ref dst;
        }

        // [MethodImpl(Inline), Op]
        // public static ReadOnlySpan<char> inflate16u(in ByteBlock8 src)
        //     => recover<char>(bytes(vcpu.vlo(vpack.vinflate256x16u(vcpu.vbytes(w128, u64(src))))));

        // [MethodImpl(Inline), Op]
        // public static ReadOnlySpan<char> inflate16u(in ByteBlock16 src)
        //     => recover<char>(bytes(vcpu.vlo(vpack.vinflate256x16u(vcpu.vbytes(w128, u64(src))))));

        // [MethodImpl(Inline), Op]
        // public static ReadOnlySpan<char> inflate16u(in ByteBlock32 src)
        // {
        //     var v = vload(w256, src.Bytes);
        //     var lo = vpack.vinflatelo256x16u(v);
        //     var hi = vpack.vinflatehi256x16u(v);
        //     return recover<char>(sys.bytes(new V256x2(lo,hi)));
        // }

        [MethodImpl(Inline), Op]
        public static ref T copy<T>(ReadOnlySpan<byte> src, ref T dst)
            where T : unmanaged, IStorageBlock
        {
            var size = max(src.Length, dst.ByteCount);
            ref var target = ref u8(dst);
            if(size == dst.ByteCount)
                dst = @as<T>(src);
            else
                Bytes.copy(slice(src, 0, size), ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock16 block(W128 w, ReadOnlySpan<byte> src)
        {
            var dst = ByteBlock16.Empty;
            copy(src, ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock32 block(W256 w, ReadOnlySpan<byte> src)
        {
            var dst = ByteBlock32.Empty;
            copy(src, ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock64 block(Vector256<byte> lo, Vector256<byte> hi)
        {
            var src = new Seg512(lo,hi);
            var dst = ByteBlocks.alloc(n64);
            copy(bytes(src), ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock32 block(Vector256<byte> src)
        {
            var dst = ByteBlock32.Empty;
            vstore(src, dst.Bytes);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock16 block(Vector128<byte> src)
        {
            var dst = ByteBlock16.Empty;
            vstore(src, dst.Bytes);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Vector128<byte> vector(W128 w, ByteBlock16 src)
            => vload(w, src.Bytes);

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vector(W256 w, ByteBlock32 src)
            => vload(w, src.Bytes);

        [MethodImpl(Inline), Op]
        public static Vector128<T> vector<T>(W128 w, ByteBlock16 src)
            where T : unmanaged
                => vgcpu.vload(w, @as<T>(src.First));

        [MethodImpl(Inline), Op]
        public static Vector256<T> vector<T>(W256 w, ByteBlock32 src)
            where T : unmanaged
                => vgcpu.vload(w, @as<T>(src.First));

        readonly struct Seg512
        {
            readonly Vector256<byte> Lo;

            readonly Vector256<byte> Hi;

            [MethodImpl(Inline), Op]
            public Seg512(Vector256<byte> lo, Vector256<byte> hi)
            {
                Lo = lo;
                Hi = hi;
            }
        }

        [MethodImpl(Inline), Op]
        public static T block<T>(ReadOnlySpan<byte> src)
            where T : unmanaged, IStorageBlock
        {
            var dst = default(T);
            copy(src, ref dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public static TrimmedBlock<T> trim<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src;

        [MethodImpl(Inline)]
        public static ByteSize size<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var data = src.BlockData;
            var length = (int)src.BlockSize;
            var size = 0;
            for(var i=length-1; i>=0; i--)
            {
                ref readonly var b = ref skip(data,i);
                if(b == 0)
                    continue;
                else
                {
                    size = i + 1;
                    break;
                }

            }
            return size;
        }

        [MethodImpl(Inline)]
        public static bool empty<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
        {
            var b = src.Bytes;
            var count = b.Length;
            var empty = true;
            for(var i=0; i<count; i++)
            {
                if(skip(b,i) != 0)
                {
                    empty=false;
                    break;
                }
            }
            return empty;
        }
    }
}