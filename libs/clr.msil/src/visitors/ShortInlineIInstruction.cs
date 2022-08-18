// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class ShortInlineIInstruction : ILInlineInstruction
    {
        public readonly sbyte Value;

        public ShortInlineIInstruction(int offset, OpCode opCode, sbyte value)
            : base(offset, opCode)
        {
            Value = value;
        }


        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitShortInlineIInstruction(this);
    }
}