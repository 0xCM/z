//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a type is unmanaged
        /// </summary>
        /// <param name="t">The type to test</param>
        /// <remarks>Idea from https://stackoverflow.com/questions/53968920/how-do-i-check-if-a-type-fits-the-unmanaged-constraint-in-c</remarks>
        [Op]
        public static bool IsUnManaged(this Type t)
            => Option.Try(() => typeof(Unmanaged<>).MakeGenericType(t)).MapValueOrElse(x => true, () => false);

        class Unmanaged<T> where T : unmanaged { }
    }
}