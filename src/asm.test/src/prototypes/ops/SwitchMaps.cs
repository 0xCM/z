//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        [ApiHost(@prototypes + "switches.map")]
        public struct SwitchMaps
        {
            [Op]
            public static uint sm01(uint src)
                => src switch {
                    34 => 3000,
                    51 => 201,
                    98 => 197,
                    101 => 313145,
                    264 => 264801,
                    888 => 911122,
                    911 => 4,
                    902 => 7,
                    3828 => 11,
                    13 => 54,
                    19 => 99,
                    _ => 0
                };
        }
    }
}