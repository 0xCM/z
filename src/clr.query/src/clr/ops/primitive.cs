//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        /// <summary>
        /// Determines whether a specified type is a system-defined primitive
        /// </summary>
        /// <param name="src">The type to test</param>
        [MethodImpl(Inline), Op]
        public static bool primitive(Type src)
            => PrimalBits.kind(src) != 0;
    }
}