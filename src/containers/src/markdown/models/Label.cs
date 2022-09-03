//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct Label : IContented<Label,string>
        {
            public readonly string Content;

            [MethodImpl(Inline)]
            public Label(string src)
            {
                Content = src;
            }

            public string Format()
                => string.Format("[{0}]", Content);

            public override string ToString()
                => Format();

            string IContented<string>.Content
                => Content;

            [MethodImpl(Inline)]
            public static implicit operator Label(string src)
                => new Label(src);
        }
    }
}