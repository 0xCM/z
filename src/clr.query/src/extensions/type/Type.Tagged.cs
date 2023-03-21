//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class ClrQuery
    {
        public static bool Tagged(this Type src, string name)
            => src.GetCustomAttributes(true).Where(a => a.GetType().Name == name).Length != 0;
    }
}