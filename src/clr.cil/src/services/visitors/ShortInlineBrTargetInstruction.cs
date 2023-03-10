// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class ShortInlineBrTargetInstruction : ILInlineInstruction
    {
        public ShortInlineBrTargetInstruction(int offset, OpCode opCode, sbyte delta)
            : base(offset, opCode)
        {
            Delta = delta;
        }

        public readonly sbyte Delta;

        public int TargetOffset
            => Offset + Delta + 1 + 1;

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitShortInlineBrTargetInstruction(this);
    }
}