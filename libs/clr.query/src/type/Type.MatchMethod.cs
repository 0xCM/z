//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;
    using System.Reflection;

    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Searches a type for any method that matches the supplied signature
        /// </summary>
        /// <param name="declarer">The type to search</param>
        /// <param name="name">The name of the method</param>
        /// <param name="paramTypes">The method parameter types in ordinal position</param>
        [Op]
        public static Option<MethodInfo> MatchMethod(this Type declarer, string name, params Type[] paramTypes)
            => paramTypes.Length != 0
                ? declarer.GetMethod(name, bindingAttr: BF_All, binder: null, types: paramTypes, modifiers: null)
                : declarer.GetMethod(name, BF_All);
    }
}