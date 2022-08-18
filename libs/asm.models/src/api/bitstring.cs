//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [Op]
        public static string bitstring(in AsmHexCode src)
            => ApiNative.bitstring(src);
    }
}