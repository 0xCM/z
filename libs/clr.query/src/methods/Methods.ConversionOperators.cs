//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Selects the conversion operators from a stream
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] ConversionOperators(this MethodInfo[] src)
            => src.Where(m => m.IsConversionOperator());

        /// <summary>
        /// Removes any conversion operations from the stream
        /// </summary>
        /// <param name="src">The methods to examine</param>
        [Op]
        public static MethodInfo[] WithoutConversionOperators(this MethodInfo[] src)
            => src.Where(m => !m.IsConversionOperator());
    }
}