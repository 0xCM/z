//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Settings
    {
        public static CfgEntries cfg(FilePath src)
        {
            var dst = list<CfgEntry>();
            using var reader = src.Utf8LineReader();
            var line = TextLine.Empty;
            while(reader.Next(out line))
            {
                var i = line.Index('=');
                if(i > 0)
                {
                    var name = text.left(line.Content, i);
                    var value = text.right(line.Content,i);
                    dst.Add(new (name,value));
                }
            }
            return new (dst.ToArray());
        }
    }
}