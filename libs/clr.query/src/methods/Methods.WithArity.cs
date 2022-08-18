//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects functions from a stream
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] WithArity(this MethodInfo[] src, int arity)
            => src.Where(m => m.HasArityValue(arity));

        /// <summary>
        ///  Selects methods from a stream that have a specified parameter count
        /// </summary>
        /// <param name="src">The methods to examine</param>
        /// <param name="t">The parameter type to match</param>
        [Op]
        public static MethodInfo[] WithParameterCount(this MethodInfo[] src, int count)
            => from m in src
                where m.GetParameters().Length == count
                select m;
    }
}