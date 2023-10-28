//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static LogixEngine;
using static TypedLogicSpec;
using static sys;


using S = NumericLogixOps;
using L = AsciLetterLoSym;
using CS = Comparisons;

public abstract class t_logix<X> : UnitTest<X,CheckVectorBits,ICheckVectorBits>
    where X : t_logix<X>
{
    protected BitLogix bitlogix => BitLogix.Service;

    /// <summary>
    /// Creates a typed variable named 'a'
    /// </summary>
    /// <typeparam name="V">The variable's underlying type</typeparam>
    protected static VariableExpr<V> var_a<V>()
        where V : unmanaged
            => variable<V>(L.a);

    /// <summary>
    /// Creates a typed variable named 'b'
    /// </summary>
    /// <typeparam name="V">The variable's underlying type</typeparam>
    protected static VariableExpr<V> var_b<V>()
        where V : unmanaged
            => variable<V>(L.b);

    /// <summary>
    /// Creates a typed variable named 'c'
    /// </summary>
    /// <typeparam name="V">The variable's underlying type</typeparam>
    protected static VariableExpr<V> var_c<V>()
        where V : unmanaged
            => variable<V>(L.c);

    /// <summary>
    /// Creates a typed variable named 'x'
    /// </summary>
    /// <typeparam name="V">The variable's underlying type</typeparam>
    protected static VariableExpr<V> var_x<V>()
        where V : unmanaged
            => variable<V>(L.a);

    /// <summary>
    /// Creates a typed variable named 'y'
    /// </summary>
    /// <typeparam name="V">The variable's underlying type</typeparam>
    protected static VariableExpr<V> var_y<V>()
        where V : unmanaged
            => variable<V>(L.y);

    /// <summary>
    /// Creates a typed variable named 'z'
    /// </summary>
    /// <typeparam name="V">The variable's underlying type</typeparam>
    protected static VariableExpr<V> var_z<V>()
        where V : unmanaged
            => variable<V>(L.z);

    protected void scalar_eq_op_check<T>()
        where T : unmanaged
    {
        for(var i=0; i< RepCount; i++)
        {
            var x = Random.Next<T>();
            var y = gmath.inc(x);

            var y0 = gmath.eq(x,x);
            Claim.require(y0);

            var y1 = S.equals(x,x);
            Claim.eq(Limits.maxval<T>(), y1);

            var y2 = gmath.eq(x,y);
            Claim.nea(y2);

            var y3 = S.equals(x,y);
            Claim.eq(zero<T>(),y3);
        }
    }

    protected void cpu_lt_op_check<T>(N128 n)
        where T : unmanaged
    {
        var x = Random.CpuVector<T>(n);
        var y = Random.CpuVector<T>(n);
        var expect = gcpu.vzero<T>(n);
        var actual = gcpu.vzero<T>(n);
        for(var i=0; i< RepCount; i++)
        {
            expect = gcpu.vlt(x,y);
            actual = gcpu.vlt(x,y);
            Claim.require(gcpu.vsame(expect,actual));

            var a = gcpu.vbroadcast(n,Random.Next<T>());
            x = gcpu.vxor(x,a);
            y = gcpu.vxor(y,a);
        }
    }

    protected void cpu_lt_op_check<T>(N256 n)
        where T : unmanaged
    {
        var x = Random.CpuVector<T>(n);
        var y = Random.CpuVector<T>(n);
        var expect = gcpu.vzero<T>(n);
        var actual = gcpu.vzero<T>(n);
        for(var i=0; i< RepCount; i++)
        {
            expect = gcpu.vlt(x,y);
            actual = gcpu.vlt(x,y);
            Claim.require(gcpu.vsame(expect,actual));

            var a = gcpu.vbroadcast(n,Random.Next<T>());
            x = gcpu.vxor(x,a);
            y = gcpu.vxor(y,a);
        }
    }

    protected void cpu_gt_op_check<T>(N128 n)
        where T : unmanaged
    {
        var x = Random.CpuVector<T>(n);
        var y = Random.CpuVector<T>(n);
        var expect = gcpu.vzero<T>(n);
        var actual = gcpu.vzero<T>(n);
        for(var i=0; i< RepCount; i++)
        {
            expect = gcpu.vgt(x,y);
            actual = gcpu.vgt(x,y);
            Claim.require(gcpu.vsame(expect,actual));

            var a = gcpu.vbroadcast(n, Random.Next<T>());
            x = gcpu.vxor(x,a);
            y = gcpu.vxor(y,a);
        }
    }

    protected void cpu_gt_op_check<T>(N256 n)
        where T : unmanaged
    {
        var x = Random.CpuVector<T>(n);
        var y = Random.CpuVector<T>(n);
        var expect = gcpu.vzero<T>(n);
        var actual = gcpu.vzero<T>(n);
        for(var i=0; i<RepCount; i++)
        {
            expect = gcpu.vgt(x,y);
            actual = gcpu.vgt(x,y);
            Claim.require(gcpu.vsame(expect,actual));

            var a = gcpu.vbroadcast(n,Random.Next<T>());
            x = gcpu.vxor(x,a);
            y = gcpu.vxor(y,a);
        }

    }

    protected void scalar_lt_op_check<T>()
        where T : unmanaged
    {
        for(var i=0; i< RepCount; i++)
        {
            var x = Random.Next<T>();
            var y = Random.Next<T>();
            var expect = bits.promote<T>(gmath.lt(x,y));
            var actual = S.lt(x,y);
            Claim.eq(expect,actual);
        }
    }

    protected void scalar_lteq_op_check<T>()
        where T : unmanaged
    {
        for(var i=0; i< RepCount; i++)
        {
            var x = Random.Next<T>();
            var y = Random.Next<T>();
            var expect = bits.promote<T>(gmath.lteq(x,y));
            var actual = S.lteq(x,y);
            Claim.eq(expect,actual);
        }
    }

    protected void scalar_gt_op_check<T>()
        where T : unmanaged
    {
        for(var i=0; i< RepCount; i++)
        {
            var x = Random.Next<T>();
            var y = Random.Next<T>();
            var expect = bits.promote<T>(gmath.gt(x,y));
            var actual = S.gt(x,y);
            Claim.eq(expect,actual);
        }
    }

    protected void scalar_gteq_op_check<T>()
        where T : unmanaged
    {
        for(var i=0; i< RepCount; i++)
        {
            var x = Random.Next<T>();
            var y = Random.Next<T>();
            var expect = bits.promote<T>(gmath.gteq(x,y));
            var actual = S.gteq(x,y);
            Claim.eq(expect,actual);
        }
    }

    protected void scalar_lt_check<T>()
        where T : unmanaged
    {
        var va = var_a<T>();
        var vb = var_b<T>();
        var x = CS.lt(va,vb);
        for(var i=0; i<RepCount; i++)
        {
            var a = va.Set(Random);
            var b = vb.Set(Random);
            var result = eval(x).Value;
            var expect = LogixPredicateEval.eval(ApiComparisonClass.Lt,a,b);
            Claim.eq(expect,result);
        }
    }

    protected void scalar_lteq_check<T>()
        where T : unmanaged
    {
        var va = var_a<T>();
        var vb = var_b<T>();
        var x = CS.lteq(va,vb);
        for(var i=0; i<RepCount; i++)
        {
            var a = va.Set(Random);
            var b = vb.Set(Random);
            var result = eval(x).Value;
            var expect = LogixPredicateEval.eval(ApiComparisonClass.LtEq,a,b);
            Claim.eq(expect,result);
        }
    }

    protected void scalar_gt_check<T>()
        where T : unmanaged
    {
        var va = var_a<T>();
        var vb = var_b<T>();
        var x = CS.gt(va,vb);
        for(var i=0; i<RepCount; i++)
        {
            var a = va.Set(Random);
            var b = vb.Set(Random);
            var expect = LogixPredicateEval.eval(ApiComparisonClass.Gt,a,b);
            var actual = eval(x).Value;
            if(gmath.neq(actual,expect))
                Notify($"{a} > {b}?");
            Claim.eq(expect,actual);
        }
    }

    protected void scalar_gteq_check<T>()
        where T : unmanaged
    {
        var va = var_a<T>();
        var vb = var_b<T>();
        var x = CS.gteq(va,vb);
        for(var i=0; i<RepCount; i++)
        {
            var a = va.Set(Random);
            var b = vb.Set(Random);
            var expect = LogixPredicateEval.eval(ApiComparisonClass.GtEq,a,b);
            var actual = eval(x).Value;
            Claim.eq(expect,actual);
        }
    }
}
