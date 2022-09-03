//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a parameter has a parametrically-identified attribute
        /// </summary>
        /// <param name="p">The parameter to examine</param>
        /// <typeparam name="A">The attribute type to check</typeparam>
        [MethodImpl(Inline)]
        public static bool Tagged<A>(this ParameterInfo p)
            where A : Attribute
                => System.Attribute.IsDefined(p, typeof(A));
    }
}