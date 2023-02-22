//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Promotes a bit to a numeric value where all target bits are enabled if the state of the
        /// bit is on; otherwise all target bits are disabled
        /// </summary>
        /// <param name="src">The source bit</param>
        /// <typeparam name="T">The target numeric type</typeparam>
        [MethodImpl(Inline), Op]
        public static T promote<T>(bit src)
            where T : unmanaged
                => src ? Limits.maxval<T>() : default;
    }
}