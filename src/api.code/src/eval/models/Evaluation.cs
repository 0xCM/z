//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct Evaluation : IEvaluation
    {
        public dynamic Input {get;}

        public dynamic Output {get;}

        [MethodImpl(Inline)]
        public Evaluation(dynamic input, dynamic output)
        {
            Input = input;
            Output = output;
        }
    }
}