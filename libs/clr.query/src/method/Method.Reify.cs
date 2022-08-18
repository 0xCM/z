//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// Reifies a method if it is open generic; otherwise, returns the original method
        /// </summary>
        /// <param name="m">The source method</param>
        /// <param name="args">The types over which to close the method</param>
        [Op]
        public static MethodInfo Reify(this MethodInfo m, params Type[] args)
        {
            if(m.IsGenericMethodDefinition)
                return m.MakeGenericMethod(args);
            else if(m.IsConstructedGenericMethod)
                return m;
            else if(m.IsGenericMethod)
                return m.GetGenericMethodDefinition().MakeGenericMethod(args);
            else
                return m;
        }

        /// <summary>
        /// Reifies a 1-parameter generic method with a parametric type argument
        /// </summary>
        /// <param name="src">The source method</param>
        /// <param name="args">The type arguments</param>
        [MethodImpl(Inline)]
        public static MethodInfo Reify<T>(this MethodInfo src)
            => src.Reify(typeof(T));

        /// <summary>
        /// Reifies a 2-parameter generic method with a parametric type argument
        /// </summary>
        /// <param name="src">The source method</param>
        /// <param name="args">The type arguments</param>
        [MethodImpl(Inline)]
        public static MethodInfo Reify<T1,T2>(this MethodInfo src)
            => src.Reify(typeof(T1), typeof(T2));

        /// <summary>
        /// Reifies generic source methods with supplied type arguments
        /// </summary>
        /// <param name="src">The source method</param>
        /// <param name="args">The type arguments</param>
        public static IEnumerable<MethodInfo> Reify(this IEnumerable<MethodInfo> src, params Type[] args)
            => src.Select(m => m.Reify(args));
    }
}