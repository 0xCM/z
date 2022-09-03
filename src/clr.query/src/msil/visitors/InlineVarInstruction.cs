// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class InlineVarInstruction : ILInlineInstruction
    {
        public InlineVarInstruction(int offset, OpCode opCode, ushort ordinal)
            : base(offset, opCode)
        {
            Ordinal = ordinal;
        }

        public readonly ushort Ordinal;

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineVarInstruction(this);
    }
}