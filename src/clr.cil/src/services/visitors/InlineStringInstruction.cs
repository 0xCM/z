// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class InlineStringInstruction : ILInlineInstruction
    {
        readonly ICilTokenResolver _resolver;

        string _string;

        public InlineStringInstruction(int offset, OpCode opCode, int token, ICilTokenResolver resolver)
            : base(offset, opCode)
        {
            _resolver = resolver;
            Token = token;
        }

        public string String => _string ?? (_string = _resolver.AsString(Token));
        public readonly int Token;

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineStringInstruction(this);
    }
}