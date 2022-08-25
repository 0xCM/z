//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public readonly struct LlvmIdentifiers
    {
        public static ListItem<T,string>[] discover<T>(FilePath header, string marker)
            where T : unmanaged
        {
            var items = list<ListItem<T,string>>();
            using var reader = header.Utf8LineReader();
            var parsing = false;
            while(reader.Next(out var line))
            {
                if(parsing)
                {
                    if(enumliteral<T>(line.Content, out var literal))
                        items.Add(literal);
                    else
                        break;
                }
                else
                {
                    if(line.Contains(marker))
                    {
                        parsing = true;
                        if(definesliteral(marker))
                        {
                            if(enumliteral<T>(marker, out var first))
                                items.Add(first);
                        }
                        else
                            items.Add((zero<T>(), text.remove(marker, Chars.Comma)));
                    }
                }
            }
            return items.ToArray();
        }

        static bool enumliteral<T>(string src, out ListItem<T,string> dst)
            where T : unmanaged
        {
            if(definesliteral(src))
            {
                var i = text.index(src, Chars.Eq);
                var name = text.left(src,i).Trim();
                var idtext = text.remove(text.right(src,i),Chars.Comma).Trim();
                DataParser.numeric(idtext, out ushort id);
                dst = (generic<T>(id),name);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        static bool definesliteral(string src)
            => src.Contains(Chars.Eq) && src.Trim().EndsWith(Chars.Comma);
    }
}