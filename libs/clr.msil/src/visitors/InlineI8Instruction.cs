// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class InlineI8Instruction : ILInlineInstruction
    {
        public InlineI8Instruction(int offset, OpCode opCode, long value)
            : base(offset, opCode)
        {
            Value = value;
        }

        public readonly long Value;

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineI8Instruction(this);
    }
}