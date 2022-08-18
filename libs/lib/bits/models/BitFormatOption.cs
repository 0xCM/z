//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitFormatOption.OptionKind;

    public struct BitFormatOption
    {
        readonly OptionKind Kind;

        readonly byte Data;

        [MethodImpl(Inline)]
        public BitFormatOption(OptionKind kind)
        {
            Kind = kind;
            Data = byte.MaxValue;
        }

        [MethodImpl(Inline)]
        public BitFormatOption(OptionKind kind, byte width)
        {
            Kind = kind;
            Data = width;
        }

        public bool IsTrimmed
        {
            [MethodImpl(Inline)]
            get => (Kind & Trimmed) != 0;
        }

        public bool IsPadded
        {
            [MethodImpl(Inline)]
            get => (Kind & Padded) != 0;
        }

        public bool IsLimited
        {
            [MethodImpl(Inline)]
            get => (Kind & Limited) != 0;
        }

        public bool HasSpecifier
        {
            [MethodImpl(Inline)]
            get => (Kind & OptionKind.Specifier) != 0;
        }

        public bool IsBlocked
        {
            [MethodImpl(Inline)]
            get => (Kind & OptionKind.Blocked) != 0;
        }

        public char BlockSep
        {
            [MethodImpl(Inline)]
            get => (Kind & UnderscoreSep) != 0 ? '_' : ' ';
        }

        public string Specifier
        {
            [MethodImpl(Inline)]
            get => HasSpecifier ? "0b" : EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public byte MaxWidth
        {
            [MethodImpl(Inline)]
            get => IsLimited ? Width : byte.MaxValue;
        }

        public static BitFormatOption Empty => default;

        [Flags]
        public enum OptionKind : byte
        {
            None,

            Trimmed = 1,

            Padded = 2,

            Specifier = 4,

            SpaceSep = 8,

            UnderscoreSep = 16,

            Blocked = 32,

            Limited = 64,
        }
    }
}