//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline)]
        public static bool tag<A>(MemberInfo src, out A dst)
            where A : Attribute
        {
            dst = src.GetCustomAttribute<A>();
            return dst != null;
        }
    }
}