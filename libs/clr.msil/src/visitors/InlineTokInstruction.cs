// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class InlineTokInstruction : ILInlineInstruction
    {
        readonly ICilTokenResolver _resolver;

        MemberInfo _member;

        public InlineTokInstruction(int offset, OpCode opCode, int token, ICilTokenResolver resolver)
            : base(offset, opCode)
        {
            _resolver = resolver;
            Token = token;
        }

        public MemberInfo Member 
            => _member ?? (_member = _resolver.AsMember(Token));

        public readonly int Token;

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineTokInstruction(this);
    }
}