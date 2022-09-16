//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend 
    {
        public static StackFrameInfo Describe(this StackFrame src)
            => StackFrameInfo.from(src);
    }

    class ProcessCmd : AppCmdService<ProcessCmd>
    {
        [CmdOp("process/memory")]
        Outcome ShowMemHex(CmdArgs args)
        {
            var address = MemoryAddress.Zero;
            var result = DataParser.parse(arg(args,0), out address);
            if(result)
            {

                var size = 16u;
                if(args.Count >= 2)
                    result = DataParser.parse(arg(args,1), out size);

                if(result)
                {
                    ref readonly var src = ref address.Ref<byte>();
                    var data = sys.cover(src,size);
                    var hex = data.FormatHex();
                    Write(string.Format("{0,-16}: {1}", address, hex));
                }

            }
            return result;
        }
        
        [CmdOp("procs/list")]
        void ProcessList()
        {
            const string Pattern = "{0,-24} | {1,-12}";
            var src = ProcessAdapter.proceses().Sort();
            var dst = text.emitter();
            dst.AppendLineFormat(Pattern,"Name", "PID");
            iter(src, p => dst.AppendLineFormat(Pattern, p.ProcessName, p.Id));
            var data = dst.Emit();
            Row(data);
            FileEmit(data, AppDb.AppData().Path("processes", FileKind.Csv));
            //Row(dst.Emit());
            //FileEmit()
        }

        [CmdOp("proc/context")]
        void ProcessMap(CmdArgs args)
        {
            RuntimeContext.emit(args, Emitter, AppDb.ProcDumps());

            //ImageMemory.map()
        }




        [CmdOp("proc/stack")]
        void Trace()
        {
            var trace = new StackTrace(true);
            var frames = trace.GetFrames().ToReadOnlySeq();
            for(var i=0; i<frames.Count; i++)
            {
                ref readonly var frame = ref frames[i];
                Write(frame.Describe());
            }            
        }
    }
}