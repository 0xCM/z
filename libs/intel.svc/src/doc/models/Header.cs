//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntrinsicsDoc
    {
        public readonly record struct Header
        {
            public const string ElementName = "header";

            public readonly string Content;

            [MethodImpl(Inline)]
            public Header(string src)
            {
                Content = src;
            }

            public string Format()
                => Content;

            public override string ToString()
                => Content;

            [MethodImpl(Inline)]
            public static implicit operator Header(string src)
                => new Header(src);
        }
    }
}