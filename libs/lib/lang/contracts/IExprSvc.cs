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
    public interface IExprSvc
    {
        /// <summary>
        /// Attempts to evaluate a specified value, returning <langkeyword name='true'/> upon success and <langkeyword name='false'/> otherwise
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The evaluation</param>
        bool Eval(in dynamic src, out dynamic dst);
    }

    [Free]
    public interface IExprSvc<S> : IExprSvc
    {
        /// <summary>
        /// Attempts to evaluate a specified value, returning <langkeyword name='true'/> upon success and <langkeyword name='false'/> otherwise
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The evaluation</param>
        bool Eval(in S src, out dynamic dst);

        bool IExprSvc.Eval(in dynamic src, out dynamic dst)
            => Eval(src, out dst);
    }

    [Free]
    public interface IExprSvc<S,T> : IExprSvc<S>
    {
        /// <summary>
        /// Attempts to evaluate a specified value, returning <langkeyword name='true'/> upon success and <langkeyword name='false'/> otherwise
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The evaluation</param>
        bool Eval(in S src, out T dst);

        bool IExprSvc<S>.Eval(in S src, out dynamic dst)
        {
            var succeeded = Eval(src, out var v);
            if(succeeded)
            {
                dst = v;
            }
            else
            {
                dst = default(T);
            }
            return succeeded;
        }
    }
}