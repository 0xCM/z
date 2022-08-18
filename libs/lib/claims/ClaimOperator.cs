//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClaimOperator : ITextual
    {
        public ClaimKind Kind {get;}

        [MethodImpl(Inline)]
        public ClaimOperator(ClaimKind kind)
            => Kind = kind;

        [MethodImpl(Inline)]
        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ClaimOperator(ClaimKind kind)
            => new ClaimOperator(kind);
    }
}