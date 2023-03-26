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

    public abstract class JsonTraverser<T>
        where T : JsonTraverser<T>
    {
        public static void traverse(JsonDocument src, T dst)
        {
            dst.Traverse(src.RootElement);
        }

        public virtual void Traversed(JsonObject src) {}

        void Traverse(JsonObject src) 
        {
            iter(src, Traverse);
        }

        void Traverse(JsonArray src) 
        {

        }

        void Traverse(JsonElement src)
        {
            switch(src.ValueKind)
            {
                case JsonValueKind.Object:
                    iter(src.EnumerateObject(), Traverse);
                break;
                case JsonValueKind.Array:
                    iter(src.EnumerateArray(), Traverse);
                break;
                case JsonValueKind.String:
                    Traverse(src.GetString());
                break;
                case JsonValueKind.False:
                    Traverse(src.GetBoolean());
                break;
                case JsonValueKind.True:
                    Traverse(src.GetBoolean());
                break;
                case JsonValueKind.Null:
                break;
                case JsonValueKind.Number:
                    
                break;
            }

        }


        void Traverse(string src)
        {

        }

        void Traverse(bool src)
        {
            
        }

        void Traverse(KeyValuePair<string,JsonNode> src) 
        {   
            
        }

        void Traverse(JsonProperty src) 
        {
            

        }

    }
    [ApiHost]
    public partial class Json
    {
        const NumericKind Closure = UInt64k;

        [Op, Closures(Closure)]
        public static JsonDocument document(ReadOnlySeq<byte> src)
            => JsonDocument.Parse(src.Storage);

        [Op, Closures(Closure)]
        public static JsonDocument document(FilePath src)
            => JsonDocument.Parse(src.ReadBytes());

        [Op, Closures(Closure)]
        public static JsonDocument document<T>(T src)
            => JsonSerializer.SerializeToDocument(src, options());

        public static Utf8JsonReader reader(ReadOnlySpan<byte> src)
            => new Utf8JsonReader(src);

        public static Utf8JsonReader reader(FilePath src)
            => reader(src.ReadBytes());

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
            return JsonConverters.coverters(options);
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
            where T : new()
                => new JsonArray<T>(src);
                        
        public static JsonArray<T> array<T>(IEnumerable<T> src)
            where T : new()
                => new JsonArray<T>(src.Array());

        public static JsonEmitter emitter(ITextEmitter dst)
            => new JsonEmitter(dst, options());

        [Op, Closures(Closure)]
        public static Utf8JsonWriter writer(Stream stream, JsonOptions options)
            => new Utf8JsonWriter(stream, options.Writer);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonProp<T> prop<T>(string name, T value)
            where T : new()
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
    }
}