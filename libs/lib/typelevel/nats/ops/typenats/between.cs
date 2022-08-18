//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class TypeNats
    {
        /// <summary>
        /// Constructs the canonical sequence representatives for the natural numbers within an inclusive range
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        public static IEnumerable<INatSeq> between(ulong min, ulong max)
        {
            for(var i = min; i<= max; i++)
                yield return reflect(i);
        }
   }
}