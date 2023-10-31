//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class t_vnonz : t_inx<t_vnonz>
{
    public void vnonz_check()
    {
        vnonz_check(w128);
        vnonz_check(w256);
    }

    void vnonz_check(N128 w)
    {
        vnonz_check(w,z8i);
        vnonz_check(w,z8);
        vnonz_check(w,z16i);
        vnonz_check(w,z16);
        vnonz_check(w,z32i);
        vnonz_check(w,z32);
        vnonz_check(w,z64i);
        vnonz_check(w,z64);
    }

    void vnonz_check(N256 w)
    {
        vnonz_check(w,z8i);
        vnonz_check(w,z8);
        vnonz_check(w,z16i);
        vnonz_check(w,z16);
        vnonz_check(w,z32i);
        vnonz_check(w,z32);
        vnonz_check(w,z64i);
        vnonz_check(w,z64);
    }

    protected void vnonz_check<T>(W128 w, T t = default)
        where T : unmanaged
    {
        var min = one<T>();
        var max = Limits.maxval(t);
        var domain = Intervals.closed(one<T>(), Limits.maxval<T>());
        var f = Calcs.vnonz(w,t);

        Claim.nea(gcpu.vnonz(gcpu.vzero(w,t)));

        for(var i=0; i<RepCount; i++)
            Claim.require(f.Invoke(Random.CpuVector(w, domain)));
    }

    protected void vnonz_check<T>(W256 w, T t = default)
        where T : unmanaged
    {
        var min = one<T>();
        var max = Limits.maxval(t);
        var domain = Intervals.closed(one<T>(), Limits.maxval<T>());
        var f = Calcs.vnonz(w,t);

        Claim.nea(gcpu.vnonz(gcpu.vzero<T>(w)));

        for(var i=0; i<RepCount; i++)
            Claim.require(f.Invoke(Random.CpuVector(w,domain)));
    }
}
