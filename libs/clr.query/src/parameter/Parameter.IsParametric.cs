//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a parameter's type is of some generic kind
        /// </summary>
        /// <param name="src">The source parameter</param>
        [MethodImpl(Inline), Op]
        public static bool IsParametric(this ParameterInfo src)
            => src.ParameterType.IsGenericParameter
            || src.ParameterType.IsGenericMethodParameter
            || src.ParameterType.IsGenericTypeParameter;
    }
}