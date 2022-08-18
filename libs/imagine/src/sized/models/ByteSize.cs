//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;

    /// <summary>
    /// Specifies data size in bytes
    /// </summary>
    public readonly struct ByteSize : IDataType<ByteSize>
    {
        /// <summary>
        /// Specifies a byte count
        /// </summary>
        public readonly ulong Content;

        [MethodImpl(Inline)]
        public ByteSize(int count)
            => Content = (ulong)count;

        [MethodImpl(Inline)]
        public ByteSize(long count)
            => Content = (ulong)count;

        [MethodImpl(Inline)]
        public ByteSize(uint count)
            => Content = count;

        [MethodImpl(Inline)]
        public ByteSize(ulong count)
            => Content = count;

        public BitWidth Bits
        {
            [MethodImpl(Inline)]
            get => Content*8;
        }

        public Kb Kb
        {
            [MethodImpl(Inline)]
            get => api.kb(this);
        }

        public Mb Mb
        {
            [MethodImpl(Inline)]
            get => Kb.Mb;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.GetHashCode();
        }

        [MethodImpl(Inline),Ignore]
        public ByteSize Align(ulong factor)
            => api.align(this, factor);

        [MethodImpl(Inline),Ignore]
        public ByteSize Align(long factor)
            => api.align(this,factor);

        [MethodImpl(Inline),Ignore]
        public string Format()
            => Content == 0 ? "0" : Content.ToString("#,#");

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Content.GetHashCode();

        [MethodImpl(Inline)]
        public bool Equals(ByteSize src)
            => Content == src.Content;

        [MethodImpl(Inline)]
        public int CompareTo(ByteSize src)
            => Content.CompareTo(src.Content);

        public override bool Equals(object obj)
            => obj is ByteSize ? Equals((ByteSize)obj) : false;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content != 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Content != 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(sbyte src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(byte src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(short src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(ushort src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(int src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(uint src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(ulong src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator long(ByteSize src)
            => (long)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(long src)
            => new ByteSize(src);

        [MethodImpl(Inline)]
        public static implicit operator int(ByteSize src)
            => (int)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator uint(ByteSize src)
            => (uint)src.Content;

        [MethodImpl(Inline)]
        public static explicit operator ushort(ByteSize src)
            => (ushort)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ulong(ByteSize src)
            => src.Content;

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(DataWidth src)
            => new ByteSize((ulong)src/8);

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(ByteSize src)
            => (IntPtr)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(IntPtr src)
            => new ByteSize((ulong)src);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(UIntPtr src)
            => new ByteSize((ulong)src);

        [MethodImpl(Inline)]
        public static implicit operator UIntPtr(ByteSize src)
            => new UIntPtr(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(NativeTypeWidth src)
            => new ByteSize((ulong)src/8);

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(NativeVectorWidth src)
            => new ByteSize((ulong)src/8);

        [MethodImpl(Inline)]
        public static bool operator ==(ByteSize a, ByteSize b)
            => a.Content == b.Content;

        [MethodImpl(Inline)]
        public static bool operator !=(ByteSize a, ByteSize b)
            => a.Content != b.Content;

        [MethodImpl(Inline)]
        public static ByteSize operator +(ByteSize a, ByteSize b)
            => a.Content + b.Content;

        [MethodImpl(Inline)]
        public static ByteSize operator -(ByteSize a, ByteSize b)
            => a.Content - b.Content;

        [MethodImpl(Inline)]
        public static ByteSize operator *(ByteSize a, ByteSize b)
            => a.Content * b.Content;

        [MethodImpl(Inline)]
        public static ByteSize operator /(ByteSize a, ByteSize b)
            => a.Content/b.Content;

        [MethodImpl(Inline)]
        public static ByteSize operator %(ByteSize a, ByteSize b)
            => a.Content % b.Content;

        public static ByteSize Zero
            => default;
    }
}