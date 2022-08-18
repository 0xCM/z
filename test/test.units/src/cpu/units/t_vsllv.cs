//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;
    using System.Runtime.CompilerServices;

    using static core;
    using static Numeric;

    public class t_vsllv : t_inx<t_vsllv>
    {
        public override bool Enabled
            => true;

        public void vsllv_check()
        {
            vsllv_check(n128);
            vsllv_check(n256);
        }

        void vsllv_check(W128 w)
        {
            vsllv_check(w, z8);
            vsllv_check(w, z16);
            vsllv_check(w, z32);
            vsllv_check(w, z32i);
            vsllv_check(w, z64);
            vsllv_check(w, z64i);
        }

        void vsllv_check(W256 w)
        {
            vsllv_check(w, z8);
            vsllv_check(w, z16);
            vsllv_check(w, z32);
            vsllv_check(w, z32i);
            vsllv_check(w, z64);
            vsllv_check(w, z64i);
        }

        void vsllv_check<T>(W128 w, T t = default)
            where T : unmanaged
        {
            var domain = Intervals.closed(zero<T>(), force<uint,T>(width<T>() - 1));

            Pair<Vector128<T>> @case(uint i)
            {
                var x = Random.CpuVector(w,t);
                var offsets = Random.CpuVector(w, domain);
                return (x,offsets);
            }

            CheckSVF.CheckCells(Calcs.vsllv(w, t), @case);
        }

        void vsllv_check<T>(W256 w, T t = default)
            where T : unmanaged
        {
            var domain = Intervals.closed(zero<T>(), force<uint,T>(width<T>() - 1));

            Pair<Vector256<T>> @case(uint i)
            {
                var x = Random.CpuVector(w,t);
                var offsets = Random.CpuVector(w, domain);
                return (x,offsets);
            }

            CheckSVF.CheckCells(Calcs.vsllv(w, t), @case);
        }
    }
}