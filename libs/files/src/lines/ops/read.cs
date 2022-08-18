//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    partial class Lines
    {
        [Op]
        public static ReadOnlySpan<TextLine> read(string src, bool keepblank = false, bool trim = true)
        {
            var lines = list<TextLine>();
            var lineNumber = 0u;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(blank(next))
                    {
                        if(keepblank)
                            lines.Add(new TextLine(++lineNumber, next));
                    }
                    else
                        lines.Add(new TextLine(++lineNumber, trim ? text.trim(next) : next));

                    next = reader.ReadLine();
                }
            }
            return lines.ViewDeposited();
        }
    }
}