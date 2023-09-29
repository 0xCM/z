//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public class AsmGenContext
{

    RegRange RegOps;

    ImmRange ImmOps;

    public readonly SdmForm Form;

    public AsmGenContext()
    {

    }

    AsmGenContext(SdmForm form, RegRange regs, ImmRange imm)
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
