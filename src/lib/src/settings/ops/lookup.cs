//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Settings
    {
        public static SettingLookup<T> lookup<T>(T src)
            where T : new()
                => new (typeof(T).PublicInstanceFields().Select(f => new Setting(f.Name, f.GetValue(src))));
 
        public static SettingLookup lookup(FilePath src, char sep)
        {
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            var quoted = new Fence<AsciCode>(AsciCode.SQuote, AsciCode.SQuote);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var value = Asci.format(SQ.right(content,i));
                        dst.Add(new Setting(name, value));
                    }
                }
            }
            return new SettingLookup(dst.ToArray());
        } 
    }
}