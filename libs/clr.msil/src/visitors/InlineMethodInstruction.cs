// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class InlineMethodInstruction : ILInlineInstruction
    {
        readonly ICilTokenResolver _resolver;

        MethodBase _method;

        public readonly int Token;

        public InlineMethodInstruction(int offset, OpCode opCode, int token, ICilTokenResolver resolver)
            : base(offset, opCode)
        {
            _resolver = resolver;
            Token = token;
        }


        public MethodBase Method
            => _method ?? (_method = _resolver.AsMethod(Token));


        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineMethodInstruction(this);
    }
}