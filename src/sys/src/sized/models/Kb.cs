//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct Kb : IDataString<Kb>
    {
        public const string UOM = "kb";

        /// <summary>
        /// Specifies a kilobyte count
        /// </summary>
        public readonly uint Count;

        /// <summary>
        /// Specifies the remaining bit count
        /// </summary>
        public readonly uint Rem;

        [MethodImpl(Inline)]
        public Kb(uint count, uint rem)
        {
            Count = count;
            Rem = rem;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => api.bits(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public Mb Mb
        {
            [MethodImpl(Inline)]
            get => api.mb(this);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash((ulong)Size);
        }

        [MethodImpl(Inline)]
        public int CompareTo(Kb src)
            => Size.CompareTo(src.Size);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Kb rhs)
            => api.eq(this, rhs);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(Kb src)
            => api.size(src);

        [MethodImpl(Inline)]
        public static explicit operator BitWidth(Kb src)
            => api.bits(src);

        [MethodImpl(Inline)]
        public static implicit operator Kb(DataWidth src)
            => api.kb((BitWidth)src);

        [MethodImpl(Inline)]
        public static implicit operator DataWidth(Kb src)
            => api.bits(src);

        [MethodImpl(Inline)]
        public static implicit operator Kb(NativeTypeWidth src)
            => api.kb((BitWidth)src);

        [MethodImpl(Inline)]
        public static implicit operator NativeTypeWidth(Kb src)
            => api.bits(src);

        [MethodImpl(Inline)]
        public static implicit operator Kb(NativeVectorWidth src)
            => api.kb((BitWidth)src);

        [MethodImpl(Inline)]
        public static implicit operator Kb(NumericWidth src)
            => api.kb((BitWidth)src);

        /// <summary>
        /// The bit with no size
        /// </summary>
        public static Kb Empty
            => default;

        /// <summary>
        /// The bit with no size
        /// </summary>
        public static Kb Zero
            => default;
    }
}