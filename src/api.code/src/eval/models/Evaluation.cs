//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Evaluation : IEvaluation
    {
        public readonly dynamic Input {get;}

        public readonly dynamic Output {get;}

        [MethodImpl(Inline)]
        public Evaluation(dynamic input, dynamic output)
        {
            Input = input;
            Output = output;
        }
    }
}