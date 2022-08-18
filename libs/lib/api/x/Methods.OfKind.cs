//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XApi
    {
        /// <summary>
        /// Queries the stream for mathods that are of a specified kind
        /// </summary>
        /// <param name="src">The source methods</param>
        /// <param name="kind">The kind to match</param>
        [Op]
        public static MethodInfo[] OfKind(this MethodInfo[] src, ApiClassKind kind)
            => from m in src where m.ApiClass() == kind select m;

        /// <summary>
        /// Selects methods from a stream that accept and/or return intrinsic vectors
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] OfKind(this MethodInfo[] src, Vec128Type vk, bool total = false)
            => src.Where(m => m.IsKind(vk,total));

        /// <summary>
        /// Selects methods from a stream that accept and/or return intrinsic vectors
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] OfKind(this MethodInfo[] src, Vec256Type vk, bool total = false)
            => src.Where(m => m.IsKind(vk,total));

        /// <summary>
        /// Selects methods from a stream that accept and/or return intrinsic vectors
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op, Closures(Closure)]
        public static MethodInfo[] OfKind<T>(this MethodInfo[] src, Vec128Kind<T> vk)
            where T : unmanaged
                => src.Where(m => m.IsKind(vk));

        /// <summary>
        /// Selects methods from a stream that accept and/or return intrinsic vectors
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op, Closures(Closure)]
        public static MethodInfo[] OfKind<T>(this MethodInfo[] src, Vec256Kind<T> vk)
            where T : unmanaged
                => src.Where(m => m.IsKind(vk));
    }
}