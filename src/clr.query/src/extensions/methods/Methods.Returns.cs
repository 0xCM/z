//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the methods from a stream that return a particular type of value
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op, Closures(Closure)]
        public static MethodInfo[] Returns<T>(this MethodInfo[] src)
            => src.Where(x => x.ReturnType == typeof(T));

        /// <summary>
        /// Selects methods from a stream that return a particular type of value
        /// </summary>
        /// <param name="src">The methods to examine</param>
        /// <param name="rt">The method return type</param>
        [Op]
        public static MethodInfo[] Returns(this MethodInfo[] src, Type rt)
            => src.Where(x => x.ReturnType == rt);
    }
}