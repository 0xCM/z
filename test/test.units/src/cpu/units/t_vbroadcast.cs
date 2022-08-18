//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vbroadcast : t_inx<t_vbroadcast>
    {
        public void vbroadcast_check()
        {
            vbroadcast_check(w128);
            vbroadcast_check(w256);
        }

        void vbroadcast_check(W128 w)
        {
            vbroadcast_check(w,z8);
            vbroadcast_check(w,z8i);
            vbroadcast_check(w,z16);
            vbroadcast_check(w,z16i);
            vbroadcast_check(w,z32);
            vbroadcast_check(w,z32i);
            vbroadcast_check(w,z64i);
            vbroadcast_check(w,z64);
            vbroadcast_check(w,z32f);
            vbroadcast_check(w,z64f);
        }

        void vbroadcast_check(W256 w)
        {
            vbroadcast_check(w,z8);
            vbroadcast_check(w,z8i);
            vbroadcast_check(w,z16);
            vbroadcast_check(w,z16i);
            vbroadcast_check(w,z32);
            vbroadcast_check(w,z32i);
            vbroadcast_check(w,z64i);
            vbroadcast_check(w,z64);
            vbroadcast_check(w,z32f);
            vbroadcast_check(w,z64f);
        }

        protected void vbroadcast_check<T>(W128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckFactory(w, Calcs.vbroadcast(w,t,t), VBroadcastChecks.vbroadcast(w,t,t),t,t);

        protected void vbroadcast_check<T>(W256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckFactory(w, Calcs.vbroadcast(w,t,t), VBroadcastChecks.vbroadcast(w,t,t),t,t);
    }
}