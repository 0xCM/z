//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymTypeInfo : IRecord<SymTypeInfo>
    {
        public const string TableId = "symtype";

        public Identifier TypeName;

        public PrimalCode DataType;

        public ushort SymCount;

        public ushort TypeNameSize;

        public BinaryCode TypeNameData;
    }
}