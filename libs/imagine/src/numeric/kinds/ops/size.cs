//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NumericKinds
    {
        /// <summary>
        /// Determines the width of the represented kind in bytes
        /// </summary>
        /// <param name="k">The kind to examine</param>
        [MethodImpl(Inline), Op]
        public static byte size(NumericKind k)
            => (byte)(((ushort)k)/8);
    }
}