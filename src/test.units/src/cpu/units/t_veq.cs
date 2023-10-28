//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class t_veq : t_inx<t_veq>
{
    public void veq_check()
    {
        veq_basecase(w128);
        veq_basecase(w256);
        veq_check(w128);
        veq_check(w256);
    }

    void veq_check(W128 w)
    {
        veq_check(w, z8);
        veq_check(w, z8i);
        veq_check(w, z16);
        veq_check(w, z16i);
        veq_check(w, z32);
        veq_check(w, z32i);
        veq_check(w, z64);
        veq_check(w, z64i);
    }

    void veq_check(W256 w)
    {
        veq_check(w, z8);
        veq_check(w, z8i);
        veq_check(w, z16);
        veq_check(w, z16i);
        veq_check(w, z32);
        veq_check(w, z32i);
        veq_check(w, z64);
        veq_check(w, z64i);
    }

    void veq_basecase(W128 w)
    {
        veq_basecase(w, z8);
        veq_basecase(w, z8i);
        veq_basecase(w, z16);
        veq_basecase(w, z16i);
        veq_basecase(w, z32);
        veq_basecase(w, z32i);
        veq_basecase(w, z64);
        veq_basecase(w, z64i);
    }

    void veq_basecase(W256 w)
    {
        veq_basecase(w, z8);
        veq_basecase(w, z8i);
        veq_basecase(w, z16);
        veq_basecase(w, z16i);
        veq_basecase(w, z32);
        veq_basecase(w, z32i);
        veq_basecase(w, z64);
        veq_basecase(w, z64i);
    }

    void veq_basecase<T>(W128 w, T t = default)
        where T : unmanaged
    {
        var name = CaseName(SFxIdentity.identity(nameof(veq_basecase), w.VectorKind<T>()));
        var f = Calcs.veq<T>(w);
        var x = Random.SpanBlocks<T>(w, RepCount/cpu.vcount(w,t));
        var result = SpanBlocks.alloc<T>(w, x.BlockCount);
        result.Fill(ones<T>());
        CheckSVF.CheckExplicit(f,x,x,result, name);
    }

    void veq_basecase<T>(W256 w, T t = default)
        where T : unmanaged
    {

        var name = CaseName(SFxIdentity.identity(nameof(veq_basecase), w.VectorKind<T>()));
        var f = Calcs.veq<T>(w);
        var x = Random.SpanBlocks<T>(w, RepCount/cpu.vcount(w,t));
        var result = SpanBlocks.alloc<T>(w, x.BlockCount);
        result.Fill(ones<T>());
        CheckSVF.CheckExplicit(f,x,x,result,name);
    }

    void veq_check<T>(N128 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckBinaryOp(Calcs.veq<T>(w),w,t);

    void veq_check<T>(N256 w, T t = default)
        where T : unmanaged
            => CheckSVF.CheckBinaryOp(Calcs.veq<T>(w),w,t);
}
