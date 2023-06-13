//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TextLine<T>
        where T : IEquatable<T>
    {
        public readonly LineNumber LineNumber;

        public readonly T Content;

        [MethodImpl(Inline)]
        public TextLine(uint number, T content)
        {
            LineNumber = number;
            Content = content;
        }

        public bool Equals(TextLine<T> src)
            => Content.Equals(src.Content) && LineNumber == src.LineNumber;

        public int CompareTo(TextLine<T> src)
            => LineNumber.CompareTo(src.LineNumber);
    }
}