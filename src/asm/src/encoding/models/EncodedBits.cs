//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static AsmOpCodes;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public record struct EncodedBits
{
    public RepPrefix Rep;

    public LockPrefix Lock;

    public SizeOverride OPSZ;

    public SizeOverride ADSZ;

    public RexPrefix Rex;

    public VexPrefix Vex;

    public EvexPrefix Evex;

    public OpCodeValue OpCode;

    public ModRm ModRm;

    public Sib Sib;

    public Disp Disp;

    public Imm Imm;
}
