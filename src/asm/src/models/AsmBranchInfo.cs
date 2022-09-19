//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Describes a branching instruction operand
    /// </summary>
    public struct AsmBranchInfo
    {
        public MemoryAddress Base;

        public MemoryAddress Source;

        public AsmBranchTarget Target;

        public MemoryAddress TargetOffset;

        [MethodImpl(Inline)]
        public AsmBranchInfo(MemoryAddress @base, MemoryAddress src, in AsmBranchTarget target, MemoryAddress offset)
        {
            Base = @base;
            Source = src;
            Target = target;
            TargetOffset = offset;
        }
    }
}