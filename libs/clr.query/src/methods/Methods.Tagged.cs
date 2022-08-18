//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects the methods that are adorned with parametrically-identified attribute
        /// </summary>
        /// <param name="src">The methods to examine</param>
        /// <typeparam name="A">The attribute type</typeparam>
        public static MethodInfo[] Tagged<A>(this MethodInfo[] src)
            where A : Attribute
                => src.Where(m => m.Tagged<A>());

        /// <summary>
        /// Selects the methods that are adorned with parametrically-identified attribute
        /// </summary>
        /// <param name="src">The methods to examine</param>
        /// <typeparam name="A">The attribute type</typeparam>
        public static int Tagged<A>(this MethodInfo[] src, out TaggedMethod<A>[] dst)
            where A : Attribute
        {
            var count = src.Length;
            var methods = new List<TaggedMethod<A>>();
            var found = 0;
            for(var i=0; i<count; i++)
            {
                var method = src[i];
                if(method.Tag<A>(out var a))
                    methods.Add((method,a));
            }
            dst = methods.ToArray();
            return methods.Count;
        }
    }
}