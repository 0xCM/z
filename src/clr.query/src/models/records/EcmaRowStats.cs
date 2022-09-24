//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct EcmaRowStats : IComparable<EcmaRowStats>
    {
        const string TableId = "ecma.rowstats";

        [Render(48)]
        public Label AssemblyName;

        [Render(12)]
        public byte TableIndex;

        [Render(32)]
        public Label TableName;

        [Render(12)]
        public Address32 TableOffset;        

        [Render(12)]
        public uint RowCount;

        [Render(12)]
        public byte RowSize;

        [Render(12)]
        public ByteSize TableSize;

        public int CompareTo(EcmaRowStats src)
        {
            var result = AssemblyName.CompareTo(src.AssemblyName);
            if(result == 0)
                result = TableIndex.CompareTo(src.TableIndex);
            return result;
        }
    }
}