//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [Op]
        public static Assembly[] refs(Assembly src)
            => refnames(src).Select(Assembly.Load);

    }
}