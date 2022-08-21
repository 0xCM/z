//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    using strings;

    [ApiComplete]
    public readonly struct GenStrings
    {
        public static MemoryStrings<ushort> OpCodes
        {
            [MethodImpl(Inline)]
            get => MemoryStrings.create<ushort>(InstructionST.Offsets, InstructionST.Data);
        }
    }

    public class StringTableChecks : Checker<StringTableChecks>
    {
        Outcome LabelTest1()
        {
            var result = Outcome.Success;
            var data = MemoryStrings.create(InstructionST.Offsets, InstructionST.Data);
            var count = data.EntryCount;

            for(var i=0; i<count; i++)
            {
                var current = data[i];
                var length = (uint)current.Length;
                var address = data.Address(i);
                var label = data.Label(i);
                var a = text.format(current);
                var b = label.Format();
                if(!text.equals(a,b))
                {
                    result = (false, string.Format("{0} != {1}", a, b));
                    break;
                }
            }

            if(result)
            {
                //Write(string.Format("Verified {0} stringtable lookups", count));
            }

            return result;
        }


        public void RunAll()
        {
            var result = Outcome.Success;
            var runtime = MemoryStrings.create(AVX512ST.Offsets, AVX512ST.Data);
            var offsets = runtime.Offsets;
            var count = runtime.EntryCount;
            var formatter = Tables.formatter<MemoryStrings>(16);
            var symbols = Symbols.index<AVX512Kind>();
            for(var i=0; i<offsets.Length; i++)
            {
                var l = MemoryStrings.length(runtime, i);
                if(l == 0)
                    break;
                var k = (AVX512Kind)i;
                var o = skip(offsets,i);
                var c = text.format(runtime[i]);
                var info = string.Format("{0} = '{1}'", k, c);
                Write(info);
            }
        }
    }
}