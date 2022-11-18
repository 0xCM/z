//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Text.Json;

    using static sys;

    public class JsonSettings : IJsonSettings
    {
        public static string format<S>(S src)
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

        public JsonSettings(IEnumerable<(string,string)> pairs)
        {
            Pairs = pairs.Select(pair => new KeyValuePair<string, string>(pair.Item1, pair.Item2)).ToArray();
        }

        public JsonSettings(IEnumerable<KeyValuePair<string,string>> pairs)
        {
            Pairs = pairs.ToArray();
        }

        readonly ReadOnlySeq<KeyValuePair<string,string>> Pairs;

        public Option<string> Setting(string name)
        {
            var matches = Pairs.Where(p => p.Key == name).ToArray();
            if(matches.Length == 0)
                return Option.none<string>();
            else
                return matches[0].Value;
        }

        public bool IsEmpty
        {
            get => Pairs.Count == 0;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public string this[string name]
            => Setting(name).ValueOrDefault(string.Empty);

        public static IJsonSettings Empty
            => new JsonSettings(new KeyValuePair<string,string>[]{});

        ReadOnlySeq<ISetting> IJsonSettings.All 
            => Pairs.Map(p => (ISetting)new Setting(p.Key, p.Value)).ToSeq();
    }
}