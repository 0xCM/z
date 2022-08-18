//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Text.Json;

    using static Algs;
    using static Spans;
    using static Arrays;

    public class JsonSettings : IJsonSettings
    {
        public static FS.FilePath path(Assembly src)
            => FS.path(src.Location).FolderPath + FS.file(src.GetSimpleName(), FS.JsonSettings);

        public static IJsonSettings load(Assembly src)
            => load(path(src));

        public static IJsonSettings load(FS.FilePath src)
        {
            var dst = new Dictionary<string,string>();
            if(src.Exists)
            {
                absorb(src, dst);
                return new JsonSettings(src, dst.Map(kvp => (kvp.Key, kvp.Value)));
            }
            else
            {
                return JsonSettings.Empty;
            }
        }

        static void absorb(FS.FilePath src, Dictionary<string,string> dst)
        {
            var settings = new Dictionary<string,string>();
            var ignore = new char[]{Chars.Quote, Chars.Comma};
            if(src.Exists)
            {
                var lines = src.ReadLines().Select(l => l.Trim().RemoveAny(ignore));
                foreach(var line in lines)
                {
                    var parts = line.SplitClean(Chars.Colon);
                    if(parts.Length == 2)
                    {
                        var key = parts[0].Trim();
                        var value = parts[1].Trim();
                        dst.TryAdd(key,value);
                    }
                }
            }
        }

        public JsonSettings(FS.FilePath src, IEnumerable<(string,string)> pairs)
        {
            SourcePath = src;
            Pairs = pairs.Select(pair => new KeyValuePair<string, string>(pair.Item1, pair.Item2)).ToArray();
        }

        public JsonSettings(FS.FilePath src, IEnumerable<KeyValuePair<string,string>> pairs)
        {
            SourcePath = src;
            Pairs = pairs.ToArray();
        }

        public FS.FilePath SourcePath {get;}

        IEnumerable<KeyValuePair<string,string>> Pairs {get;}

        public Option<string> Setting(string name)
        {
            var matches = Pairs.Where(p => p.Key == name).ToArray();
            if(matches.Length == 0)
                return Option.none<string>();
            else
                return matches[0].Value;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public IEnumerable<ISetting> All
            => from p in Pairs select new Setting(p.Key, p.Value) as ISetting;

        public string this[string name]
            => Setting(name).ValueOrDefault(string.Empty);

        static string format<S>(S src)
            where S : IJsonSettings
        {
            var dst = text.buffer();
            var settings = @readonly(src.All.Array());
            var count = settings.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                var value = JsonSerializer.Serialize(setting.Value);
                dst.AppendFormat("{0}: {1}", setting.Name, value);
                if(i != count - 1)
                    dst.Append(Chars.Comma);
                dst.AppendLine();
            }

            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

        public static IJsonSettings Empty
            => new JsonSettings(FS.FilePath.Empty, new KeyValuePair<string,string>[]{});
    }
}