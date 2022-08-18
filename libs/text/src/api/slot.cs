//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Produces the literal '{<paramref name='index'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index)
            => string.Concat("{", index, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>,<paramref name='pad'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index, short pad)
            => string.Concat("{", index, ",", pad, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>,<paramref name='pad'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(uint index, short pad)
            => string.Concat("{", index, ",", pad, "}");
    }
}