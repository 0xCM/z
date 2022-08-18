//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op]
        public static object box(ValueType src)
            => RuntimeHelpers.GetObjectValue(src);
    }
}