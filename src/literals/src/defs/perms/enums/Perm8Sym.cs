//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(perms, NBK.Base2),Flags]
    public enum Perm8Sym : byte
    {
        /// <summary>
        /// Identifies the first permutation symbol
        /// </summary>
        [Symbol("000")]
        A = 0b000,

        /// <summary>
        /// Identifies the second permutation symbol
        /// </summary>
        [Symbol("001")]
        B = 0b001,

        /// <summary>
        /// Identifies the third permutation symbol
        /// </summary>
        [Symbol("010")]
        C = 0b010,

        /// <summary>
        /// Identifies the fourth permutation symbol
        /// </summary>
        [Symbol("011")]
        D = 0b011,

        /// <summary>
        /// Identifies the fifth permutation symbol
        /// </summary>
        [Symbol("100")]
        E = 0b100,

        /// <summary>
        /// Identifies the sixth permutation symbol
        /// </summary>
        [Symbol("101")]
        F = 0b101,

        /// <summary>
        /// Identifies the seventh permutation symbol
        /// </summary>
        [Symbol("110")]
        G = 0b110,

        /// <summary>
        /// Identifies the eighth permutation symbol
        /// </summary>
        [Symbol("111")]
        H = 0b111,
    }
}