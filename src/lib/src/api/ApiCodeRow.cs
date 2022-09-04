//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiCodeRow
    {
        const string TableId = "api.code";

        public const byte FieldCount = 6;

        public uint Seq;

        public uint SourceSeq;

        public MemoryAddress Address;

        public uint CodeSize;

        public _OpUri Uri;

        public BinaryCode Data;

        public static ApiCodeRow Empty => default;
    }
}