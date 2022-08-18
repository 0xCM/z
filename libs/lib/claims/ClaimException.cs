//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Raised when a validation check has failed
    /// </summary>
    public class ClaimException : Exception
    {
        public static ClaimException define(ClaimKind op, TextBlock msg)
            => new ClaimException(op, msg);

        public ClaimException() { }

         ClaimException(ClaimKind kind, TextBlock msg)
            : base(msg.Format())
            {
                OpKind = kind;
            }

        public ClaimKind OpKind {get;}
    }
}