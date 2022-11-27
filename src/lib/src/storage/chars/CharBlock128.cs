//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = CharBlocks;
    using B = CharBlock128;

    /// <summary>
    /// Defines a character block b with capacity(b) = 128x16u
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=2)]
    public struct CharBlock128 : ICharBlock<B>
    {
        CharBlock64 Lo;

        CharBlock64 Hi;

        public Span<char> Data
        {
            [MethodImpl(Inline)]
            get => cover<B,char>(this, CharCount);
        }

        /// <summary>
        /// If the block contains no null-terminators, returns a readonly view of the data source; otherwise
        /// returns the content preceding the first null-terminator
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

        [MethodImpl(Inline)]
        public ref CharBlock32 Block(N0 n, N32 w)
        {
            ref var c = ref seek(Data,0);
            return ref @as<char,CharBlock32>(c);
        }

        [MethodImpl(Inline)]
        public ref CharBlock32 Block(N1 n, N32 w)
        {
            ref var c = ref seek(Data,32);
            return ref @as<char,CharBlock32>(c);
        }

        [MethodImpl(Inline)]
        public ref CharBlock32 Block(N2 n, N32 w)
        {
            ref var c = ref seek(Data,64);
            return ref @as<char,CharBlock32>(c);
        }

        [MethodImpl(Inline)]
        public ref CharBlock32 Block(N3 n, N32 w)
        {
            ref var c = ref seek(Data,86);
            return ref @as<char,CharBlock32>(c);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator B(string src)
            => api.init(src, out B dst);

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<char> src)
            => api.init(src, out B dst);

        public static B Empty => RpOps.Spaced128;

        public static B Null => default;

        /// <summary>
        /// The block capacity
        /// </summary>
        public const ushort CharCount = 128;

        /// <summary>
        /// The size of the block, in bytes
        /// </summary>
        public const uint Size = CharCount * 2;
    }
}