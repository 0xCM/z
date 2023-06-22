//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmMnemonic : IComparable<AsmMnemonic>
    {
        public static AsmMnemonic parse(string src, out int i)
        {
            i = text.index(src,Chars.Comma,Chars.Space);
            if(i>0)
            {
                return text.left(src,i);
            }
            else
                return src;
        }

        [Render(32)]
        public readonly asci32 Name;

        [MethodImpl(Inline)]
        public AsmMnemonic(string src)
        {
            Name = (src?.Trim() ?? EmptyString).ToLowerInvariant();
        }

        public string Content
        {
            [MethodImpl(Inline)]
            get => Name.Format();
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }


        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public string Format(MnemonicCase @case)
        {
            if(IsEmpty)
                return EmptyString;

            var content = Format();
            switch(@case)
            {
                case MnemonicCase.Captialized:
                    return string.Format("{0}{1}",Char.ToUpperInvariant(content[0]), content.ToLowerInvariant().Substring(1));
                case MnemonicCase.Lowercase:
                    return content.ToLowerInvariant();
                case MnemonicCase.Uppercase:
                    return content.ToUpperInvariant();
            }
            return content;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmMnemonic src)
            => Content.Equals(src.Content,StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object src)
            => src is AsmMnemonic x && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(AsmMnemonic src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator AsmMnemonic(string src)
            => new AsmMnemonic(src);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmMnemonic a, AsmMnemonic b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmMnemonic a, AsmMnemonic b)
            => !a.Equals(b);

        public static AsmMnemonic Empty
        {
            [MethodImpl(Inline)]
            get => new AsmMnemonic(EmptyString);
        }
    }
}