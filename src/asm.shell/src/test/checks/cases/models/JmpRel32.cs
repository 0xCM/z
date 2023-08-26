//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmCases
{
    public struct JmpRel32
    {
        public @string Statment;

        public MemoryAddress Source;

        public Disp32 Disp;

        public AsmHexCode Encoding;

        public MemoryAddress RelativeTarget;

        public string Format()
            => string.Format("{0} jmp near ptr {1:x}h | {2}", Source, (int)Disp, Encoding);


        public override string ToString()
            => Format();
    }
}
