//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct VPipeTests
    {
        [Op]
        public static void test(IWfRuntime wf)
        {
            var flow = wf.Running(nameof(VPipeTests));
            var w = w128;
            var blocks = Pow2.T08;
            var random = Rng.@default();
            var mapper = new VMap01();
            var signal = Events.signal(wf.EventSink, typeof(VPipeTests));
            var src = new BlockSource01(random, blocks);
            var dst = new BlockSink01(signal);
            var pipeline = Pipelines.create(w, src, mapper, dst, z8, z8);
            var processed = pipeline.Run();
            wf.Ran(flow, string.Format("Processed {0} blocks", processed));
        }
    }

    public readonly struct VMap01 : IVMap128<VMap01,byte,byte>
    {
        [MethodImpl(Inline)]
        public Vector128<byte> Invoke(Vector128<byte> a)
        {
            var mask = BitMasks.even<byte>(n2,n1);
            var bcast = cpu.vbroadcast(w128, mask);
            return cpu.vand(a, bcast);
        }
    }

    public struct BlockSink01 : IBlockSink128<BlockSink01,byte>
    {
        readonly WfEventSignal Signal;

        uint Counter;

        public ByteSize ReceivedBytes
        {
            [MethodImpl(Inline)]
            get => Counter*16;
        }

        public uint ReceivedCount
        {
            [MethodImpl(Inline)]
            get => Counter;
        }

        [MethodImpl(Inline)]
        public BlockSink01(WfEventSignal wf)
        {
            Signal = wf;
            Counter = 0;
        }

        [MethodImpl(Inline)]
        public void Deposit(in SpanBlock128<byte> src)
        {
            Counter++;
        }
    }

    public readonly struct BlockSource01 : IBlockSource128<BlockSource01, byte>
    {
        public uint BlockCount {get;}

        readonly IBoundSource PolySource;

        [MethodImpl(Inline)]
        public BlockSource01(IBoundSource source, uint count)
        {
            PolySource = source;
            BlockCount = count;
        }

        public SpanBlock128<byte> Emit(uint index)
        {
            var buffer = SpanBlocks.single<byte>(w128);
            PolySource.Fill(buffer);
            return buffer;
        }
    }
}