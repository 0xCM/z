//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct List : IElement<List>
        {
            public readonly Index<ListItem> Items;

            public readonly DepthIndicator Style;

            public List(Index<ListItem> items, DepthIndicator style)
            {
                Items = items;
                Style = style;
            }

            public string Format()
            {
                var dst = text.buffer();
                var count = Items.Count;
                for(var i=0; i<count; i++)
                    dst.AppendLine(Items[i]);
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}