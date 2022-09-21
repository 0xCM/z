//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public class ReplaceRule<T> : IRuleExpr
    {
        /// <summary>
        /// The sequence term to match
        /// </summary>
        public readonly T Match;

        /// <summary>
        /// The replacement value when matched
        /// </summary>
        public readonly T Replace;

        [MethodImpl(Inline)]
        public ReplaceRule(T match, T replace)
        {
            Match = match;
            Replace = replace;
        }

        public string Format()
            => string.Format("{0} -> {1}", Match, Replace);

        public override string ToString()
            => Format();
    }    
}