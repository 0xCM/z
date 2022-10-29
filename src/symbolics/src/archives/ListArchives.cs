//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ListArchives
    {
        public delegate Outcome<T> ItemParser<T>(string src);

        public static ItemList<uint,string> load(IWfChannel channel, FilePath src)
            => load(channel, src, trim);

        public static ItemList<uint,T> load<T>(IWfChannel channel, FilePath src, ItemParser<T> parser)
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