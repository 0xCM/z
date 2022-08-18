//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct OpEvaluation<S,T> : IOpEvaluation<S,T>
    {
        public readonly IOperation Actor {get;}

        public readonly S Input {get;}

        public readonly T Output {get;}

        [MethodImpl(Inline)]
        public OpEvaluation(IOperation actor, S src, T result)
        {
            Actor = actor;
            Input = src;
            Output = result;
        }

        public string Format()
            => eval.format(this);

        public override string ToString()
            => Format();
    }
}