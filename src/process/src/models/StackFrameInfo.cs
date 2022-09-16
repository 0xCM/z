//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
}