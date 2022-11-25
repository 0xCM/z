//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;
    using System.Globalization;
    using System.Linq;

    [ApiHost]
    public readonly struct JsonData
    {
        const NumericKind Closure = UInt64k;

        [Op, Closures(Closure)]
        public static string serialize<T>(T src, bool indented = true)
            => JsonSerializer.Serialize(src);

        [MethodImpl(Inline), Op]
        static JsonText json(string src)
            => new JsonText(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static JsonText jtext<T>(Json<T> src)
            => json(format(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static string format<T>(Json<T> src)
            => src.Content?.ToString() ?? EmptyString;

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        /// <param name="src">The json input</param>
        /// <param name="dst">Receives the unescaped text, if successful</param>
        internal static Outcome unescape(string src, out string dst)
        {
            dst = EmptyString;
            var result = Outcome.Success;
            if(src == null)
                return Outcome.fail(RP.Null);

            var buffer = new StringBuilder();
            int startIndex = 0, count = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == '\\')
                {
                    i++;

                    buffer.Append(src, startIndex, count);

                    if (i >= src.Length)
                    {
                        result = Outcome.fail(string.Format("{0}>={1}", i, src.Length));
                        break;
                    }

                    switch (src[i])
                    {
                        case '"':
                        case '\'':
                        case '/':
                        case '\\':
                            buffer.Append(src[i]);
                            break;
                        case 'b':
                            buffer.Append('\b');
                            break;
                        case 'f':
                            buffer.Append('\f');
                            break;
                        case 'n':
                            buffer.Append('\n');
                            break;
                        case 'r':
                            buffer.Append('\r');
                            break;
                        case 't':
                            buffer.Append('\t');
                            break;
                        case 'u':
                            if ((i + 3) >= src.Length)
                            {
                                result = Outcome.fail(string.Format("{0} + 3 >={1}", i, src.Length));
                                break;
                            }

                            result = parse(src.Substring(i + 1, 4), NumberStyles.HexNumber, out char c);
                            if(result)
                                buffer.Append(c);
                            else
                                break;
                            i += 4;
                            break;
                    }
                    startIndex = i + 1;
                    count = 0;
                }
                else
                    count++;
            }

            if(count > 0)
                buffer.Append(src, startIndex, count);

            dst = buffer.ToString();
            return result;
        }

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        static bool parse(string src, NumberStyles style, out char dst)
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
        static bool parse(string value, NumberStyles style, out int dst)
            => int.TryParse(value, style, NumberFormatInfo.InvariantInfo, out dst);

        // static Option<S> WriteSetting<S>(string name, string value, S dst)
        // {
        //     try
        //     {
        //         var wf = from p in typeof(S).Property(name)
        //                  let v = Convert.ChangeType(value, p.PropertyType)
        //                  from r in p.Write(v, dst)
        //                  select (S)r;
        //         return wf;
        //     }
        //     catch(Exception e)
        //     {
        //         Console.Error.WriteLine(e);
        //         return Option.none<S>();
        //     }
        // }

        static IEnumerable<FieldInfo> SettingFields<S>()
            => typeof(S).InstanceFields();

        static IEnumerable<PropertyInfo> SettingProperties<S>()
            => from p in typeof(S).InstanceProperties()
                where p.HasPublicGetter() && p.HasPublicSetter()
                select p;

        static IEnumerable<MemberInfo> SettingMembers<S>()
            => SettingProperties<S>().Cast<MemberInfo>().Union(SettingFields<S>());

        // static IEnumerable<string> SettingNames<S>()
        //     => SettingMembers<S>().Select(m => m.Name);

        // static IEnumerable<Setting> PropSettings<S>(object src)
        //     => SettingProperties<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));

        // static IEnumerable<Setting> FieldSettings<S>(object src)
        //     => SettingFields<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));
    }
}