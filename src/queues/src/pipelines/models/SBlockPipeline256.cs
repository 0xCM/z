//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct SBlockPipeline256<B,M,R,S,T>
        where R : IBlockSink256<R,T>
        where M : IVMap256<M,S,T>
        where B : IBlockSource256<S>
        where S : unmanaged
        where T : unmanaged
    {
        B Blocks;

        M Mapper;

        R Receiver;

        SBlockProjector256<M,S,T> Projector;

        static W256 W => default;

        [MethodImpl(Inline)]
        public SBlockPipeline256(B blocks, M mapper, R receiver)
        {
            Blocks = blocks;
            Mapper = mapper;
            Receiver = receiver;
            Projector = new SBlockProjector256<M,S,T>(mapper);
        }

        [MethodImpl(Inline)]
        public uint Run()
        {
            var count = Blocks.BlockCount;
            var counter = 0u;
            for(var j=0u; j<count; j++)
            {
                var dst = SpanBlocks.single<T>(W);
                var src = Blocks.Emit(j);
                counter += Projector.Map(src, dst);
                Receiver.Deposit(dst);
            }
            return counter;
        }
    }
}