//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Machines : AppCmdService<Machines>
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

        void EventRaised(IWfEvent e)
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

        public IX86Machine RunMachine()
            => Machine.Run(Verbose);

        [CmdOp("machine/run")]
        Outcome RunMachine(CmdArgs args)
        {
            var dispatcher = Machine.Run(Verbose);
            return true;
        }

        void DumpRegs()
        {
            var buffer = text.buffer();
            X86Machine.state(Machine,buffer);
            Write(buffer.Emit());
        }

        [CmdOp("machine/regs/dump")]
        Outcome RegDump(CmdArgs args)
        {
            var result = Outcome.Success;
            DumpRegs();
            return result;
        }

        [CmdOp("machine/bss/dump")]
        Outcome TestBss(CmdArgs args)
        {
            var result = Outcome.Success;
            var dispenser = CoffSections.dispenser();
            var entries = dispenser.Entries();
            var count = entries.Length;
            const sbyte Pad = -16;

            Write(RpOps.attrib(nameof(dispenser.EntryCount), count));
            for(ushort i=0; i<count; i++)
            {
                ref readonly var entry = ref dispenser.Entry(i);
                var desc = entry.Descriptor();
                var capacity = desc.Capacity;
                Write(RpOps.PageBreak32);
                Write(RpOps.attrib(Pad, nameof(desc.Index), desc.Index));
                Write(RpOps.attrib(Pad, nameof(desc.BaseAddress), desc.BaseAddress));
                Write(RpOps.attrib(Pad, nameof(desc.EndAddress), desc.EndAddress));
                Write(RpOps.attrib(Pad, nameof(capacity.Indicator), capacity.Indicator));
                Write(RpOps.attrib(Pad, nameof(capacity.CellSize), capacity.CellSize));
                Write(RpOps.attrib(Pad, nameof(capacity.CellsPerSeg), capacity.CellsPerSeg));
                Write(RpOps.attrib(Pad, nameof(capacity.SegSize), capacity.SegSize));
                Write(RpOps.attrib(Pad, nameof(capacity.SegCount), capacity.SegCount));
                Write(RpOps.attrib(Pad, nameof(capacity.SegsPerBlock), capacity.SegsPerBlock));
                Write(RpOps.attrib(Pad, nameof(capacity.BlockCount), capacity.BlockCount));
                Write(RpOps.attrib(Pad, nameof(capacity.BlockSize), capacity.BlockSize));
                Write(RpOps.attrib(Pad, nameof(capacity.TotalSize), capacity.TotalSize));
            }

            return result;
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
        void CheckMahine()
        {
            TestStack();
            TestMatchMachine();
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

        void Run(N3 n)
        {
            var bank = PageBank16x4x4.allocated();
            var size = PageBank16x4x4.BlockSize;
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
            var f = Calcs.vor<uint>(w);
            for(var i=0u; i<cells; i++)
            {
                ref var a = ref seek(left,i);
                //a = cpu.vbroadcast(w, i);
                ref var b = ref seek(right,i);
                //b = cpu.vbroadcast(w, i + Pow2.T12);
                seek(target,i) = f.Invoke(a,b);
            }
        }

        void Run(N5 n)
        {
            var bank = PageBank16x4x4.allocated();
            var size = PageBank16x4x4.BlockSize;
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
                Wf.Data(string.Format("{0:D6} {1}([{2}],[{3}]) = {4}", i, "or", a.V32u.FormatHex(), b.V32u.FormatHex(), result.V32u.FormatHex()));
            }
        }

        public void Run(N10 n)
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
                => Task.Factory.StartNew(() => new Vmx128x2(CellCount, Rng.@default()).Run(cycles));

            var flow = Wf.Running("Test11");
            var clock = Time.counter(true);
            var count = 0ul;
            var tasks = core.stream(0u,JobCount).Map(i => RunMachine(CycleCount));
            Task.WaitAll(tasks);
            foreach(var t in tasks)
                count += t.Result;

            var time = clock.Elapsed();
            Wf.Ran(flow, string.Format("Processed {0:##,#} items in {1} ms", count, time.Ms));
        }

        void Run(N19 n)
        {
            VPipeTests.test(Wf);
        }

        void Run(N21 n)
        {
            BlitMachine.create(Wf).Run();
        }

        void Run(N26 n)
        {
            void receive(uint i, uint j)
            {
                Write(string.Format("{0} -> {1}", i, j));
            }
            var seq = SeqSpecs.finite((0u,57u), i => i + 1);
            Write(string.Format("{0}..{1}", seq.Min, seq.Max));
            var count = seq.Compute(receive);
            count += seq.Compute(receive);
            Write(string.Format("Term Count:{0}", count));
        }

        void Spin()
        {
            var counter = 0u;
            var ticks = 0L;

            void Receiver(long t)
            {
                counter++;
                ticks += t;

                Write(string.Format("{0:D4}:{1:D12}", counter, ticks));
            }

            var spinner = new Spinner(TimeSpan.FromSeconds(1), Receiver);
            spinner.Spin();
        }

        void Run(N28 n)
        {
            Spin();
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

        [CmdOp("machine/run/cmd")]
        Outcome Run(CmdArgs args)
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
                    case 10:
                        Run(n10);
                    break;
                    case 11:
                        Run(n11);
                    break;
                    case 19:
                        Run(n19);
                    break;
                    case 21:
                        Run(n21);
                    break;
                    case 26:
                        Run(n26);
                    break;
                    case 28:
                        Run(n28);
                    break;
                    case 29:
                        Run(n29);
                    break;
                    case 32:
                        Run(n32);
                    break;

               }
            }
            return true;
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