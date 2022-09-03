//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    public class t_vsub : t_inx<t_vsub>
    {
        public void vsub_check()
        {
            vsub_check(w128);
            vsub_check(w256);
        }

        void vsub_check(W128 w)
        {
            vsub_check(w, z8);
            vsub_check(w, z8i);
            vsub_check(w, z16);
            vsub_check(w, z16i);
            vsub_check(w, z32);
            vsub_check(w, z32i);
            vsub_check(w, z64);
            vsub_check(w, z64i);
        }

        void vsub_check(W256 w)
        {
            vsub_check(w, z8);
            vsub_check(w, z8i);
            vsub_check(w, z16);
            vsub_check(w, z16i);
            vsub_check(w, z32);
            vsub_check(w, z32i);
            vsub_check(w, z64);
            vsub_check(w, z64i);
        }

        void vsub_check<T>(W128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vsub(w,t),w,t);

        void vsub_check<T>(W256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vsub(w,t), w,t);
    }
}