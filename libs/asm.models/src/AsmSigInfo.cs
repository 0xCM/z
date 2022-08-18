//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Represents an expression that identifies an instruction
    /// </summary>
    public readonly struct AsmSigInfo : IComparable<AsmSigInfo>
    {
        [MethodImpl(Inline), Op]
        public static AsmSigInfo define(AsmMnemonic mnemonic, string content)
            => new AsmSigInfo(mnemonic, content);

        [Parser]
        public static Outcome parse(string src, out AsmSigInfo dst)
        {
            dst = default;

            if(text.empty(src))
                return true;

            var trimmed = src.Trim();
            var i = text.index(trimmed, Chars.Space);
            if(i == NotFound)
                dst = AsmSigInfo.define(new AsmMnemonic(src), src);
            else
            {
                var mnemonic = new AsmMnemonic(text.slice(trimmed,0,i));
                var operands = text.slice(trimmed, i + 1);
                dst = AsmSigInfo.define(mnemonic, trimmed);
            }
            return true;
        }

        public readonly AsmMnemonic Mnemonic;

        public readonly TextBlock Content;

        [MethodImpl(Inline)]
        public AsmSigInfo(AsmMnemonic mnemonic, TextBlock content)
        {
            Mnemonic = mnemonic;
            Content = content;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Content);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmSigInfo src)
            => Content.Equals(src.Content);

        public override bool Equals(object src)
            => src is AsmSigInfo x && Equals(x);

        public int CompareTo(AsmSigInfo src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator TextBlock(AsmSigInfo src)
            => new TextBlock(src.Content);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmSigInfo a, AsmSigInfo b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmSigInfo a, AsmSigInfo b)
            => !a.Equals(b);

        public static AsmSigInfo Empty
            => new AsmSigInfo(AsmMnemonic.Empty, TextBlock.Empty);
    }
}