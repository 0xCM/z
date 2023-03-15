//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    using static JsonTypes;
    using static JsonValues;
    using static sys;

    [ApiHost]
    public partial class Json
    {
        const NumericKind Closure = UInt64k;

        [Op, Closures(Closure)]
        public static JsonDocument document(ReadOnlySeq<byte> src)
            => JsonDocument.Parse(src.Storage);
            
        [Op, Closures(Closure)]
        public static JsonDocument document<T>(T src)
            => JsonSerializer.SerializeToDocument(src, options());

        public static void render<T>(JsonArray<T> src, JsonEmitter dst)
            where T : IJsonValue, new()
        {
            dst.OpenArray();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i != count - 1)
                    dst.Delimit();
            }
            dst.CloseArray();
        }

        public static void register(IEnumerable<JsonConverter> src)
            => Converters.AddRange(src);

        public static void register(params JsonConverter[] src)
            => Converters.AddRange(src);

        public static JV<Record,T> record<T>(in T src)
            where T : new()
                => src;

        public static JV<Records,JsonArray<T>> records<T>(params T[] src)
            where T : IJsonValue, new()
                => array(src);
                
        public static string format(IJsonValue src)
            => $"{src.Content}";

        public static bool empty(IJsonValue src)
            => src.Content is null || (src.Content is @string s && s == @string.Empty);

        public static IJsonType type(IJsonValue value)
        {
            throw new NotImplementedException();
        }

        [Op]
        public static JV<I8,sbyte> i8(sbyte value)
            => value;

        [Op]
        public static JV<U8,byte> u8(byte value)
            => value;

        [Op]
        public static JV<U8,short> i16(short value)
            => value;

        [Op]
        public static JV<U8,ushort> u16(ushort value)
            => value;

        [Op]
        public static JV<U8,int> i32(int value)
            => value;

        [Op]
        public static JV<U8,uint> u32(uint value)
            => value;

        [Op]
        public static JV<U8,long> i64(long value)
            => value;

        [Op]
        public static JV<U8,ulong> u64(ulong value)
            => value;

        [Op]
        public static JV<U8,Date> date(Date value)
            => value;

        [Op]
        public static JV<U8,Time> time(Time value)
            => value;        

        public static JV<Text,JsonText> text(string value)
            => new JsonText(value);

        public static JsonSerializerOptions options()
        {
            var options = new JsonSerializerOptions{
                WriteIndented = true,
                IncludeFields = true,
                AllowTrailingCommas = true,
                IgnoreReadOnlyFields = false                
            };
            iter(Converters, converter => options.Converters.Add(converter));
            return options;
        }

        [Op, Closures(Closure)]
        public static T materialize<T>(string src)
            => JsonSerializer.Deserialize<T>(src, JsonOptions.Default.Serializer);

        [Op, Closures(Closure)]
        public static T materialize<T>(FileUri src)
        {
            using var reader = src.Utf8Reader();
            var data = reader.ReadToEnd();
            return materialize<T>(data);
        }

        public static T materialize2<T>(FileUri src)
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

        [Op, Closures(Closure)]
        public static string serialize<T>(T src)
            => JsonSerializer.Serialize(src, options());

        public static JsonArray<T> array<T>(params T[] src)
            where T : IJsonValue, new()
                => new JsonArray<T>(src);
                        
        public static JsonArray<T> array<T>(IEnumerable<T> src)
            where T : IJsonValue, new()
                => new JsonArray<T>(src.Array());

        public static JsonEmitter emitter(ITextEmitter dst)
            => new JsonEmitter(dst, options());

        [Op, Closures(Closure)]
        public static Utf8JsonWriter writer(Stream stream, JsonOptions options)
            => new Utf8JsonWriter(stream, options.Writer);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonProp<T> prop<T>(string name, T value)
            where T : IJsonValue, new()
                => new (name,value);

        [MethodImpl(Inline), Op]
        public static JsonText json(string src)
            => new JsonText(src);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonText jtext<T>(T src)
            => json($"{src}");

        internal static void absorb(FileUri src, Dictionary<string,string> dst)
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
        
        static List<JsonConverter> Converters = new();

        class StringConverter : JsonConverter<@string>
        {
            public override @string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
                => reader.GetString();

            public override void Write(Utf8JsonWriter writer, @string src, JsonSerializerOptions options) 
                => writer.WriteStringValue(src);
        }        

        class FilePathConverter : JsonConverter<FilePath>
        {
            public override FilePath Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
                => FS.path(reader.GetString());

            public override void Write(Utf8JsonWriter writer, FilePath src, JsonSerializerOptions options) 
                => writer.WriteStringValue(src.Format(PathSeparator.FS));
        }        

        class FolderPathConverter : JsonConverter<FolderPath>
        {
            public override FolderPath Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
                => FS.dir(reader.GetString());

            public override void Write(Utf8JsonWriter writer, FolderPath src, JsonSerializerOptions options) 
                => writer.WriteStringValue(src.Format(PathSeparator.FS));
        }        

        static Json()
        {
            register(new StringConverter());
            register(new FilePathConverter());
            register(new FolderPathConverter());
        }
    }
}