//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Perm16L;
    using static Perm8L;

    [LiteralProvider]
    public readonly struct PermLits
    {
        public const Perm16L Perm16Identity =
            (Perm16L)(
              (ulong)X0 << 00 | (ulong)X1 << 04 | (ulong)X2 << 08 | (ulong)X3 << 12
            | (ulong)X4 << 16 | (ulong)X5 << 20 | (ulong)X6 << 24 | (ulong)X7 << 28
            | (ulong)X8 << 32 | (ulong)X9 << 36 | (ulong)XA << 40 | (ulong)XB << 44
            | (ulong)XC << 48 | (ulong)XD << 52 | (ulong)XE << 56 | (ulong)XF << 60);


        public const Perm8L Perm8Identity = (Perm8L)(
            (uint)A       | (uint)B << 3  | (uint)C << 6  | (uint)D << 9
          | (uint)E << 12 | (uint)F << 15 | (uint)G << 18 | (uint)H << 21
              );

        public const Perm8L Perm8Reversed = (Perm8L)(
            (uint)H       | (uint)G << 3  | (uint)F << 6  | (uint)E << 9
          | (uint)D << 12 | (uint)C << 15 | (uint)B << 18 | (uint)A << 21
            );
    }
}