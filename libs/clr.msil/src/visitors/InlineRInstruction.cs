// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class InlineRInstruction : ILInlineInstruction
    {
        public InlineRInstruction(int offset, OpCode opCode, double value)
            : base(offset, opCode)
        {
            Value = value;
        }

        public double Value { get; }

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineRInstruction(this);
    }
}