//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;
    
    partial class Json
    {
        [Op, Closures(Closure)]
        public static JsonText serialize<T>(T src, FileUri dst)
        {
            var data = serialize(src);
            using var writer = dst.Utf8Writer();
            writer.Write(data);
            return data;
        }

        [Op, Closures(Closure)]
        public static string serialize<T>(T src)
            => JsonSerializer.Serialize(src, JsonOptions.Default.Serializer);

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
    }
}