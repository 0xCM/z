//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct OpEvaluation<S> : IOpEvaluation<S>
    {
        public readonly IOperation Actor {get;}

        public readonly S Input {get;}

        public readonly dynamic Output {get;}

        [MethodImpl(Inline)]
        public OpEvaluation(IOperation op, S src, dynamic result)
        {
            Actor = op;
            Input = src;
            Output = result;
        }

        public string Format()
            => eval.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OpEvaluation(OpEvaluation<S> src)
            => new OpEvaluation(src.Actor, src.Input, src.Output);
    }
}