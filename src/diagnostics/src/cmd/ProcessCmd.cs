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
    
    public record struct StackFrameInfo
    {
        public static StackFrameInfo from(StackFrame src)
        {
            var dst = new StackFrameInfo();
            dst.MethodId = src.GetMethod().MetadataToken;
            dst.MethodSig = Clr.sig(src.GetMethod());
            dst.Point = FilePoint.point(FS.path(src.GetFileName()), src.GetFileLineNumber(), src.GetFileColumnNumber());
            dst.IlOffset = src.GetILOffset();
            dst.IP = src.GetNativeIP();
            dst.NativeBase = src.GetNativeImageBase();
            dst.NativeOffset = src.GetNativeOffset();
            return dst;
        }

        public CliToken MethodId;

        public CliSig MethodSig;

        public FilePoint Point;

        public Address32 IlOffset;

        public MemoryAddress IP;

        public Address64 NativeBase;

        public Address32 NativeOffset;

        public string Format()
        {
            var dst = EmptyString;
            if(Point.Path.IsNonEmpty)
            {
                dst = Point.Format();
            }
            else
            {
                dst = $"{NativeBase}:{NativeOffset}";
            }
            return dst;
        }

        public override string ToString()
            => Format();
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
        
        [CmdOp("process/list")]
        void ProcessList()
        {
            const string Pattern = "{0,-24} | {1,-12}";
            var src = ProcessAdapter.adapt().Sort();
            var dst = text.emitter();
            dst.AppendLineFormat(Pattern,"Name", "PID");
            iter(src, p => dst.AppendLineFormat(Pattern, p.ProcessName, p.Id));
            Row(dst.Emit());           
        }

        [CmdOp("process/context")]
        void ProcessMap(CmdArgs args)
        {
            RuntimeContext.emit(args, Emitter, AppDb.ProcDumps());
        }

        [CmdOp("process/stack")]
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