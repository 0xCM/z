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
        /// Determines whether a type is an unconstructed generic type, also called an open generic type
        /// </summary>
        /// <param name="src">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsOpenGeneric(this Type src, bool effective = true)
        {
            var t = effective ? src.EffectiveType() : src;
            return (t.IsGenericType || t.IsGenericTypeDefinition) && !t.IsConstructedGenericType;
        }
    }
}