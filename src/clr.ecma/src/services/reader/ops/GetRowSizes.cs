//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [Op]
        public Index<TableIndex,byte> GetRowSizes()
        {
            var index = Symbols.values<TableIndex,byte>();
            var count = index.Count;
            var dst = sys.alloc<byte>(count);
            for(byte i=0; i<count; i++)
                seek(dst,i) = (byte)MD.GetTableRowSize(index[i].Key);
            return dst;
        }
    }
}