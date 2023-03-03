//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaModels;

    partial class EcmaReader
    {
        [Op]
        public Index<TableIndex,byte> GetRowSizes(ReadOnlySeq<KeyedValue<TableIndex,byte>> indices)
        {
            var count = indices.Count;
            var dst = sys.alloc<byte>(count);
            for(byte i=0; i<count; i++)
                seek(dst,i) = (byte)MD.GetTableRowSize(indices[i].Key);
            return dst;
        }
    }
}