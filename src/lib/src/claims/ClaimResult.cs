//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClaimResult
    {
        [MethodImpl(Inline)]
        public static ClaimResult success(ClaimKind kind)
            => new ClaimResult(kind, true, TextBlock.Empty);

        public static ClaimResult failure(ClaimKind kind, TextBlock message)
            => new ClaimResult(kind, false, message);

        public ClaimKind Claim {get;}

        public bool Success {get;}

        public TextBlock Message {get;}

        [MethodImpl(Inline)]
        public ClaimResult(ClaimKind claim, bool success, TextBlock message)
        {
            Claim = claim;
            Success = success;
            Message = message;
        }
    }
}