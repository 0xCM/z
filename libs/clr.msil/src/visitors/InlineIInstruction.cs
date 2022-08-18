// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class InlineIInstruction : ILInlineInstruction
    {
        public InlineIInstruction(int offset, OpCode opCode, int value)
            : base(offset, opCode)
        {
            Value = value;
        }

        public readonly int Value;

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineIInstruction(this);
    }
}