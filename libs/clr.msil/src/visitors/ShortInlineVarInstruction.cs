// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class ShortInlineVarInstruction : ILInlineInstruction
    {
        public ShortInlineVarInstruction(int offset, OpCode opCode, byte ordinal)
            : base(offset, opCode)
        {
            Ordinal = ordinal;
        }

        public byte Ordinal { get; }

        public override void Accept(ILInstructionVisitor visitor) => visitor.VisitShortInlineVarInstruction(this);
    }
}