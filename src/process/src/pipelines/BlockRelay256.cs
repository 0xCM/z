//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BlockRelay256<S,T> : IBlockRelay256<S,T>
        where S : unmanaged
        where T : unmanaged
    {
        readonly IBlockSource256<S> Source;

        readonly IBlockSink256<T> Target;

        static W256 W => default;

        [MethodImpl(Inline)]
        public BlockRelay256(IPipeline pipes, IBlockSource256<S> src, IBlockSink256<T> dst)
        {
            Source = src;
            Target = dst;
        }

        public uint BlockCount
        {
            [MethodImpl(Inline)]
            get => Source.BlockCount;
        }

        [MethodImpl(Inline)]
        public void Run<P>(P projector)
            where P : IBlockProjector256<P,S,T>
        {
            var w = w256;
            var count = BlockCount;
            var buffer = SpanBlocks.single<T>(w);
            for(var i=0u; i<count; i++)
            {
                buffer.BlockLead(0) = default;
                var emission = Emit(i);
                projector.Project(emission, buffer);
                Deposit(buffer);
            }
        }

        [MethodImpl(Inline)]
        public void Deposit(in SpanBlock256<T> src)
            => Target.Deposit(src);

        [MethodImpl(Inline)]
        public SpanBlock256<S> Emit(uint index)
            => Source.Emit(index);
    }

    public readonly struct BlockRelay256<A,S,B,T> : IBlockRelay256<S,T>
        where S : unmanaged
        where A : IBlockSource256<S>
        where T : unmanaged
        where B : IBlockSink256<T>
    {
        readonly A Source;

        readonly B Sink;

        [MethodImpl(Inline)]
        public BlockRelay256(IPipeline pipes, A src, B dst)
        {
            Source = src;
            Sink = dst;
        }

        public uint BlockCount
        {
            [MethodImpl(Inline)]
            get => Source.BlockCount;
        }

        [MethodImpl(Inline)]
        public void Run<P>(P projector)
            where P : IBlockProjector256<P,S,T>
        {
            var w = w256;
            var count = BlockCount;
            var buffer = SpanBlocks.single<T>(w);
            for(var i=0u; i<count; i++)
            {
                buffer.BlockLead(0) = default;
                var emission = Emit(i);
                projector.Project(emission, buffer);
                Deposit(buffer);
            }
        }

        [MethodImpl(Inline)]
        public void Deposit(in SpanBlock256<T> src)
            => Sink.Deposit(src);

        [MethodImpl(Inline)]
        public SpanBlock256<S> Emit(uint index)
            => Source.Emit(index);
    }
}