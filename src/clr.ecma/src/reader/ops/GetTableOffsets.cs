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
        /// <summary>
        /// Returns the offset from the metadata base to each included metadata table
        /// </summary>
        /// <returns></returns>
        [Op]
        public Index<TableIndex,Address32> GetTableOffsets(ReadOnlySeq<KeyedValue<TableIndex,byte>> indices)
        {
            var count = indices.Count;
            var dst = sys.alloc<Address32>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (uint)MD.GetTableMetadataOffset(indices[i].Key);
            return dst;
        }
    }
}