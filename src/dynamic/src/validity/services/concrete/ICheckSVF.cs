//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

using K = OperatorClasses;

public interface ICheckSVF : ITestService, ICheckVectors, ITestRandom, ICheckAction
{
    ICheckSVF<T> Typed<T>()
        where T : unmanaged
            => new CheckSVF<T>(Context);

    void CheckUnaryOp<F,T>(F f, W128 w, T t = default)
        where T : unmanaged
        where F : IUnaryOp128D<T>
            => Typed<T>().CheckSVF(f, K.unary(), w);

    void CheckUnaryOp<F,T>(F f, W256 w, T t = default)
        where T : unmanaged
        where F : IUnaryOp256D<T>
            => Typed<T>().CheckSVF(f, K.unary(), w);

    void CheckShiftOp<F,T>(F f, W128 w, T t = default)
        where T : unmanaged
        where F : IShiftOp128D<T>
            => Typed<T>().CheckSVF(f, K.shift(), w);

    void CheckShiftOp<F,T>(F f, W256 w, T t = default)
        where T : unmanaged
        where F : IShiftOp256D<T>
            => Typed<T>().CheckSVF(f, K.shift(), w);

    void CheckBinaryOp<F,T>(F f, W128 w, T t = default)
        where T : unmanaged
        where F : IBinaryOp128D<T>
            => Typed<T>().CheckSVF(f, K.binary(), w);

    void CheckBinaryOp<F,T>(F f, W256 w, T t = default)
        where T : unmanaged
        where F : IBinaryOp256D<T>
            => Typed<T>().CheckSVF(f, K.binary(), w);

    void CheckTernaryOp<F,T>(F f, W128 w, T t = default)
        where T : unmanaged
        where F : ITernaryOp128D<T>
            => Typed<T>().CheckSVF(f, K.ternary(), w);

    void CheckTernaryOp<F,T>(F f, W256 w, T t = default)
        where T : unmanaged
        where F : ITernaryOp256D<T>
            => Typed<T>().CheckSVF(f, K.ternary(), w);

    void CheckCells<F,T>(F f, Func<uint,Pair<Vector128<T>>> src)
        where T : unmanaged
        where F : IBinaryOp128D<T>
    {
        var cells = vcpu.vcount<T>(n128);
        var succeeded = true;
        var casename = SFxIdentity.name(f);
        var count = Time.counter();

        count.Start();
        try
        {
            for(var i=0u; i<RepCount; i++)
            {
                (var x, var y) = src(i);
                var z = f.Invoke(x,y);
                for(byte j=0; j<cells; j++)
                    eq(f.Invoke(vcell(x,j),vcell(y,j)), vcell(z,j));
            }
        }
        catch(Exception e)
        {
            term.errlabel(e, casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename,succeeded,count);
        }
    }

    void CheckCells<F,T>(F f, Func<uint,Pair<Vector256<T>>> src)
        where T : unmanaged
        where F : IBinaryOp256D<T>
    {
        var cells = vcpu.vcount<T>(n256);
        var succeeded = true;
        var casename = SFxIdentity.name(f);
        var count = Time.counter();

        count.Start();
        try
        {
            for(var i=0u; i < RepCount; i++)
            {
                (var x, var y) = src(i);
                var z = f.Invoke(x,y);
                for(byte j=0; j< cells; j++)
                    eq(f.Invoke(vcell(x,j),vcell(y,j)), vcell(z,j));
            }
        }
        catch(Exception e)
        {
            term.errlabel(e, casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename,succeeded,count);
        }
    }

    void CheckExplicit<F,T>(F f, SpanBlock128<T> left, SpanBlock128<T> right, SpanBlock128<T> dst, string name = null)
        where T : unmanaged
        where F : IBinaryOp128<T>
    {
        var casename = name ?? SFxIdentity.name(f);
        var w = n128;
        var t = default(T);
        var cells = vcpu.vcount(w,t);
        var succeeded = true;
        var blocks = left.BlockCount;
        var count = Time.counter();

        count.Start();
        try
        {
            for(var block=0; block<blocks; block++)
            {
                var x = left.LoadVector(block);
                var y = right.LoadVector(block);
                var actual = f.Invoke(x,y);
                var expect = dst.LoadVector(block);
                eq(actual, expect);
            }
        }
        catch(Exception e)
        {
            term.errlabel(e, casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename, succeeded,count);
        }
    }

