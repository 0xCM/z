//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly record struct ListItem : IContented<ListItem,string>, ILeveled
        {
            public readonly Level Level;

            public readonly string Content;

            public ListItem(Level level, string content)
            {
                Level = level;
                Content = content;
            }

            string IContented<string>.Content
                => Content;

            Level ILeveled.Level
                => Level;

            public string Format()
                => string.Format("{0} {1}", Level, Content);

            public override string ToString()
                => Format();
        }
    }
}