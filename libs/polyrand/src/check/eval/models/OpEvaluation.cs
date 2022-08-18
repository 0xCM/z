//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct OpEvaluation : IOpEvaluation
    {
        public readonly IOperation Actor {get;}

        public readonly dynamic Input {get;}

        public readonly dynamic Output {get;}

        [MethodImpl(Inline)]
        public OpEvaluation(IOperation op, dynamic src, dynamic result)
        {
            Actor = op;
            Input = src;
            Output = result;
        }

        public string Format()
            => eval.format(this);

        public override string ToString()
            => Format();
    }
}