//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Charaterizes an evaluation operation eval:S->T
    /// </summary>
    [Free]
    public interface IEvaluator
    {
        /// <summary>
        /// Attempts to evaluate a specified value, returning <langkeyword name='true'/> upon success and <langkeyword name='false'/> otherwise
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The evaluation</param>
        bool Eval(in dynamic src, out dynamic dst);
    }

    /// <summary>
    /// Chracterizes an <typeparamref name='S'/> evaluator
    /// </summary>
    /// <typeparam name="S">The source value type</typeparam>
    public interface IEvaluator<S> : IEvaluator
    {
        /// <summary>
        /// Attempts to evaluate a specified value, returning <langkeyword name='true'/> upon success and <langkeyword name='false'/> otherwise
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The evaluation</param>
        bool Eval(in S src, out dynamic dst);

        bool IEvaluator.Eval(in dynamic src, out dynamic dst)
            => Eval(src, out dst);
    }

    /// <summary>
    /// Chracterizes an <typeparamref name='S'/> -> <typeparamref name='T'/> evaluator
    /// </summary>
    /// <typeparam name="S">The source value type</typeparam>
    /// <typeparam name="T">The evaluation value type</typeparam>
    [Free]
    public interface IEvaluator<S,T> : IEvaluator<S>
    {
        /// <summary>
        /// Attempts to evaluate a specified value, returning <langkeyword name='true'/> upon success and <langkeyword name='false'/> otherwise
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The evaluation</param>
        bool Eval(in S src, out T dst);

        bool IEvaluator<S>.Eval(in S src, out dynamic dst)
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