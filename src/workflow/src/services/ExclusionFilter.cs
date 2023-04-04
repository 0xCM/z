//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public record struct ExclusionFilter
    {
        public readonly ReadOnlySeq<string> Patterns;

        public ExclusionFilter(params string[] patterns)
        {
            Patterns = patterns;
        }

        public static ExclusionFilter create(params string[] patterns)
            => new ExclusionFilter(patterns);        
    }
}