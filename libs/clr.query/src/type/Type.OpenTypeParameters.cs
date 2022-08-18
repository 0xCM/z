//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class ClrQuery
    {
        /// <summary>
        /// For a non-constructed generic type or a generic type definition, returns an
        /// array of defined type parameters; otherwise, returns an empty array
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static Type[] OpenTypeParameters(this Type t)
        {
            var effective = t.TEffective();
            return effective.ContainsGenericParameters
                    ? effective.GetGenericTypeDefinition().GetGenericArguments()
                    : effective.IsGenericTypeDefinition
                    ? effective.GetGenericArguments()
             : new Type[]{};
        }

        /// <summary>
        /// Returns the number of open generic paramters defined by the source type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static int OpenTypeParameterCount(this Type t)
            => t.OpenTypeParameters().Length;
    }
}