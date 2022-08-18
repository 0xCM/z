//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;
    using static ReflectionFlags;

    partial class ClrQuery
    {
        /// <summary>
        /// Queries the source <see cref='Type'/> for the <see cref='EventInfo'/> members determined by the <see cref='BF_World'/> flags
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static EventInfo[] Events(this Type src)
            => src.GetEvents(BF_World);
    }
}