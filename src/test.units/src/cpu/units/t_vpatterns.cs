//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class t_vpatterns : t_inx<t_vpatterns>
{
    public void vunits_check()
    {
        vunits_check(n128);
        vunits_check(n256);
    }

    void vunits_check(N128 w)
    {
        vunits_check<byte>(w);
        vunits_check<sbyte>(w);
        vunits_check<ushort>(w);
        vunits_check<short>(w);
        vunits_check<uint>(w);
        vunits_check<int>(w);
        vunits_check<ulong>(w);
        vunits_check<long>(w);
    }

    void vunits_check(N256 w)
    {
        vunits_check<byte>(w);
        vunits_check<sbyte>(w);
        vunits_check<ushort>(w);
        vunits_check<short>(w);
        vunits_check<uint>(w);
        vunits_check<int>(w);
        vunits_check<ulong>(w);
        vunits_check<long>(w);
    }

    public void vones_check()
    {
        vones_check(n128);
        vones_check(n256);
    }

    void vones_check(N128 w)
    {
        vones_check(w,z8);
        vones_check(w,z8i);
        vones_check(w,z16);
        vones_check(w,z16i);
        vones_check(w,z32);
        vones_check(w,z32i);
        vones_check(w,z64);
        vones_check(w,z64i);
    }

    void vones_check(N256 w)
    {
        vones_check(w,z8);
        vones_check(w,z8i);
        vones_check(w,z16);
        vones_check(w,z16i);
        vones_check(w,z32);
        vones_check(w,z32i);
        vones_check(w,z64);
        vones_check(w,z64i);
    }

    void vunits_check<T>(N128 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckPattern(Calcs.vunits(w,t), gcpu.vbroadcast(w, one<T>()));

    void vunits_check<T>(N256 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckPattern(Calcs.vunits(w,t), gcpu.vbroadcast(w, one<T>()));

    void vones_check<T>(N128 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckPattern(Calcs.vones(w,t), gcpu.vbroadcast(w, ones<T>()));

    void vones_check<T>(N256 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckPattern(Calcs.vones(w,t), gcpu.vbroadcast(w, ones<T>()));
}
