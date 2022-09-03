// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public abstract class ILInlineInstruction
    {
        public readonly int Offset;
        
        public readonly OpCode OpCode;

        protected ILInlineInstruction(int offset, OpCode opCode)
        {
            Offset = offset;
            OpCode = opCode;
        }

        public abstract void Accept(ILInstructionVisitor visitor);
    }
}