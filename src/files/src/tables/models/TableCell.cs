//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableCell : ITextual
    {
        public readonly object Content;

        [MethodImpl(Inline)]
        public TableCell(object content)
        {
            Content = content;
        }

        public string Format()
            => Content != null ? Content.ToString() : RP.Null;

        public override string ToString()
            => Format();
    }
}