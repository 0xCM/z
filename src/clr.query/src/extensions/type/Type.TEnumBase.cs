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
        /// If source type is an enum, returns the integral base type; otherwise returns the empty type
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static Type TEnumBase(this Type src)
            => src.IsEnum ? src.GetEnumUnderlyingType() : typeof(void);
    }
}