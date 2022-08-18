//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    public class t_vsrlv : t_inx<t_vsrlv>
    {
        public void vsrlv_check()
        {
            vsrlv_check(w128);
            vsrlv_check(w256);
        }

        void vsrlv_check(N128 w)
        {
            vsrlv_check(w, z8);
            vsrlv_check(w, z16);
            vsrlv_check(w, z32);
            vsrlv_check(w, z32i);
            vsrlv_check(w, z64);
            vsrlv_check(w, z64i);
        }

        void vsrlv_check(N256 w)
        {
            vsrlv_check(w, z8);
            vsrlv_check(w, z16);
            vsrlv_check(w, z32);
            vsrlv_check(w, z32i);
            vsrlv_check(w, z64);
            vsrlv_check(w, z64i);
        }

        void vsrlv_check<T>(N128 w, T t = default)
            where T : unmanaged
        {
            var domain = Intervals.closed(zero<T>(), Numeric.force<uint,T>((uint)width<T>() - 1));

            Pair<Vector128<T>> @case(uint i)
            {
                var x = Random.CpuVector(w,t);
                var offsets = Random.CpuVector(w, domain);
                return (x,offsets);
            }

            CheckSVF.CheckCells(Calcs.vsrlv<T>(w),@case);
        }

        void vsrlv_check<T>(N256 w, T t = default)
            where T : unmanaged
        {
            var domain = Intervals.closed(default(T), Numeric.force<uint,T>((uint)width<T>() - 1));

            Pair<Vector256<T>> @case(uint i)
            {
                var x = Random.CpuVector(w,t);
                var offsets = Random.CpuVector(w, domain);
                return (x,offsets);
            }

            CheckSVF.CheckCells(Calcs.vsrlv<T>(w),@case);
        }
    }
}