//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Perm4Sym;

    /// <summary>
    /// Defines literals that define symbol arrangements that may or may not be permutations
    /// </summary>
    [SymSource(arrangements)]
    public enum Arrange4L : byte
    {
        ABCD = A | (B << 2) | (C << 4) | (D << 6),

        DCBA = D | (C << 2) | (B << 4) | (A << 6),

        AAAA = A | (A << 2) | (A << 4) | (A << 6),

        BBBB = B | (B << 2) | (B << 4) | (B << 6),

        CCCC = C | (C << 2) | (C << 4) | (C << 6),

        DDDD = D | (D << 2) | (D << 4) | (D << 6),

        AABB = A | (A<< 2) | (B << 4) | (B << 6),

        BBAA = B | (B<< 2) | (A << 4) | (A << 6),
   }
}