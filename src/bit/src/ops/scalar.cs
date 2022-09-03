//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
       /// <summary>
        /// Packs a section of bits into a scalar
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T scalar<T>(ReadOnlySpan<bit> src, int offset = 0, int? count = null)
            where T : unmanaged
        {
            var len = min((count == null ? (int)width<T>() : count.Value), src.Length - offset);
            return scalar<T>(slice(src,offset, len));;
        }

        /// <summary>
        /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T scalar<T>(ReadOnlySpan<bit> src)
            where T : unmanaged
        {
            var dst = default(T);
            if(src.Length == 0)
                return dst;

            return pack(src, ref dst);
        }
    }
}