//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = ByteBlock64;
    using api = Storage;

    /// <summary>
    /// Covers 64 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1)]
    public struct ByteBlock64 : IStorageBlock<B>
    {
        public const ushort Size = 64;

        public static N64 N => default;

        ByteBlock32 A;

        ByteBlock32 B;

        [MethodImpl(Inline)]
        public ByteBlock64(ByteBlock32 a, ByteBlock32 b)
        {
            A = a;
            B = b;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Bytes);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => api.empty(this);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !api.empty(this);
        }

        public ref byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public ref T Cell<T>(int index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public ref T Cell<T>(uint index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public Vector512<T> Vector<T>()
            where T : unmanaged
                => vgcpu.vload<T>(w512, @as<T>(First));

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Vector512<byte>(B src)
            => vgcpu.vload(default(W512), src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator B(Vector512<byte> src)
        {
            var dst = Empty;
            vcpu.vstore(src, dst.Bytes);
            return dst;
        }

        public static B Empty => default;
    }
}