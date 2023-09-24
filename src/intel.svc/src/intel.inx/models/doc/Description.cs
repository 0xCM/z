//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class IntrinsicsDoc
{
    public readonly record struct Description
    {
        public const string ElementName = "description";

        public readonly @string Content;

        [MethodImpl(Inline)]
        public Description(string src)
        {
            Content = text.despace(src.Replace('\t', ' '));
        }

        public bool IsEmpty
        {
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            get => Content.IsNonEmpty;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Content;

        [MethodImpl(Inline)]
        public static implicit operator Description(string src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator string(Description src)
            => src.Content;
    }
}
