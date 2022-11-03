//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an operation which is, by definition, a named evaluator
    /// </summary>
    [Free]
    public interface IOpSvc : IExprSvc
    {
        Identifier OpName {get;}
    }

    [Free]
    public interface IOpSvc<S> : IOpSvc, IExprSvc<S>
    {
        bool IExprSvc.Eval(in dynamic src, out dynamic dst)
            => Eval(src, out dst);
    }

    [Free]
    public interface IOpSvc<S,T> : IOpSvc<S>, IExprSvc<S,T>
    {
        bool IExprSvc<S>.Eval(in S src, out dynamic dst)
        {
            var succeeded = Eval(src, out var v);
            if(succeeded)
                dst = v;
            else
                dst = default(T);
            return succeeded;
        }
    }
}