//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using Windows;

    [Flags]
    public enum CONTEXT_FLAGS : uint
    {
        CONTEXT_AMD64 = 0x00100000,

        CONTEXT_CONTROL = CONTEXT_AMD64 | 0x00000001,

        CONTEXT_INTEGER = CONTEXT_AMD64 | 0x00000002,
        
        CONTEXT_SEGMENTS = CONTEXT_AMD64 | 0x00000004,
        
        CONTEXT_FLOATING_POINT = CONTEXT_AMD64 | 0x00000008,
        
        CONTEXT_DEBUG_REGISTERS = CONTEXT_AMD64 | 0x00000010,

        CONTEXT_FULL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_FLOATING_POINT,

        CONTEXT_ALL = CONTEXT_CONTROL | CONTEXT_INTEGER |  CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS,
    
        CONTEXT_XSTATE = CONTEXT_AMD64 | 0x00000040,

        CONTEXT_KERNEL_CET = CONTEXT_AMD64 | 0x00000080,
    }
     
    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public unsafe struct XSAVE_FORMAT 
    {
        public Hex16 ControlWord;

        public Hex16 StatusWord;

        public Hex8 TagWord;

        public Hex8 Reserved1;

        public Hex16 ErrorOpcode;

        public DWORD ErrorOffset;

        public Hex16 ErrorSelector;

        public Hex16 Reserved2;

        public Hex32 DataOffset;

        public Hex16 DataSelector;

        public Hex16 Reserved3;

        public Hex32 MxCsr;

        public Hex32 MxCsr_Mask;

        public FLOAT_REGISTERS FloatRegisters;

        public XMM_REGISTERS XmmRegisters;

        fixed byte Reserved4[96];
    }


    [StructLayout(LayoutKind.Sequential,Pack = 8)]
    public unsafe struct XSAVE_AREA_HEADER 
    {
        public Hex64 Mask;
        
        public Hex64 CompactionMask;
        
        public fixed ulong Reserved2[6];
    }

    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public struct XSAVE_AREA
    {
        public XSAVE_FORMAT LegacyState;

        public XSAVE_AREA_HEADER Header;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XSTATE_CONTEXT
    {
        public Hex64 Mask;

        public Hex32 Length;

        public Hex32 Reserved1;

        public XSAVE_AREA* Area;

        public void* Buffer;

    }

    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public struct XMM_REGISTERS
    {
        public Vector128<byte> Xmm0;

        public Vector128<byte> Xmm1;

        public Vector128<byte> Xmm2;

        public Vector128<byte> Xmm3;

        public Vector128<byte> Xmm4;

        public Vector128<byte> Xmm5;

        public Vector128<byte> Xmm6;

        public Vector128<byte> Xmm7;

        public Vector128<byte> Xmm8;

        public Vector128<byte> Xmm9;

        public Vector128<byte> Xmm10;

        public Vector128<byte> Xmm11;

        public Vector128<byte> Xmm12;

        public Vector128<byte> Xmm13;

        public Vector128<byte> Xmm14;

        public Vector128<byte> Xmm15;

        public override string ToString()
        {
            var dst = text.emitter();
            var fields = GetType().Fields();
            var @this = this;
            iter(fields, f => {
                dst.AppendLineFormat("{0,-16} ", ((Vector128<byte>)f.GetValue(@this)).FormatHex());
            });
            return dst.Emit();
        }
    }

    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public struct FLOAT_REGISTERS
    {
        public Vector128<double> F0;

        public Vector128<double> F1;

        public Vector128<double> F2;

        public Vector128<double> F3;

        public Vector128<double> F4;

        public Vector128<double> F5;

        public Vector128<double> F6;

        public Vector128<double> F7;
    }

    public unsafe struct VECTOR_REGISTERS
    {
        fixed ulong Data[52];

        public override string ToString()
        {
            var cells = recover<Vector128<ulong>>(sys.bytes(this));
            var dst = text.emitter();
            for(var i=0; i<cells.Length; i++)
            {
                dst.AppendLine(skip(cells,i).FormatHex());
            }
            return dst.Emit();
        }
    }
    [StructLayout(LayoutKind.Sequential,Pack=16)]
    public unsafe struct CONTEXT
    {
        public Hex64 P1Home;

        public Hex64 P2Home;

        public Hex64 P3Home;

        public Hex64 P4Home;

        public Hex64 P5Home;

        public Hex64 P6Home;

        public CONTEXT_FLAGS ContextFlags;

        public Hex32 MxCsr;

        public Hex16 SegCs;
        
        public Hex16 SegDs;
        
        public Hex16 SegEs;
        
        public Hex16 SegFs;
        
        public Hex16 SegGs;
        
        public Hex16 SegSs;
        
        public BitVector32 EFlags;

        public Hex64 Dr0;
        
        public Hex64 Dr1;
        
        public Hex64 Dr2;
        
        public Hex64 Dr3;
        
        public Hex64 Dr6;
        
        public Hex64 Dr7;

        public Hex64 Rax;

        public Hex64 Rcx;

        public Hex64 Rdx;

        public Hex64 Rbx;

        public Hex64 Rsp;

        public Hex64 Rbp;

        public Hex64 Rsi;

        public Hex64 Rdi;

        public Hex64 R8;

        public Hex64 R9;

        public Hex64 R10;

        public Hex64 R11;

        public Hex64 R12;

        public Hex64 R13;

        public Hex64 R14;

        public Hex64 R15;

        public Hex64 Rip;

        ByteBlock32 Header;

        ByteBlock16 Legacy0;

        ByteBlock16 Legacy1;

        ByteBlock16 Legacy2;

        ByteBlock16 Legacy3;

        ByteBlock16 Legacy4;

        ByteBlock16 Legacy5;

        ByteBlock16 Legacy6;

        ByteBlock16 Legacy7;

        public XMM_REGISTERS Xmm;
        
        public VECTOR_REGISTERS VectorRegisters;

        public Hex64 VectorControl;

        public Hex64 DebugControl;
        
        public Hex64 LastBranchToRip;
        
        public Hex64 LastBranchFromRip;
        
        public Hex64 LastExceptionToRip;
        
        public Hex64 LastExceptionFromRip;
    }

    class ImageCmd : WfAppCmd<ImageCmd>
    {        
        [ApiHost,Free]
        public sealed class ProcessControl : Control<ProcessControl>
        {
            public static IControl Control()
                => Instance;    

            static ProcessControl Instance = new();

            public static unsafe Outcome context(ThreadId id, out CONTEXT dst)
            {
                var result = Outcome.Failure;
                var ctx = default(CONTEXT);
                ctx.ContextFlags = CONTEXT_FLAGS.CONTEXT_CONTROL | CONTEXT_FLAGS.CONTEXT_SEGMENTS | CONTEXT_FLAGS.CONTEXT_INTEGER;
                ctx.VectorControl = 1;
                using var open = ProcessThreads.open(id);
                result = Kernel32.GetThreadContext(open, (IntPtr)sys.gptr(ctx));
                if(result.Fail)
                    result = Outcome.fail(Kernel32.GetLastError());
                dst = ctx;
                return result;
            }

            public unsafe static Outcome context(out CONTEXT dst)
            {
                var id = ThreadId.Empty;
                var result = Outcome.Failure;
                var ctx = default(CONTEXT);

                void OnStart(EventWaitHandle wait)
                {
                    id = ProcessThreads.executing();
                    result = context(id, out ctx);
                    // using var open = ProcessThreads.open(id);
                    // result = Kernel32.GetThreadContext(open, (IntPtr)sys.gptr(ctx));
                    // if(result.Fail)
                    //     result = Outcome.fail(Kernel32.GetLastError());
                    wait.Set();
                }

                var wait = new EventWaitHandle(false, EventResetMode.ManualReset);
                var thread = new Thread(new ParameterizedThreadStart(obj => OnStart((EventWaitHandle)obj)));
                thread.Start(wait);
                wait.WaitOne();            
                dst = ctx;
                term.babble(id);
                return result;           
            }
        }

        [CmdOp("process/memory")]
        Outcome ShowMemHex(CmdArgs args)
        {
            var address = MemoryAddress.Zero;
            var result = DataParser.parse(arg(args,0), out address);
            var size = 16u;
            if(result)
            {

                if(args.Count >= 2)
                    result = DataParser.parse(arg(args,1), out size);

                if(result)
                {
                    var data = sys.cover(address.Ref<byte>(), size);
                    var hex = data.FormatHex();
                    Channel.Write(string.Format("{0,-16}: {1}", address, hex));
                }

            }
            return result;
        }
        
        [CmdOp("process/list")]
        void ProcessList()
        {
            const string Pattern = "{0,-24} | {1,-12}";
            var src = ProcessAdapter.proceses().Sort();
            var dst = text.emitter();
            dst.AppendLineFormat(Pattern,"Name", "PID");
            iter(src, p => dst.AppendLineFormat(Pattern, p.ProcessName, p.Id));
            var data = dst.Emit();
            Channel.Row(data);
            Channel.FileEmit(data, Env.ShellData.Path("processes", FileKind.Csv));
        }


        [CmdOp("process/thread")]
        unsafe void ProcessThread()
        {
            var v0 = vcpu.vbroadcast(w128,0xFF);
            var v1 = vcpu.vbroadcast(w128,0xFF);
            var v2 = vcpu.vbroadcast(w128,0xFF);
            var v3 = vcpu.vbroadcast(w128,0xFF);
            var f0 = vcpu.vbroadcast(w128, (double)255.0);
            var result = ProcessControl.context(ProcessThreads.executing(), out var context);

            if(result)            
            {
                var fields = context.GetType().Fields();
                iter(fields, f => {
                    Channel.Row(string.Format("{0,-16} {1}", f.Name, f.GetValue(context)));
                });
            
            }
            else
                Channel.Error(result.Message);
        }

        [CmdOp("process/context")]
        void ProcContext(CmdArgs args)
            => ImageMemory.dump(Channel, args, AppSettings.ProcDumps());

        [CmdOp("process/map")]
        void ProcMap(CmdArgs args)
            => ImageMemory.map(Channel, args, Env.ShellData);

        [CmdOp("process/modules")]
        void ProcModules(CmdArgs args)
            => ImageMemory.modules(Channel, args, Env.ShellData);
    }
}