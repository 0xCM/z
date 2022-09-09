//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct RegBanks
    {
        [Op]
        public static RegBank intel64()
            => allocate(RegFile.intel64());

        /// <summary>
        /// Alocates a set of register representations over a contiguous sequence of native memory
        /// </summary>
        /// <param name="file">The allocation spec</param>
        [Op]
        public static RegBank allocate(RegFile file)
        {
            ref readonly var specs = ref file.Spec(0);
            var count = file.SeqCount;
            var size = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref seek(specs,i);
                size += (spec.RegSize.ByteCount*spec.RegCount);
            }

            var buffer = memory.native(size);
            buffer.Clear();
            var @base = buffer.BaseAddress;
            var address = @base;
            var allocations = alloc<RegAlloc>(count);
            ref var allocation = ref first(allocations);

            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref seek(specs,i);
                var tokens = memory.tokenize(address, spec.RegSize.ByteCount, spec.RegCount);
                seek(allocations,i) = new RegAlloc(spec,tokens);
                var blockSize = spec.RegCount*spec.RegSize.ByteCount;
                address += blockSize;
            }

            return new RegBank(file, buffer, allocations);
        }
    }
}