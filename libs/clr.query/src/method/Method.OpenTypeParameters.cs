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
        /// For a non-constructed generic method or a generic method definition, returns an array of the method's type parameters; otherwise, returns an empty array
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static Type[] OpenTypeParameters(this MethodInfo m, bool effective)
            => (m.ContainsGenericParameters ? m.GetGenericMethodDefinition().GetGenericArguments()
             : m.IsGenericMethodDefinition ? m.GetGenericArguments()
             : Array.Empty<Type>()).Select(arg => effective ? arg.TEffective() : arg).ToArray();
    }
}