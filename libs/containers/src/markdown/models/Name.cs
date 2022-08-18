//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct Name : IContented<Name,string>
        {
            public readonly string Content;

            [MethodImpl(Inline)]
            public Name(string src)
            {
                Content = src;
            }

            public string Format()
                => Content;

            string IContented<string>.Content
                => Content;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Name(string src)
                => new Name(src);
        }
    }
}