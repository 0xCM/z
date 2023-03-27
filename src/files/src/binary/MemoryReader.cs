//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class MemoryReaders
    {
        public sealed class MemoryReader : MemoryReader<MemoryReader>
        {
            public MemoryReader(MemoryAddress @base, ByteSize size, uint offset = 0)
                : base(@base, size, offset)
            {

            }
        }       
    }
}