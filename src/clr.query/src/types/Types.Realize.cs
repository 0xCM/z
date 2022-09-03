//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the types from a stream that implement a specific interface
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The interface type</typeparam>
        [Op]
        public static Type[] Realize<T>(this Type[] src)
            where T : class
                => src.Where(t => t.Interfaces().Contains(typeof(T))).Array();

        [Op]
        public static Type[] Realize(this Type[] src, Type @interface)
            => src.Where(t => t.Interfaces().Contains(@interface)).Array();
    }
}