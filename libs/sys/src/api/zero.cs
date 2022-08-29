//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T zero<T>()
            where T : unmanaged
                => default(T);
    }
}