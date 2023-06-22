//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    
    partial class XedModels
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct Instruction
        {
            public readonly InstructionId Id;

            public readonly asci64 Asm;

            public readonly XedInstClass Class;

            public readonly XedInstForm Form;

            public readonly InstFieldValues Props;

            [MethodImpl(Inline)]
            public Instruction(InstructionId id, asci64 asm, XedInstClass @class, XedInstForm form, InstFieldValues props)
            {
                Id = id;
                Asm = asm;
                Class = @class;
                Form = form;
                Props = props;
            }

            public static Instruction Empty => new Instruction(InstructionId.Empty, asci64.Null, XedInstClass.Empty, XedInstForm.Empty, InstFieldValues.Empty);
        }
    }
}