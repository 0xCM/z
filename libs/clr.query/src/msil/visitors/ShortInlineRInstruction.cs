// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class ShortInlineRInstruction : ILInlineInstruction
    {
        public ShortInlineRInstruction(int offset, OpCode opCode, float value)
            : base(offset, opCode)
        {
            Value = value;
        }

        public readonly float Value;

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitShortInlineRInstruction(this);
    }
}