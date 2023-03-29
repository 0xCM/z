//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ClaimResult<A>
    {
        public Identifier Identifier;

        public readonly ClaimOperator Claim;

        public OutputValue<A> Arg0;

        public bool Success;

        public TextBlock Message;

        [MethodImpl(Inline)]
        public ClaimResult(Identifier identifier, ClaimKind claim, bool success, string message, A a)
        {
            Identifier = identifier;
            Claim = claim;
            Arg0 = a;
            Success = success;
            Message = message;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(Identifier, Claim, Success, Message, Arg0);

        public override string ToString()
            => Format();
    }
}