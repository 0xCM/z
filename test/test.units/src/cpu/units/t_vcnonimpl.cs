//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vcnonimpl : t_inx<t_vcnonimpl>
    {
        public void vcnonimpl_check()
        {
            vcnonimpl_check(w128);
            vcnonimpl_check(w128);
        }

        void vcnonimpl_check(W128 w)
        {
            vcnonimpl_check(w, z8);
            vcnonimpl_check(w, z8i);
            vcnonimpl_check(w, z16);
            vcnonimpl_check(w, z16i);
            vcnonimpl_check(w, z32);
            vcnonimpl_check(w, z32i);
            vcnonimpl_check(w, z64);
            vcnonimpl_check(w, z64i);

        }

        void vcnonimpl_check(W256 w)
        {
            vcnonimpl_check(w, z8);
            vcnonimpl_check(w, z8i);
            vcnonimpl_check(w, z16);
            vcnonimpl_check(w, z16i);
            vcnonimpl_check(w, z32);
            vcnonimpl_check(w, z32i);
            vcnonimpl_check(w, z64);
            vcnonimpl_check(w, z64i);
        }

        void vcnonimpl_check<T>(W128 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vcnonimpl<T>(w), w, t);

        void vcnonimpl_check<T>(W256 w, T t = default)
            where T : unmanaged
                => CheckSVF.CheckBinaryOp(Calcs.vcnonimpl<T>(w), w, t);
     }
}
