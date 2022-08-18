//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = CharBlocks;
    using B = CharBlock64;

    /// <summary>
    /// Defines a character block b with capacity(b) = 64x16u
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=2, Size = Size)]
    public struct CharBlock64 : ICharBlock<B>
    {
        /// <summary>
        /// The block capacity
        /// </summary>
        public const ushort CharCount = 64;

        /// <summary>
        /// The size of the block, in bytes
        /// </summary>
        public const ushort Size = CharCount * 2;

        public Span<char> Data
        {
            [MethodImpl(Inline)]
            get => cover<B,char>(this, CharCount);
        }

        /// <summary>
        /// If the block contains no null-terminators, returns a readonly view of the data source; otherwise returns the content preceding the first null-terminator
        /// </summary>
        public ReadOnlySpan<char> String
        {
            [MethodImpl(Inline)]
            get => text.@string(Data);
        }

        /// <summary>
        /// Specifies a reference to the leading cell
        /// </summary>
        public ref char First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public ref char this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public ref char this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public uint Capacity
            => CharCount;

        public int Length
        {
            [MethodImpl(Inline)]
            get => api.length(this);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator B(string src)
            => api.init(src, out B dst);

        [MethodImpl(Inline)]
        public static implicit operator string(B src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<char> src)
            => api.init(src, out B dst);

        public static B Empty => RpOps.Spaced64;

        public static B Null => default;
    }
}