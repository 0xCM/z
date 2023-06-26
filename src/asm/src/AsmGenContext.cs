//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmGenContext
    {

        RegOpRange RegOps;

        ImmOpRange ImmOps;

        public readonly SdmForm Form;

        public AsmGenContext()
        {

        }

        AsmGenContext(SdmForm form, RegOpRange regs, ImmOpRange imm)
        {
            Form = form;
            RegOps = regs;
            ImmOps = imm;
        }

        [MethodImpl(Inline)]
        public bool NextReg(out RegOp op)
            => RegOps.Next(out op);

        [MethodImpl(Inline)]
        public bool NextImm(out Imm op)
            => ImmOps.Next(out op);

    }
}