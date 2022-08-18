//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct ClaimResult<A0,A1>
    {
        public Identifier Identifier;

        public readonly ClaimOperator Claim;

        public OutputValue<A0> Arg0;

        public OutputValue<A1> Arg1;

        public bool Success;

        public TextBlock Message;

        [MethodImpl(Inline)]
        public ClaimResult(Identifier identifier, ClaimKind claim, bool success, string message, A0 a, A1 b)
        {
            Identifier = identifier;
            Claim = claim;
            Success = success;
            Message = message;
            Arg0 = a;
            Arg1 = b;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(Identifier, Claim, Success, Message, Arg0, Arg1);

        public override string ToString()
            => Format();
    }
}