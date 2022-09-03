//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct)]
    public class NatSpanAttribute : Attribute
    {
        /// <summary>
        /// Determines whether a type is a natural span
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static bool test(Type t)
            => Attribute.IsDefined(t,typeof(NatSpanAttribute));

        public NatSpanAttribute()
        {

        }

    }
}