//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents an operand in the context of an instruction signature
    /// </summary>
    public readonly record struct AsmSigOpExpr
    {
        readonly string Content;

        [MethodImpl(Inline)]
        public AsmSigOpExpr(string data)
        {
            Content = data.Trim();
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Text;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.length(Text) == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.length(Text) != 0;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Text);
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public bool Equals(AsmSigOpExpr src)
            => Text.Equals(src.Text);

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOpExpr(string src)
            => new (src);

        public static AsmSigOpExpr Empty
        {
            [MethodImpl(Inline)]
            get => new (EmptyString);
        }
    }
}