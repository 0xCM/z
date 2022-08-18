//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class IntrinsicsDoc
    {
        public readonly record struct Category
        {
            public const string ElementName = "category";

            public readonly string Content;

            [MethodImpl(Inline)]
            public Category(string src)
            {
                Content = src;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => nonempty(Content);
            }

            public string Format()
                => Content;

            public override string ToString()
                => Content;

            [MethodImpl(Inline)]
            public static implicit operator Category(string src)
                => new Category(src);

            [MethodImpl(Inline)]
            public static implicit operator string(Category src)
                => src.Content;
        }

    }

}