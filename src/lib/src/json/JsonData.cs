//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;
    using System.Globalization;
    using System.Linq;
    
    using static Chars;
    
    partial class XTend
    {
        public static Utf8JsonWriter JsonWriter(this Stream src, bool indented = true)
            => JsonData.writer(src, indented);
    }

    [ApiHost]
    public readonly struct JsonData
    {
        const NumericKind Closure = UInt64k;

        [Op, Closures(Closure)]
        public static Utf8JsonWriter writer(Stream stream, bool indented = true)
            => new Utf8JsonWriter(stream, new JsonWriterOptions{Indented = indented});

        [Op, Closures(Closure)]
        public static JsonText serialize<T>(T src, FileUri dst, bool indented = true)
        {
            var data = serialize(src, indented);
            using var writer = dst.Utf8Writer();
            writer.Write(data);
            return data;
        }

        [Op, Closures(Closure)]
        public static string serialize<T>(T src, bool indented = true)
            => JsonSerializer.Serialize(src);

        [Op, Closures(Closure)]
        public static JsonDocument parse(ReadOnlySeq<byte> src)
            => JsonDocument.Parse(src.Storage);
            
        [Op, Closures(Closure)]
        public static JsonDocument document<T>(T src, bool indented = true)
            => JsonSerializer.SerializeToDocument(src, new JsonSerializerOptions{WriteIndented = indented, AllowTrailingCommas = true});

        [Op, Closures(Closure)]
        public static T materialize<T>(JsonText src)
        {
            var packet = JsonSerializer.Deserialize<JsonPacket<T>>(src);
            return packet.Content;
        }

        [Op, Closures(Closure)]
        public static T materialize<T>(FileUri src)
        {
            using var reader = src.Utf8Reader();
            var data = reader.ReadToEnd();
            return materialize<T>(data);
        }

        public static T materialize2<T>(FilePath src)
            where T : new()
        {
            var kvp = new Dictionary<string,string>();
            var dst = new T();
            var fields = typeof(T).GetFields(BindingFlags.Instance).Select(x => (x.Name, x)).ToDictionary();
            absorb(src, kvp);
            foreach(var key in kvp.Keys)
            {
                if(fields.TryGetValue(key, out FieldInfo f))
                {
                    var dstType = f.FieldType;
                    Option.Try(() => Convert.ChangeType(kvp[key], dstType)).OnSome(value => f.SetValue(dst,value));
                }
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static JsonText json(string src)
            => new JsonText(src);

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static Json<T> json<T>(T[] src)
            => new Json<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonText jtext<T>(Json<T> src)
            => json(format(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string format<T>(Json<T> src)
            => src.Content?.ToString() ?? EmptyString;

        public static ISettingsAdapter<T> Adapt<T>(IJsonSettings src)
            where T : ISettingsAdapter<T>, new()
        {
            var adapter = new T();
            return adapter.Adapt(src);
        }

        public static FilePath path(Assembly src)
            => FS.path(src.Location).FolderPath + FS.file(src.GetSimpleName(), FS.JsonSettings);

        public static IJsonSettings settings(Assembly src)
            => settings(path(src));

        public static IJsonSettings settings(FileUri src)
        {
            var dst = new Dictionary<string,string>();
            if(src.Exists)
            {
                absorb(src, dst);
                return new JsonSettings(dst.Map(kvp => (kvp.Key, kvp.Value)));
            }
            else
            {
                return JsonSettings.Empty;
            }
        }

        public static void save(SettingLookup src, FileUri dst)
        {
            const string indent = "    ";

            var settings = src.View;
            if(settings.Length != 0)
            {
                using var writer = dst.Utf8Writer();
                writer.WriteLine(LBrace);
                for(var i = 0; i<settings.Length; i++)
                {
                    var line = indent + settings[i].Json();
                    if(i != settings.Length - 1)
                        line += Chars.Comma;
                    writer.WriteLine(line);
                }
                writer.WriteLine(RBrace);
            }
        }

        public static S load<S>(IJsonSettings src)
            where S : new()
        {
            var dst = new S();
            foreach(var name in SettingNames<S>())
                src.Setting(name).OnSome(value => WriteSetting(name, value, dst));
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonPacket<T> packet<T>(T src)
            => src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonSetting<T> setting<T>(string name, T value)
            => new JsonSetting<T>(name, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonSetting setting(string name, string value)
            => new JsonSetting(name, value);

        public static string format(JsonSetting src)
            => JsonSerializer.Serialize(src);

        public static string format<T>(JsonSetting<T> src)
            => JsonSerializer.Serialize(src);

        static void absorb(FileUri src, Dictionary<string,string> dst)
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

        public static IEnumerable<Setting> Settings<S>(object src)
            => PropSettings<S>(src).Union(FieldSettings<S>(src));

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        public static bool parse(string src, NumberStyles style, out char dst)
        {
            var result = parse(src, style, out int value);
            try
            {
                dst = Convert.ToChar(value);
            }
            catch(Exception)
            {
                dst = default;
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        public static bool parse(string value, NumberStyles style, out int dst)
            => int.TryParse(value, style, NumberFormatInfo.InvariantInfo, out dst);

        static Option<S> WriteSetting<S>(string name, string value, S dst)
        {
            try
            {
                var wf = from p in typeof(S).Property(name)
                         let v = Convert.ChangeType(value, p.PropertyType)
                         from r in p.Write(v, dst)
                         select (S)r;
                return wf;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e);
                return Option.none<S>();
            }
        }

        static IEnumerable<FieldInfo> SettingFields<S>()
            => typeof(S).InstanceFields();

        static IEnumerable<PropertyInfo> SettingProperties<S>()
            => from p in typeof(S).InstanceProperties()
                where p.HasPublicGetter() && p.HasPublicSetter()
                select p;

        static IEnumerable<MemberInfo> SettingMembers<S>()
            => SettingProperties<S>().Cast<MemberInfo>().Union(SettingFields<S>());

        static IEnumerable<string> SettingNames<S>()
            => SettingMembers<S>().Select(m => m.Name);

        static IEnumerable<Setting> PropSettings<S>(object src)
            => SettingProperties<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));

        static IEnumerable<Setting> FieldSettings<S>(object src)
            => SettingFields<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));
    }
}