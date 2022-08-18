//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ValueTypeRow
    {
        public const string TableId = "llvm.value-type";

        public const byte FieldCount = 3;

        public CharBlock8 Namespace;

        public uint Size;

        public uint Value;
    }
}
