//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct SBlockPipeline128<B,M,R,S,T>
        where R : IBlockSink128<R,T>
        where M : IVMap128<M,S,T>
        where B : IBlockSource128<S>
        where S : unmanaged
        where T : unmanaged
    {
        readonly B Blocks;

        readonly M Mapper;

        readonly R Receiver;

        readonly SBlockProjector128<M,S,T> Projector;

        static W128 W => default;

        [MethodImpl(Inline)]
        public SBlockPipeline128(B blocks, M mapper, R receiver)
        {
            Blocks = blocks;
            Mapper = mapper;
            Receiver = receiver;
            Projector = new SBlockProjector128<M,S,T>(mapper);
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