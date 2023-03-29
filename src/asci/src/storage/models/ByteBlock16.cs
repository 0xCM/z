//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using B = ByteBlock16;
    using api = Storage;

    /// <summary>
    /// Defines 16 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1)]
    public struct ByteBlock16 : IStorageBlock<B>, IEquatable<B>
    {
        public const ushort Size = 16;

        public const uint Width = Size*8;

        public static N16 N => default;

        public static W128 W => default;

        public ulong A;

        public ulong B;

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
        public ref T Cell<T>(int index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public ref T Cell<T>(uint index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public Vector128<T> Vector<T>()
            where T : unmanaged
                => api.vector<T>(W, this);

        [MethodImpl(Inline)]
        public bool Equals(B src)
            => vcpu.vsame(Vector<ulong>(), src.Vector<ulong>());

        public override bool Equals(object src)
            => src is B b && Equals(b);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Bytes);
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => api.format(this);

        public string Format(bool prespec, bool uppercase)
            => api.format(this, Chars.Space, prespec, uppercase);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<byte>(B src)
            => api.vector(W, src);

        [MethodImpl(Inline)]
        public static implicit operator B(Vector128<byte> src)
            => api.block(src);

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<byte> src)
            => api.block(W,src);

        [MethodImpl(Inline)]
        public static implicit operator B(Span<byte> src)
            => api.block(W,src);

        [MethodImpl(Inline)]
        public static implicit operator B(ulong src)
        {
            var dst = Empty;
            dst.A = src;
            dst.B = 0;
            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator B((ulong a, ulong b) src)
        {
            var dst = Empty;
            dst.A = src.a;
            dst.B = src.b;
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool operator==(B a, B b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(B a, B b)
            => !a.Equals(b);

        public static B Empty => default;
    }
}