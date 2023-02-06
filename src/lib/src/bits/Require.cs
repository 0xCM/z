//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static void Require(this bool src)
        {
            if(!src)
                sys.@throw("Fail");
        }
                

    }
}