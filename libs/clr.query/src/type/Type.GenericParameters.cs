//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// If a type is non-generic, returns an empty list.
        /// If a type is open generic, returns a list of generic arguments
        /// If a type is closed generic, returns a list of the types that were supplied as arguments to construct the type
        /// </summary>
        /// <param name="m">The method to examine</param>
        [Op]
        public static Type[] GenericParameters(this Type src, bool effective = true)
        {
            var t = effective ? src.EffectiveType() : src;
            return !(t.IsGenericType && !t.IsGenericTypeDefinition) ? new Type[]{}
               : t.IsConstructedGenericType
               ? t.GetGenericArguments()
               : t.GetGenericTypeDefinition().GetGenericArguments();
        }

        [MethodImpl(Inline), Op]
        public static int GenericParamerCount(this Type t)
            => t.GenericParameters().Length;
    }
}