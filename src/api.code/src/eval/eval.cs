//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using XF = ExprPatterns;

    public readonly partial struct eval
    {
        const NumericKind Closure = UnsignedInts;

        public static uint evaluate<S,T>(ReadOnlySpan<S> src, Span<T> dst, IEvaluator<S,T> f)
        {
            var count = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                if(f.Eval(skip(src,i), out seek(dst,i)))
                    counter++;
                else
                    break;
            }
            return counter;
        }


       public static string format<S,T>(in OpEvaluation<S,T> src)
            => string.Format(XF.Eval, src.Actor.OpName, src.Input, src.Output);

        public static string format<S>(in OpEvaluation<S> src)
            => string.Format(XF.Eval, src.Actor.OpName, src.Input, src.Output);

        public static string format<O,S,T>(in OpEvaluation<O,S,T> src)
            where O : IOperation
                => string.Format(XF.Eval, src.Actor.OpName, src.Input, src.Output);

        public static string format(in OpEvaluation src)
            => string.Format(XF.Eval, src.Actor.OpName, src.Input, src.Output);
    }
}