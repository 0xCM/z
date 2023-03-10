//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MsilRow
    {
        const string TableId = "image.msil";

        public const byte FieldCount = 8;

        [Render(32)]
        public @string ImageName;

        [Render(12)]
        public EcmaToken Token;

        [Render(12)]
        public Address32 MethodRva;

        [Render(12)]
        public ByteSize BodySize;

        [Render(12)]
        public ByteSize MaxStack;

        [Render(12)]
        public bool LocalInit;

        [Render(32)]
        public ClrMemberName MethodName;

        [Render(1)]
        public BinaryCode Code;
    }
}