//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        /// <summary>
        /// Returns the offset from the metadata base to each included metadata table
        /// </summary>
        /// <returns></returns>
        [Op]
        public Index<TableIndex,Address32> GetTableOffsets()
        {
            var indicies = Symbols.values<TableIndex,byte>();
            var count = indicies.Count;
            var dst = sys.alloc<Address32>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (uint)MD.GetTableMetadataOffset(indicies[i].Key);
            return dst;
        }
    }
}