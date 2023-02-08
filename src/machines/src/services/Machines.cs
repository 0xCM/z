//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Machines : WfAppCmd<Machines>
    {
        IPolyrand Random;

        EventQueue Queue;

        X86Machine Machine;

        EventSignal Signal;

        bool Verbose;

        public Machines()
        {
            Verbose = true;
        }

        void EventRaised(IEvent e)
        {
            Write(e.Format());
        }

        protected override void Initialized()
        {
            Random = Rng.@default();
            Queue = EventQueue.allocate(typeof(Machines), EventRaised);
            Signal = Events.signal(Queue, GetType());
            Machine = X86Machine.create(Signal);
        }

        protected override void Disposing()
        {
            EmptyQueue();
            Queue.Dispose();
            Machine.Dispose();
        }

        void EmptyQueue()
        {
            while(Queue.Next(out var e))
                Wf.Raise(e);
        }

        void DumpRegs()
        {
            var buffer = text.buffer();
            X86Machine.state(Machine,buffer);
            Write(buffer.Emit());
        }

        void TestStack()
        {
            var result = Outcome.Success;
            var stack = CpuModels.stack<ulong>(24);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            while(stack.Pop(out var cell))
            {
                Write(cell);
            }
        }

        [CmdOp("machine/check")]
        void CheckMachine()
        {
            TestStack();
            TestMatchMachine();
            DumpRegs();
        }

        [CmdOp("machine/calc")]
        void Calc()
        {
            var w = w128;
            var flow = Wf.Running(w.ToString());
            var size = RunCalc(w);
            Channel.Ran(flow, size);
        }

        bool TestMatchMachine()
        {
            var result = true;
            result &= Match(2, first32u(MatchTarget0), MatchInput);
            result &= Match(2, first32u(MatchTarget1), MatchInput);
            result &= Match(3, first32u(MatchTarget2), MatchInput);
            result &= Match(1, first32u(MatchTarget3), MatchInput);
            result &= Match(3, first32u(MatchTarget4), MatchInput);
            return result;
        }

        Outcome Match(byte n, uint src, ReadOnlySpan<byte> input)
        {
            var result = Outcome.Success;
            var spec = Match3x8.specify(n,src);
            var machine = Match3x8.create(spec);
            Write(spec.Format());
            var i = machine.Run(input);
            var matched = i>=0;
            var msg = matched ? string.Format("Matched: i={0}",i) : "Unmatched";
            result = (matched, msg);
            Write(result.Message);
            return result;
        }

        void Run(N10 n)
        {
            var stack = StackMachines.create(Pow2.T08);
            stack.Push(2);
            Queue.Deposit(Events.data(stack.state()));
            stack.Push(4);
            Queue.Deposit(Events.data(stack.state()));
            stack.Push(6);
            Queue.Deposit(Events.data(stack.state()));
        }

        void Run(N11 n)
        {
            const uint CellCount = 4096;
            const uint JobCount = 256;
            const uint CycleCount = 256;

            Task<uint> RunMachine(uint cycles)
                => Task.Factory.StartNew(() => new BinaryProcessor(CellCount, Rng.@default()).Run(cycles));

            var flow = Wf.Running("Test11");
            var clock = Time.counter(true);
            var count = 0ul;
            var tasks = sys.stream(0u,JobCount).Map(i => RunMachine(CycleCount));
            Task.WaitAll(tasks);
            foreach(var t in tasks)
                count += t.Result;

            var time = clock.Elapsed();
            Wf.Ran(flow, string.Format("Processed {0:##,#} items in {1} ms", count, time.Ms));
        }

        void Run(N19 n)
            => VPipeTests.test(Wf);

        void Run(N21 n)
            => BlitMachine.create(Wf).Run();

        static void run(N26 n, IWfChannel channel)
        {
            void receive(uint i, uint j)
            {
                channel.Write(string.Format("{0} -> {1}", i, j));
            }

            var seq = SeqSpecs.finite((0u,57u), i => i + 1);
            channel.Write(string.Format("{0}..{1}", seq.Min, seq.Max));
            var count = seq.Compute(receive);
            count += seq.Compute(receive);
            channel.Write(string.Format("Term Count:{0}", count));
        }

        void Run(N33 n)
        {
            bool Predicate(SpinStats stats)
                => stats.Count > 20;
            
            Spinners.spin(TimeSpan.FromSeconds(1), Predicate);
        }

        void Run(N29 n)
        {
            var inputs = BinaryBitLogicOps.inputs(w1);
            var eval = BinaryBitLogicOps.canonical(w1,inputs);
            var count = inputs.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(inputs,i);
                ref readonly var result = ref skip(eval,i);
                Write(string.Format("{0:D2} | {1}", i, result.Format(BinaryBitLogicOps.FormatOption.Bitstrings)));
            }
        }

        void Run(N32 n)
        {
            var evals = BinaryBitLogicOps.canonical(w1);
            var count = evals.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var eval = ref skip(evals,i);
                Write(eval.Format());
            }
        }

        sealed class Buffer1 : PageBank16x4x4<Buffer1>
        {

        }

        sealed class Buffer2 : PageBank16x4x4<Buffer2>
        {

        }

        sealed class Buffer3 : PageBank16x4x4<Buffer3>
        {

        }

        [Op]
        ByteSize RunCalc(W128 w)
        {
            // var buffer = Buffer3.allocated();
            // var sizes = 0ul;
            // var cells = Buffer3.BlockSize/w.DataSize;
            // ref var left = ref buffer.Block(n0).Segment<Cell128>(0);
            // ref var right = ref buffer.Block(n1).Segment<Cell128>(1);
            // ref var target = ref buffer.Block(n2).Segment<Cell128>(2);
            // var f = Calcs.vor<uint>(w);
            // for(var i=0u; i<cells; i++)
            // {
            //     ref var a = ref seek(left,i);
            //     a = cpu.vbroadcast(w,i);
            //     ref var b = ref seek(right,i);
            //     b = cpu.vbroadcast(w,i + Pow2.T12);
            //     seek(target,i) = cpu.vor(a,b);
            //     sizes += 3*16;
            // }
            // return sizes;
            return 0;
        }

        void Run(N16 n)
        {
            var dst = Buffer1.allocated();
            Run(n, ref dst);
        }

        void Run(N16 n, ref Buffer1 buffer)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            var block = buffer.Block(n0);
            var segsize = 32;
            uint count = block.Size/segsize;
            ref var src = ref block.Segment<Cell256>(0);
            for(var i=0u; i<count; i++)
                seek(src,i) = i;

            for(var i=0; i<count; i++)
            {
                ref readonly var j = ref first(recover<uint>(bytes(skip(src,i))));
                Write(string.Format("{0:D4}:{1}",i, j.FormatHex()));
            }

            Channel.Row(block.Describe());
        }

        void LogHeader<N>(MethodBase src, N n)
            where N : unmanaged, ITypeNat
                => Channel.Row(string.Format("{0} {1} ", src.Name, n).PadRight(80,Chars.Dash));

        void Run(N8 n)
        {
            var dst = Buffer1.allocated();
            Run(n, ref dst);
        }

        void Run(N8 n, ref Buffer1 buffer)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            var block = buffer.Block(n0);
            var segsize = size<Cell256>();
            uint count = block.Size/segsize;
            ref var src = ref block.Segment<Cell256>(0);
            for(var i=0u; i<count; i++)
                seek(src,i) = i;

            for(var i=0; i<count; i++)
            {
                ref readonly var j = ref first(recover<uint>(bytes(skip(src,i))));
                Channel.Row(string.Format("{0:D4}:{1}",i, j.FormatHex()));
            }

            Channel.Row(block.Describe());
        }

        void Run(N3 n)
        {
            var bank = Buffer1.allocated();
            var size = Buffer1.BlockSize;
            var w = w128;
            var cells = size/size<Cell128>();

            var left = bank.Block(n0);
            Random.Fill(left.Bytes);
            var right = bank.Block(n1);
            Random.Fill(right.Bytes);

            var dst = bank.Block(n2);
            or(left, right, dst);

            ref var lCell = ref left.Segment<Cell128>(0);
            ref var rCell = ref right.Segment<Cell128>(0);
            ref var target = ref dst.Segment<Cell128>(0);

            for(var i=0u; i<cells; i++)
            {
                ref readonly var a = ref skip(lCell,i);
                ref readonly var b = ref skip(rCell,i);
                ref readonly var result = ref skip(target,i);
                Wf.Data(string.Format("{0:D6} {1}([{2}],[{3}]) = {4}", i, "or", a.V32u.FormatHex(), b.V32u.FormatHex(), result.V32u.FormatHex()));
            }
        }

        void or(in MemoryPage lhs, in MemoryPage rhs, in MemoryPage dst)
        {
            var size = lhs.Size;
            var w = w128;
            var cells = size/size<Cell128>();
            ref var left = ref lhs.Segment<Cell128>(0);
            ref var right = ref rhs.Segment<Cell128>(1);
            ref var target = ref dst.Segment<Cell128>(2);
            // var f = Calcs.vor<uint>(w);
            // for(var i=0u; i<cells; i++)
            //     seek(target,i) = f.Invoke(seek(left,i),seek(right,i));
        }

        void Run(N5 n)
        {
            var bank = Buffer2.allocated();
            var size = Buffer2.BlockSize;
            var w = w128;
            var left = bank.Block(n0);
            Random.Fill(left.Bytes);
            var right = bank.Block(n1);
            Random.Fill(right.Bytes);

            var dst = bank.Block(n2);
            or(left, right, dst);

            ref var lCell = ref left.Segment<Cell128>(0);
            ref var rCell = ref right.Segment<Cell128>(0);
            ref var target = ref dst.Segment<Cell128>(0);

            var cells = left.Size/size<Cell128>();
            for(var i=0u; i<cells; i++)
            {
                ref readonly var a = ref skip(lCell,i);
                ref readonly var b = ref skip(rCell,i);
                ref readonly var result = ref skip(target,i);
                Channel.Row(string.Format("{0:D6} {1}([{2}],[{3}]) = {4}", i, "or", a.V32u.FormatHex(), b.V32u.FormatHex(), result.V32u.FormatHex()));
            }
        }

        [CmdOp("machine/run")]
        void Run(CmdArgs args)
        {
            if(uint.TryParse(arg(args,0).Value, out var n))
            {
                switch(n)
                {
                    case 3:
                        Run(n3);
                    break;
                    case 5:
                        Run(n5);
                    break;
                    case 8:
                        Run(n8);
                    break;
                    case 10:
                        Run(n10);
                    break;
                    case 11:
                        Run(n11);
                    break;
                    case 16:
                        Run(n16);
                    break;
                    case 19:
                        Run(n19);
                    break;
                    case 21:
                        Run(n21);
                    break;
                    case 26:
                        run(n26,Emitter);
                    break;
                    case 29:
                        Run(n29);
                    break;
                    case 32:
                        Run(n32);
                    break;
                    case 33:
                        Run(n33);
                    break;
               }
            }
        }

        static ReadOnlySpan<byte> MatchTarget0 => new byte[4]{0x24,0x12,0x00,0x00};

        static ReadOnlySpan<byte> MatchTarget1 => new byte[4]{0xCC,0x00,0x00,0x00};

        static ReadOnlySpan<byte> MatchTarget2 => new byte[4]{0x48,0x16,0x19,0x00};

        static ReadOnlySpan<byte> MatchTarget3 => new byte[4]{0x19,0x00,0x00,0x00};

        static ReadOnlySpan<byte> MatchTarget4 => new byte[4]{0xCC,0x00,0x19,0x00};

        static ReadOnlySpan<byte> MatchInput => new byte[]{
            0x52,0x21,0x18,0x00,
            0x23,0x48,0x16,0x19,
            0x22,0x24,0x12,0xCC,
            0xCC,0x00,0x19,0x00
            };
    }
}