//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Interprets a readonly T-reference as a readonly uint64 reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long view64i<T>(in T src)
            => ref view<T,long>(src);

        /// <summary>
        /// Interprets a readonly T-reference as a readonly uint64 reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ulong view64u<T>(in T src)
            => ref view<T,ulong>(src);

       /// <summary>
        /// Interprets a readonly T-reference as a readonly float64 reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly double view64f<T>(in T src)
             => ref view<T,double>(src);
    }
}