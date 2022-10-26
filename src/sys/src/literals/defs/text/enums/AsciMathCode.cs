//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = AsciMathSym;

    [SymSource(chars)]
    public enum AsciMathCode : byte
    {
        /// <summary>
        /// The '!' character code 33
        /// </summary>
        Not = (byte)S.Not,

        /// <summary>
        /// The '%' character code 37
        /// </summary>
        Mod = (byte)S.Mod,

        /// <summary>
        /// The '*' character code 42
        /// </summary>
        Mul = (byte)S.Mul,

        /// <summary>
        /// The '+' character code 43
        /// </summary>
        Add = (byte)S.Add,

        /// <summary>
        /// The '-' character code 45
        /// </summary>
        Sub = (byte)S.Sub,

        /// <summary>
        /// The '/' character code 47
        /// </summary>
        Div = (byte)S.Div,

        /// <summary>
        /// The '<' character code 60
        /// </summary>
        LT = (byte)S.LT,

        /// <summary>
        /// The '=' character code 61
        /// </summary>
        Eq = (byte)S.Eq,

        /// <summary>
        /// The '>' character code 62
        /// </summary>
        GT = (byte)S.GT,

        /// <summary>
        /// The '^' character code 94
        /// </summary>
        Exp = (byte)S.Exp,

        /// <summary>
        /// The '~' character code 126
        /// </summary>
        Complement = (byte)S.Complement,
    }
}