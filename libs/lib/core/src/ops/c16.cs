//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Presents a parametric reference as a <see cref='char'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref char c16<T>(in T src)
            => ref @as<T,char>(src);

        /// <summary>
        /// Adds a char-measured offset to a parametric reference and presents the result as a <see cref='char'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="offset">The offset count, measured in characters</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op]
        public static ref char c16<T>(in T src, int offset)
            => ref add(@as<T,char>(src), offset);
    }
}