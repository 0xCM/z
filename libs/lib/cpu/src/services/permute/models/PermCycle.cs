//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes cycle in a perutation
    /// </summary>
    public readonly struct PermCycle
    {
        /// <summary>
        /// The terms that define the cycle
        /// </summary>
        public readonly PermTerm[] Terms;

        public PermCycle(params PermTerm[] src)
        {
            var len = src.Length;
            if(len > 1)
                Require.invariant(src[0].Source == src[len - 1].Target, () => "Not equal");

            Terms = src;
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