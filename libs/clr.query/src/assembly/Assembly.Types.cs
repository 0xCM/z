//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static Type[] Types(this Assembly a)
            => a.GetTypes();
    }
}