//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct Instruction
    {
        public readonly asci64 Asm;

        public readonly XedInstClass Class;

        public readonly XedInstForm Form;

        public readonly MemoryAddress Ip;

        public readonly AsmHexCode Encoding;

        public readonly InstFieldValues Props;

        [MethodImpl(Inline)]
        public Instruction(asci64 asm, XedInstClass @class, XedInstForm form, MemoryAddress ip, AsmHexCode encoding, InstFieldValues props)
        {
            Asm = asm;
            Class = @class;
            Form = form;
            Ip = ip;
            Encoding = encoding;
            Props = props;
        }

        public static Instruction Empty => default;
    }
}
