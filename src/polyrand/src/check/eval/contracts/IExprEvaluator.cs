//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IExprEvaluator
    {
        dynamic Evaluate(IExprDeprecated src);
    }

    [Free]
    public interface IExprEvaluator<T> : IExprEvaluator
    {
        new T Evaluate(IExprDeprecated src);

        dynamic IExprEvaluator.Evaluate(IExprDeprecated src)
            => Evaluate(src);
    }

    [Free]
    public interface IExprEvaluator<S,T>
        where S : IExprDeprecated
    {
        T Evaluate(S src);
    }
}