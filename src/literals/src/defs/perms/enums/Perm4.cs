//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies 4-element permutations
    /// </summary>
    [SymSource(perms, NBK.Base2)]
    public enum Perm4L : byte
    {
        /// <summary>
        /// Identifies the first of four permutation symbols
        /// </summary>
        [Symbol("A")]
        A = Perm4Sym.A,

        /// <summary>
        /// Identifies the second of four permutation symbols
        /// </summary>
        [Symbol("B")]
        B = Perm4Sym.B,

        /// <summary>
        /// Identifies the third of four permutation symbols
        /// </summary>
        [Symbol("C")]
        C = Perm4Sym.C,

        /// <summary>
        /// Identifies the fourth of four permutation symbols
        /// </summary>
        [Symbol("D")]
        D = Perm4Sym.D,

        /// <summary>
        /// ABCD -> ABCD
        /// </summary>
        [Symbol("ABCD -> ABCD")]
        ABCD = A | B << 2 | C << 4 | D << 6,

        /// <summary>
        /// ABCD -> ABDC
        /// </summary>
        [Symbol("ABCD -> ABDC")]
        ABDC = A | (B << 2) | (D << 4) | (C << 6),

        /// <summary>
        /// ABCD -> ACBD
        /// </summary>
        [Symbol("ABCD -> ACBD")]
        ACBD = A | (C << 2) | (B << 4) | (D << 6),

        /// <summary>
        /// ABCD -> ACDB
        /// </summary>
        [Symbol("ABCD -> ACDB")]
        ACDB = A | (C << 2) | (D << 4) | (B << 6),

        /// <summary>
        /// ABCD -> ADBC
        /// </summary>
        [Symbol("ABCD -> ADBC")]
        ADBC = A | (D << 2) | (B << 4) | (C << 6),

        /// <summary>
        /// ABCD -> ADCB
        /// </summary>
        [Symbol("ABCD -> ADCB")]
        ADCB = A | (D << 2) | (C << 4) | (B << 6),

        /// <summary>
        /// ABCD -> BACD
        /// </summary>
        [Symbol("ABCD -> BACD")]
        BACD = B | (A << 2) | (C << 4) | (D << 6),

        /// <summary>
        /// ABCD -> BADC
        /// </summary>
        [Symbol("ABCD -> BADC")]
        BADC = B | (A << 2) | (D << 4) | (C << 6),

        /// <summary>
        /// ABCD -> BCAD
        /// </summary>
        [Symbol("ABCD -> BCAD")]
        BCAD = B | C << 2 | A << 4 | D << 6,

        /// <summary>
        /// ABCD -> BCDA
        /// </summary>
        [Symbol("ABCD -> BCDA")]
        BCDA = B | (C << 2) | (D << 4) | (A << 6),

        /// <summary>
        /// ABCD -> BDAC
        /// </summary>
        [Symbol("ABCD -> BDAC")]
        BDAC = B | (D << 2) | (A << 4) | (C << 6),

        /// <summary>
        /// ABCD -> BDCA
        /// </summary>
        [Symbol("ABCD -> BDCA")]
        BDCA = B | (D << 2) | (C << 4) | (A << 6),

        /// <summary>
        /// ABCD -> CABD
        /// </summary>
        [Symbol("ABCD -> CABD")]
        CABD = C | (A << 2) | (B << 4) | (D << 6),

        /// <summary>
        /// ABCD -> CADB
        /// </summary>
        [Symbol("ABCD -> CADB")]
        CADB = C | (A << 2) | (D << 4) | (B << 6),

        /// <summary>
        /// ABCD -> CBAD
        /// </summary>
        [Symbol("ABCD -> CBAD")]
        CBAD = C | (B << 2) | (A << 4) | (D << 6),

        /// <summary>
        /// ABCD -> CBDA
        /// </summary>
        [Symbol("ABCD -> CBDA")]
        CBDA = C | (B << 2) | (D << 4) | (A << 6),

        /// <summary>
        /// ABCD -> CDAB
        /// </summary>
        [Symbol("ABCD -> CDAB")]
        CDAB = C | (D << 2) | (A << 4) | (B << 6),

        /// <summary>
        /// ABCD -> CDBA
        /// </summary>
        [Symbol("ABCD -> CDBA")]
        CDBA = C | (D << 2) | (B << 4) | (A << 6),

        /// <summary>
        /// ABCD -> DABC
        /// </summary>
        [Symbol("ABCD -> DABC")]
        DABC = D | (A << 2) | (B << 4) | (C << 6),

        /// <summary>
        /// ABCD -> DACB
        /// </summary>
        [Symbol("ABCD -> DACB")]
        DACB = D | (A << 2) | (C << 4) | (B << 6),

        /// <summary>
        /// ABCD -> DBAC
        /// </summary>
        [Symbol("ABCD -> DBAC")]
        DBAC = D | (B << 2) | (A << 4) | (C << 6),

        /// <summary>
        /// ABCD -> DBCA
        /// </summary>
        [Symbol("ABCD -> DBCA")]
        DBCA = D | (B << 2) | (C << 4) | (A << 6),

        /// <summary>
        /// ABCD -> DCAB
        /// </summary>
        [Symbol("ABCD -> DCAB")]
        DCAB = D | (C << 2) | (A << 4) | (B << 6),

        /// <summary>
        /// ABCD -> DCBA
        /// </summary>
        [Symbol("ABCD -> DCBA")]
        DCBA = D | C << 2 | B << 4 | A << 6,
    }
}