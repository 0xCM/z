//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class MemoryChecks : WfAppCmd<MemoryChecks>
    {
        [CmdOp("memory/checks")]
        void CheckMemAlloc()
        {
            CheckStringAllocator(Emitter);
            CheckLabelAllocator(Emitter);
        }

        static void CheckStringAllocator(IWfChannel channel)
        {
            var count = Pow2.T16;
            var inputlen = Pow2.T04;
            var totallen = count*inputlen;
            var size = totallen*Sized.size<char>();
            using var dispenser = Dispense.strings(size);
            var strings = sys.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
            {
                var input = BitRender.format16((ushort)i);
                ref var dispensed = ref seek(strings,i);
                dispensed = dispenser.String(input);
                if(!input.Equals(dispensed.Format()))
                {
                    channel.Error($"input:{input} != output:{dispensed}");
                    return;
                }
            }

            channel.Status($"Verified string allocator for {count} inputs over a buffer of size {size}");
        }

        static void CheckLabelAllocator(WfEmit channel)
        {
            var count = 256;
            var result = Outcome.Success;
            var src = sys.alloc<string>(count);
            for(uint i=0; i<count; i++)
                seek(src,i) = BitRender.format8((byte)i);

            using var allocation = LabelAllocation.alloc(src);
            var labels = allocation.Cells;
            if(labels.Length != count)
                result = (false, string.Format("{0} != {1}", labels.Length, count));
            else
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var label = ref skip(labels,i);
                    ref readonly var input = ref skip(src,i);
                    var same = label.Format() == input;
                    if(!same)
                    {
                        channel.Error($"{label} != {input}");
                        break;
                    }
                }
            }
            if(result)
                channel.Status($"Verified {count} label allocations");
        }
    }
}