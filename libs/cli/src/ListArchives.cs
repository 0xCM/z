//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class ListArchives
    {
        public delegate Outcome<T> ItemParser<T>(string src);

        public static ItemList<uint,string> load(FS.FilePath src, WfEmit channel)
            => load(src, trim, channel);

        public static ItemList<uint,T> load<T>(FS.FilePath src, ItemParser<T> parser, WfEmit channel)
        {
            var dst = list<ListItem<uint,T>>();
            var counter = 0u;
            var result = Outcome<T>.Empty;
            var line = EmptyString;
            using var reader = src.Utf8Reader();
            while(true)
            {
                line = reader.ReadLine();
                if(empty(line))
                    break;
                
                result = parser(line);
                if(result)
                {
                    dst.Add((counter++, result.Data));
                }
                else
                {
                    channel.Error(result.Message);
                    break;
                }                                
            }
            return dst.Array();            
        }

        static Outcome<string> trim(string src)
            => text.trim(src);
    }
}