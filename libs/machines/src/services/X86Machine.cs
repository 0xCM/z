//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading.Tasks;

    using static core;

    using Asm;

    public interface IX86Machine
    {
        void Dispatch(in AsmCode asm);
    }

    [ApiHost]
    public unsafe partial class X86Machine : IDisposable, IX86Machine
    {
        public static X86Machine create(EventSignal signal)
            => new X86Machine(signal);

        RegBank Regs;

        byte* R8;

        ushort* R16;

        uint* R32;

        ulong* R64;

        Cell512* R512;

        ulong* K;

        ulong* SYS;

        Stack<ulong> Stack;

        PageDispenser Ram;

        MemoryAddress CodeBase;

        EventSignal Signal;

        Task Dispatcher;

        ConcurrentQueue<AsmCode> Queue;

        bool Verbose;

        internal X86Machine(EventSignal signal)
        {
            Queue = new();
            Signal = signal;
            Regs = RegBanks.intel64();
            R64 = Regs[0].BaseAddress.Pointer<ulong>();
            R512 = Regs[1].BaseAddress.Pointer<Cell512>();
            K = Regs[2].BaseAddress.Pointer<ulong>();
            SYS = Regs[3].BaseAddress.Pointer<ulong>();
            R32 = (uint*)R64;
            R16 = (ushort*)R64;
            R8 = (byte*)R64;
            Stack = CpuModels.stack<ulong>(64);
            Ram = Dispense.pages(256);
            CodeBase = Ram.Page().BaseAddress;
            *CodeBase.Pointer<ulong>() = 0xCC;
            rip() = CodeBase;
        }

        public void Dispatch(in AsmCode cmd)
        {
            Queue.Enqueue(cmd);
        }

        void Execute(in AsmCode cmd)
        {

        }

        void Spin()
        {
            var counter = 0u;
            var ticks = 0L;
            var host = GetType();

            void Receiver(long t)
            {
                while(Queue.TryDequeue(out var cmd))
                    Execute(cmd);

                counter++;
                ticks += t;
                if(Verbose)
                    Signal.Babble(string.Format("{0:D4}:{1:D12}", counter, ticks));
            }

            var spinner = new Spinner(TimeSpan.FromSeconds(1), Receiver);
            spinner.Spin();
        }

        public IX86Machine Run(bool verbose)
        {
            Verbose = verbose;
            Dispatcher = start(Spin);
            return this;
        }

        internal RegBank Bank
        {
            [MethodImpl(Inline)]
            get => Regs;
        }

        public void Dispose()
        {
            Regs.Dispose();
            (Ram as IDisposable).Dispose();
        }

        [MethodImpl(Inline), Op]
        public MemoryAddress AllocPage()
            => Ram.Page().BaseAddress;

        [MethodImpl(Inline), Op]
        ref byte reg8(RegIndexCode index)
            => ref @ref(R8 + 8*(byte)(index));

        [MethodImpl(Inline), Op]
        ref ushort reg16(RegIndexCode index)
            => ref @ref(R16 + 4*(byte)(index));

        [MethodImpl(Inline), Op]
        ref uint reg32(RegIndexCode index)
            => ref @ref(R32 + 2*(byte)(index));

        [MethodImpl(Inline), Op]
        ref ulong reg64(RegIndexCode index)
            => ref @ref(R64 + (byte)index);

        [MethodImpl(Inline), Op]
        ref Cell512 reg512(RegIndexCode index)
            => ref @ref(R512 + (byte)index);

        [MethodImpl(Inline), Op]
        ref Cell256 reg256(RegIndexCode index)
            => ref @as<Cell512,Cell256>(reg512(index));

        [MethodImpl(Inline), Op]
        ref Cell128 reg128(RegIndexCode index)
            => ref @as<Cell512,Cell128>(reg512(index));

        [MethodImpl(Inline), Op]
        ref ulong mask(RegIndexCode index)
            => ref @ref(K + (byte)index);

        [MethodImpl(Inline), Op]
        ref ulong rflags()
            => ref @ref(SYS);

        [MethodImpl(Inline), Op]
        ref ulong rip()
            => ref @ref(SYS + 1);
    }
}