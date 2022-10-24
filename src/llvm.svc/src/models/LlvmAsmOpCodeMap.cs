//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmAsmOpCodeMap : ConstLookup<Identifier,Index<X86InstDef>>
    {
        public LlvmAsmOpCodeMap(Dictionary<Identifier,Index<X86InstDef>> src)
            : base(src)
        {


        }

        public static implicit operator LlvmAsmOpCodeMap(Dictionary<Identifier,Index<X86InstDef>> src)
            => new LlvmAsmOpCodeMap(src);
    }
}