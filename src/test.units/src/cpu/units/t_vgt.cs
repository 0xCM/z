//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class t_vgt : t_inx<t_vgt>
{
    public void vgt_check()
    {
        vgt_check(n128);
        vgt_check(n256);
    }

    void vgt_check(N128 w)
    {
        v_check<byte>(w);
        v_check<sbyte>(w);
        v_check<ushort>(w);
        v_check<short>(w);
        v_check<uint>(w);
        v_check<int>(w);
        v_check<ulong>(w);
        v_check<long>(w);
    }

    void vgt_check(N256 w)
    {
        v_check<byte>(w);
        v_check<sbyte>(w);
        v_check<ushort>(w);
        v_check<short>(w);
        v_check<uint>(w);
        v_check<int>(w);
        v_check<ulong>(w);
        v_check<long>(w);
    }

    void v_check<T>(N128 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckBinaryOp(Calcs.vgt<T>(w), w, t);

    void v_check<T>(N256 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckBinaryOp(Calcs.vgt<T>(w), w, t);
}
