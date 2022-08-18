//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct StringTableRow
    {
        const string TableId = "stringtables";

        [Render(24)]
        public string Table;

        [Render(12)]
        public uint Index;

        [Render(1)]
        public string Content;

        public string Format()
            => string.Format("{0}[{1}]='{2}'", Table, Index, Content);

        public override string ToString()
            => Format();
   }
}