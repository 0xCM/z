//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    class MemCheckCmd : Checker<MemCheckCmd>
    {
        [CmdOp("memory/checks")]
        void CheckMemAlloc()
        {
            CheckStringAllocator(Channel);
            CheckLabelAllocator(Channel);
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

        static void CheckLabelAllocator(IWfChannel channel)
        {
            var count = 256;
            var result = Outcome.Success;
            var src = sys.alloc<string>(count);
            for(uint i=0; i<count; i++)
                seek(src,i) = BitRender.format8((byte)i);
                
            using var alloc = Alloc.create();
            for(var i=0; i<src.Length; i++)
                Require.equal(skip(src,i), alloc.Label(skip(src,i)).Format());

        }
    }
}