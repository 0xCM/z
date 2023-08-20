//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Asm.IceOpKind;

    using BTK = BranchTargetKind;
    using BTW = BranchTargetWidth;

    partial struct IceConverters
    {
        [MethodImpl(Inline), Op]
        static Disp64 disp64(MemoryAddress src, byte instsize, MemoryAddress dst)
            => (long)(dst - (src + instsize));

        [MethodImpl(Inline), Op]
        public static AsmBranchTarget target(BranchTargetKind kind, MemoryAddress dst, BranchTargetWidth size, Address16 selector)
            => new (dst, kind, size, selector);

        [MethodImpl(Inline), Op]
        public static AsmBranchTarget target(BranchTargetKind kind, MemoryAddress dst, BranchTargetWidth size)
            => new (dst,kind, size);

        [MethodImpl(Inline), Op]
        public static AsmBranchInfo branch(MemoryAddress @base, in IceInstruction src, in AsmBranchTarget target)
            => new (@base, src.IP, target, (MemoryAddress)(long)disp64(src.IP, (byte)src.ByteLength, target.Address));

        [MethodImpl(Inline), Op]
        public static AsmBranchInfo branch(MemoryAddress @base, in IceInstruction src, byte index)
            => branch(@base, src, branch(src, index));

        [Op]
        public static AsmBranchTarget branch(in IceInstruction src, byte index)
        {
            var k = opkind(src, index);
            switch(k)
            {
                case NearBranch16:
                    return target(BTK.Near, (uint)src.NearBranch16, BTW.Branch16);
                case NearBranch32:
                    return target(BTK.Near, src.NearBranch32, BTW.Branch32);
                case NearBranch64:
                    return target(BTK.Near, src.NearBranch64, BTW.Branch64);
                case FarBranch16:
                    return target(BTK.Far, (uint)src.FarBranch16, BTW.Branch16, (Address16)src.FarBranchSelector);
                case FarBranch32:
                    return target(BTK.Far, src.FarBranch32, BTW.Branch32, (Address16)src.FarBranchSelector);
            }
            return AsmBranchTarget.Empty;
        }
    }
}