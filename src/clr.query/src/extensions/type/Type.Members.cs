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
        [MethodImpl(Inline), Op]
        public static MemberInfo[] Members(this Type src)
            => src.GetMembers(BF_World);

        [Op]
        public static MemberInfo[] Members(this Type src, string name)
            => src.Members().Where(x => x.Name == name);
    }
}