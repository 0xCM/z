//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct EncodedBits
    {
        public RepPrefix Rep;

        public LockPrefix Lock;

        public SizeOverride OPSZ;

        public SizeOverride ADSZ;

        public RexPrefix Rex;

        public uint Vex;

        public EvexPrefix Evex;

        public AsmOcValue OpCode;

        public ModRm ModRm;

        public Sib Sib;

        public Disp Disp;

        public Imm Imm;
    }
}