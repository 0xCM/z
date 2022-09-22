//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        /// <summary>
        /// Determines the <see cref='ApiClassKind'/> classifier of the source method, if any
        /// </summary>
        /// <param name="src">The method to study</param>
        [Op]
        public static ApiClass apiclass(MethodInfo src)
            =>  src.Tagged<OpKindAttribute>() ? src.Tag<OpKindAttribute>().Require().ApiClass : ApiClassKind.None;
    }
}