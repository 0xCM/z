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
        [MethodImpl(Inline), Op]
        public static bool IsRefStruct(this Type src)
            => src.IsByRefLike;
    }
}