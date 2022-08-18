//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Describes cycle in a perutation
    /// </summary>
    public readonly struct PermCycle<T>
        where T : unmanaged
    {
        public PermCycle(params PermTerm<T>[] src)
        {
            var len = src.Length;
            if(len > 1)
                Require.invariant(gmath.eq(src[0].Source, src[len - 1].Target), () => "no");

            Terms = src;
        }

        [MethodImpl(Inline)]
        public PermCycle(Span<PermTerm<T>> src)
        {
            Terms = src.ToArray();
        }

        /// <summary>
        /// The terms that define the cycle
        /// </summary>
        public readonly PermTerm<T>[] Terms;

        public int Length
        {
            [MethodImpl(Inline)]
            get => Terms.Length;
        }

        public string Format()
        {
            var sb = text.build();
            sb.Append(Chars.LParen);
            for(var i=0; i< Terms.Length; i++)
            {
                sb.Append(Terms[i].Source);
                if(i != Terms.Length - 1)
                    sb.Append(Chars.Space);
            }

            sb.Append(Chars.RParen);
            return sb.ToString();
        }

        public override string ToString()
            => Format();
    }
}