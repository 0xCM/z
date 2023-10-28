//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class t_vconcat : t_inx<t_vconcat>
{
    public void vconcat_check()
    {
        var w = w128;
        vconcat_check(w, z8);
        vconcat_check(w, z8i);
        vconcat_check(w, z16);
        vconcat_check(w, z16i);
        vconcat_check(w, z32);
        vconcat_check(w, z32i);
        vconcat_check(w, z64);
        vconcat_check(w, z64i);
    }

    void vconcat_check<T>(W128 w, T t = default)
        where T : unmanaged
            => CheckAction(() => vconcat_checker(w,t), CaseName(Calcs.vconcat(w,t)));

    Action<W128,T> vconcat_checker<T>(W128 w, T t = default)
        where T : unmanaged
            => check<T>;

    void check<T>(W128 w, T t = default)
        where T : unmanaged
    {
        for(var i=0; i<RepCount; i++)
        {
            var x = Random.CpuVector<T>(w);
            var y = Random.CpuVector<T>(w);
            var z = Calcs.vconcat(w,t).Invoke(x,y);

            var xs = x.ToSpan();
            var ys = y.ToSpan();
            var expect = xs.Concat(ys).LoadVector(n256);
            Claim.veq(expect,z);
        }
    }
}