    void CheckExplicit<F,T>(F f, SpanBlock256<T> left, SpanBlock256<T> right, SpanBlock256<T> dst, string name = null)
        where T : unmanaged
        where F : IBinaryOp256<T>
    {
        var casename = name ?? SFxIdentity.name(f);
        var w = n256;
        var t = default(T);
        var cells = vcpu.vcount(w,t);
        var succeeded = true;
        var blocks = left.BlockCount;
        var count = Time.counter();

        count.Start();
        try
        {
            for(var block=0; block<blocks; block++)
            {
                var x = left.LoadVector(block);
                var y = right.LoadVector(block);
                var actual = f.Invoke(x,y);
                var expect = dst.LoadVector(block);
                eq(actual, expect);
            }
        }
        catch(Exception e)
        {
            term.errlabel(e,casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename,succeeded,count);
        }
    }

    /// <summary>
    /// Verifies that a vectorized pattern source produces the expected pattern
    /// </summary>
    /// <param name="f">The pattern source</param>
    /// <param name="expect">The expected pattern</param>
    /// <typeparam name="F">The pattern source type</typeparam>
    /// <typeparam name="T">The component type</typeparam>
    void CheckPattern<F,T>(F f, Vector128<T> expect)
        where T : unmanaged
        where F : IEmitter128<T>
    {
        var succeeded = true;
        var casename = SFxIdentity.name(f);
        var count = Time.counter();

        count.Start();

        try
        {
            eq(expect,f.Invoke());
        }
        catch(Exception e)
        {
            term.errlabel(e,casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename,succeeded,count);
        }
    }

    /// <summary>
    /// Verifies that a vectorized pattern source produces the expected pattern
    /// </summary>
    /// <param name="f">The pattern source</param>
    /// <param name="expect">The expected pattern</param>
    /// <typeparam name="F">The pattern source type</typeparam>
    /// <typeparam name="T">The component type</typeparam>
    void CheckPattern<F,T>(F f, Vector256<T> expect)
        where T : unmanaged
        where F : IEmitter256<T>
    {
        var succeeded = true;
        var casename = SFxIdentity.name(f);
        var count = Time.counter();

        count.Start();

        try
        {
            eq(expect,f.Invoke());
        }
        catch(Exception e)
        {
            term.errlabel(e,casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename,succeeded,count);
        }
    }

    /// <summary>
    /// Verifies the correct function of a vectorized factory operator
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <param name="f">The factory operator to verify</param>
    /// <param name="check">The adjudication operator</param>
    /// <param name="s">A factory input type representative</param>
    /// <param name="t">A target vector component type representative</param>
    /// <typeparam name="F">The factory type</typeparam>
    /// <typeparam name="C">The check operator type</typeparam>
    /// <typeparam name="S">The factory input type</typeparam>
    /// <typeparam name="T">The target vector component type</typeparam>
    void CheckFactory<F,C,S,T>(N128 w, F f, C check, S s = default, T t = default)
        where S : unmanaged
        where T : unmanaged
        where F : IFactory128<S,T>
        where C : ICheckSF128<S,T>
    {
        var succeeded = true;
        var casename = SFxIdentity.name(f);
        var count = Time.counter();

        count.Start();

        void exec()
        {
            for(var i=0; i < RepCount; i++)
            {
                var a = Random.Next<S>();
                var v = f.Invoke(a);
                require(check.Invoke(a,v), ClaimKind.Eq);
            }
        }

        try
        {
            exec();
        }
        catch(Exception e)
        {
            term.errlabel(e,casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename,succeeded,count);
        }
    }

    /// <summary>
    /// Verifies the correct function of a vectorized factory operator
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <param name="f">The factory operator to verify</param>
    /// <param name="check">The adjudication operator</param>
    /// <param name="s">A factory input type representative</param>
    /// <param name="t">A target vector component type representative</param>
    /// <typeparam name="F">The factory type</typeparam>
    /// <typeparam name="C">The check operator type</typeparam>
    /// <typeparam name="S">The factory input type</typeparam>
    /// <typeparam name="T">The target vector component type</typeparam>
    void CheckFactory<F,C,S,T>(N256 w, F f, C check, S s = default, T t = default)
        where S : unmanaged
        where T : unmanaged
        where F : IFactory256<S,T>
        where C : ICheckSF256<S,T>
    {
        var succeeded = true;
        var casename = SFxIdentity.name(f);
        var count = Time.counter();

        count.Start();

        void exec()
        {
            for(var i=0; i<RepCount; i++)
            {
                var a = Random.Next<S>();
                var v = f.Invoke(a);
                require(check.Invoke(a,v), ClaimKind.Eq);
            }
        }

        try
        {
            exec();
        }
        catch(Exception e)
        {
            term.errlabel(e,casename);
            succeeded = false;
        }
        finally
        {
            Context.ReportCaseResult(casename,succeeded,count);
        }
    }
}
