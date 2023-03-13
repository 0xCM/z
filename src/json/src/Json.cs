//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;
    using static JsonTypes;
    using static JsonValues;

    [ApiHost]
    public partial class Json
    {
        const NumericKind Closure = UInt64k;

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

        [Op, Closures(Closure)]
        public static string serialize<T>(T src, bool indented = true)
            => JsonSerializer.Serialize(src, new JsonSerializerOptions{
                IncludeFields= true,
                WriteIndented = indented
            });

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonText jtext<T>(JsonSeq<T> src)
            where T : IJsonValue, new()
            => new (format(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static string format<T>(JsonSeq<T> src)
            where T : IJsonValue, new()
                => src.Content?.ToString() ?? EmptyString;

        static IEnumerable<FieldInfo> SettingFields<S>()
            => typeof(S).InstanceFields();

        public static JsonArray<T> array<T>(params T[] src)
            where T : IJsonValue, new()
                => new JsonArray<T>(src);
                        
        public static JsonStream stream(StreamReader src)
            => new JsonStream(src);
            
        public static JsonArray<T> array<T>(IEnumerable<T> src)
            where T : IJsonValue, new()
                => new JsonArray<T>(src.Array());

        public static JsonEmitter emitter(ITextEmitter dst)
            => new JsonEmitter(dst);

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
    }
}