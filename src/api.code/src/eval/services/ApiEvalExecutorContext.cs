//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct ApiEvalExecutorContext
    {
        public IBoundSource DataSource {get;}

        public uint PointCount {get;}

        public uint Sequence {get;}

        internal ApiEvalExecutorContext(IBoundSource src, uint count, uint seq)
        {
            DataSource = src;
            PointCount = count;
            Sequence = seq;
        }

        public ApiEvalExecutorContext Next
        {
            [MethodImpl(Inline)]
            get => new ApiEvalExecutorContext(DataSource, PointCount, Sequence + 1);
        }
    }
}