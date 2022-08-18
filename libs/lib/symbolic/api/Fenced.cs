//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class Fenced
    {
        public static CharFence Embraced => (Chars.LBrace, Chars.RBrace);

        public static CharFence Bracketed => (Chars.LBracket, Chars.RBracket);

        public static CharFence Angled => (Chars.Lt, Chars.Gt);

        public static CharFence Dirac => ((char)MathSym.LeftBra, (char)MathSym.RightKet);

        public static CharFence Paren => (Chars.LParen, Chars.RParen);

        public static CharFence SQuote => (Chars.SQuote, Chars.SQuote);

        [MethodImpl(Inline)]
        public static Fence<T> define<T>(T left, T right)
            => (left,right);

    }
}