//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using Windows;

    class ImageCmd : WfAppCmd<ImageCmd>
    {        
        [ApiHost,Free]
        public sealed class ProcessControl : Control<ProcessControl>
        {
            public static IControl Control()
                => Instance;    

            static ProcessControl Instance = new();

            public unsafe static Outcome context(out Amd64Context dst)
            {
                var id = ThreadId.Empty;
                var success = Outcome.Success;
                var ctx = default(Amd64Context);

                void OnStart(EventWaitHandle wait)
                {
                    id = Kernel32.GetCurrentThreadId();
                    using var open = ProcessThreads.open(id);
                    success = Kernel32.GetThreadContext(open, (IntPtr)sys.gptr(ctx));
                    wait.Set();
                }

                var wait = new EventWaitHandle(false, EventResetMode.ManualReset);
                var thread = new Thread(new ParameterizedThreadStart(obj => OnStart((EventWaitHandle)obj)));
                thread.Start(wait);
                wait.WaitOne();            
                dst = ctx;
                term.babble(id);
                return success;           
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

        static string render(object src)
        {
            var dst = EmptyString;
            var code = Type.GetTypeCode(src.GetType());
            switch(code)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                    dst = string.Format("{0:x2}", src);
                break;
                case TypeCode.UInt16:
                case TypeCode.Int16:
                    dst = string.Format("{0:x4}", src);
                break;
                case TypeCode.UInt32:
                case TypeCode.Int32:
                    dst = string.Format("{0:x8}", src);
                break;
                case TypeCode.UInt64:
                case TypeCode.Int64:
                    dst = string.Format("{0:x16}", src);
                break;
                default:
                    dst = src.ToString();
                    break;
            }
            return dst;

        }

        [CmdOp("process/thread")]
        void ProcessThread()
        {
            if(ProcessControl.context(out var context))
            {
                var fields = context.GetType().Fields();
                iter(fields, f => {
                    Channel.Row(string.Format("{0:16} {1}", f.Name, render(f.GetValue(context))));
                });
            }
            else
            {
                Channel.Error("No joy");
            }
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