//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = Perm8Sym;

    /// <summary>
    /// Defines canonical literals for representing terms of permutations on 8 symbols
    /// </summary>
    public enum Perm8L : uint
    {
        /// <summary>
        /// Identifies the first permutation symbol
        /// </summary>
        A = S.A,

        /// <summary>
        /// Identifies the second permutation symbol
        /// </summary>
        B = S.B,

        /// <summary>
        /// Identifies the third permutation symbol
        /// </summary>
        C = S.C,

        /// <summary>
        /// Identifies the fourth permutation symbol
        /// </summary>
        D = S.D,

        /// <summary>
        /// Identifies the fifth permutation symbol
        /// </summary>
        E = S.E,

        /// <summary>
        /// Identifies the sixth permutation symbol
        /// </summary>
        F = S.F,

        /// <summary>
        /// Identifies the seventh permutation symbol
        /// </summary>
        G = S.G,

        /// <summary>
        /// Identifies the eighth permutation symbol
        /// </summary>
        H = S.H,
    }
}