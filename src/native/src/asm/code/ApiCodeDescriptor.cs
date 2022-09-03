//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiCodeDescriptor
    {
        public const string TableId = "apicode";

        public ApiPartKind Part;

        public @string Host;

        public MemoryAddress Base;

        public ByteSize Size;

        public OpUri Uri;

        public BinaryCode Encoded;
    }
}