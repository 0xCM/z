//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmAsmOpCodeMap : ConstLookup<Identifier,Index<InstEntity>>
    {
        public LlvmAsmOpCodeMap(Dictionary<Identifier,Index<InstEntity>> src)
            : base(src)
        {


        }

        public static implicit operator LlvmAsmOpCodeMap(Dictionary<Identifier,Index<InstEntity>> src)
            => new LlvmAsmOpCodeMap(src);
    }
}