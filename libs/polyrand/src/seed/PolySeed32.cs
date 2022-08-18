//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public static class PolySeed32
    {
        public static uint Seed00 => (uint)PolySeed64.lookup(0);

        public static uint Seed01 => (uint)(PolySeed64.lookup(0) >> 16);

        public static uint Seed02 => (uint)PolySeed64.lookup(1);

        public static uint Seed03 =>  (uint)(PolySeed64.lookup(1) >> 16);

        public static uint Seed04 => (uint)PolySeed64.lookup(2);

        public static uint Seed05 =>  (uint)(PolySeed64.lookup(2) >> 16);

        public static uint Seed06 => (uint)PolySeed64.lookup(3);

        public static uint Seed07 =>  (uint)(PolySeed64.lookup(3) >> 16);
    }
}