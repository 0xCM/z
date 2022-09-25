//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct StackFrames
    {
        [CmdOp("proc/stack")]
        public static void emit(StackTrace src, IWfChannel channel)
        {
            //var trace = new StackTrace(true);
            var frames = src.GetFrames().ToReadOnlySeq();
            for(var i=0; i<frames.Count; i++)
                channel.Write(describe(frames[i]));
        }

        public static StackFrames describe(StackFrame src)
        {
            var dst = new StackFrames();
            dst.MethodId = src.GetMethod().MetadataToken;
            dst.MethodSig = Ecma.sig(src.GetMethod());
            dst.Point = FilePoint.point(FS.path(src.GetFileName()), src.GetFileLineNumber(), src.GetFileColumnNumber());
            dst.IlOffset = src.GetILOffset();
            dst.IP = src.GetNativeIP();
            dst.NativeBase = src.GetNativeImageBase();
            dst.NativeOffset = src.GetNativeOffset();
            return dst;
        }

        public EcmaToken MethodId;

        public EcmaSig MethodSig;

        public FilePoint Point;

        public Address32 IlOffset;

        public MemoryAddress IP;

        public Address64 NativeBase;

        public Address32 NativeOffset;

        public string Format()
        {
            var dst = EmptyString;
            if(Point.Path.IsNonEmpty)
                dst = Point.Format();
            else
                dst = $"{NativeBase}:{NativeOffset}";
            return dst;
        }

        public override string ToString()
            => Format();
    }
}