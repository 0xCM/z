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
        /// If a method is non-generic, returns an empty list.
        /// If a method is open generic, returns a list describing the open parameters
        /// If a method is closed generic, returns a list describing the closed parameters
        /// </summary>
        /// <param name="m">The method to examine</param>
        /// <param name="effective">Whether to yield effective types or types as reported by the framework reflection api</param>
        [Op]
        public static Type[] GenericParameters(this MethodInfo m, bool effective)
        {
            var dst = new Type[]{};
            if((!m.IsGenericMethod && !m.IsGenericMethodDefinition))
                return dst;
            else return
                (m.IsConstructedGenericMethod
                ? m.GetGenericArguments()
                : m.GetGenericMethodDefinition().GetGenericArguments()).Select(arg => effective ? arg.EffectiveType() : arg).ToArray();
        }

        /// <summary>
        /// Returns the generic parameters specified by a generic method definition or, if constructed,
        /// the parameters specified by the definition on which the construction was predicated. If nongeneric,
        /// returns an empty result
        /// </summary>
        /// <param name="src">The method to examine</param>
        [Op]
        public static Type[] GenericParameters(this MethodInfo src)
            => src.IsConstructedGenericMethod ? src.GetGenericMethodDefinition().GetGenericArguments()
             : src.IsGenericMethodDefinition ? src.GetGenericArguments()
             : Array.Empty<Type>();

    }
}