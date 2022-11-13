//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct SearchPattern
    {
        public static SearchPattern Recurse = "/**/*";
        
        public readonly @string Content;

        [MethodImpl(Inline)]
        public SearchPattern(string src)
        {
            Content = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator SearchPattern(string src)
            => new SearchPattern(src);

        public string Format()
            => Content;

        public override string ToString()
            => Format();


        [MethodImpl(Inline)]
        public static SearchPattern operator+(SearchPattern a, SearchPattern b)
            => new SearchPattern(a.Content + b.Content);
    }
}