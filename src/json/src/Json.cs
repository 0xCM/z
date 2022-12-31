//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    [ApiHost]
    public partial class Json
    {
        const NumericKind Closure = UInt64k;

        

        [Op, Closures(Closure)]
        public static string serialize<T>(T src, bool indented = true)
            => JsonSerializer.Serialize(src, new JsonSerializerOptions{
                IncludeFields= true,
                WriteIndented = indented
            });

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonText jtext<T>(JsonSeq<T> src)
            => new (format(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static string format<T>(JsonSeq<T> src)
            => src.Content?.ToString() ?? EmptyString;

        static IEnumerable<FieldInfo> SettingFields<S>()
            => typeof(S).InstanceFields();

        public static JsonArray<T> array<T>(T[] src)
            where T : IJsonRender
                => new JsonArray<T>(src);
                        
        public static JsonStream stream(StreamReader src)
            => new JsonStream(src);
            
        public static JsonArray<T> array<T>(IEnumerable<T> src)
            where T : IJsonRender
                => new JsonArray<T>(src.Array());

        public static IJsonEmitter emitter(ITextEmitter dst)
            => new JsonEmitter(dst);

        [Op, Closures(Closure)]
        public static Utf8JsonWriter writer(Stream stream, JsonOptions options)
            => new Utf8JsonWriter(stream, options.Writer);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonProp<T> prop<T>(string name, T value)
            where T : IEquatable<T>
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