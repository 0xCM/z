//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TextBlock : IDataString<TextBlock>, IText
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public TextBlock(string src)
            => Data = src ?? EmptyString;

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public Hash32 Hash
        {
            get => Algs.hash(Text);
        }
        public int Length
        {
            [MethodImpl(Inline)]
            get => Text.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public bool IsWhitespace
        {
            [MethodImpl(Inline)]
            get => IsNonEmpty && string.IsNullOrWhiteSpace(Data);
        }

        public bool IsInterned
        {
            [MethodImpl(Inline)]
            get => string.IsInterned(Data) != null;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public string Format(int? pad)
            => pad != null ? string.Format(RP.pad(pad.Value), Data) : Data;

        [MethodImpl(Inline)]
        public TextBlock ToLower()
            => Data?.ToLowerInvariant() ?? EmptyString;

        [MethodImpl(Inline)]
        public bool Contains(string substring)
            => Text.Contains(substring);

        [MethodImpl(Inline)]
        public TextBlock Trim()
            => Data?.Trim() ?? EmptyString;

        [MethodImpl(Inline)]
        public TextBlock Replace(TextBlock match, TextBlock value)
            => Text.Replace(match,value);

        [MethodImpl(Inline)]
        public bool StartsWith(TextBlock match)
            => Text.StartsWith(match.Text);

        [MethodImpl(Inline)]
        public bool EndsWith(TextBlock match)
            => Text.EndsWith(match.Text);

        public bool Equals(TextBlock src)
            => string.Equals(Data, src.Data);

        public bool Equals(TextBlock src, bool insensitive)
            => insensitive
            ? string.Equals(Data, src.Data, StringComparison.CurrentCultureIgnoreCase)
            : string.Equals(Data, src.Data);

        public override bool Equals(object src)
            => src is TextBlock x && Equals(x);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(TextBlock src)
            => string.Compare(Data, src.Data);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TextBlock(string src)
            => new TextBlock(src);

        [MethodImpl(Inline)]
        public static implicit operator TextBlock(char src)
            => new TextBlock(src.ToString());

        [MethodImpl(Inline)]
        public static implicit operator string(TextBlock src)
            => src.Data ?? EmptyString;

        public static TextBlock Empty
        {
            [MethodImpl(Inline)]
            get => new TextBlock(EmptyString);
        }
    }
}