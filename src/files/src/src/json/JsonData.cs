// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using System.Text.Json;
//     using System.Linq;

//     [ApiHost]
//     public readonly partial struct JsonData
//     {
//         const NumericKind Closure = UInt64k;

//         // [Op, Closures(Closure)]
//         // public static string serialize<T>(T src, bool indented = true)
//         //     => JsonSerializer.Serialize(src, new JsonSerializerOptions{
//         //         IncludeFields= true,
//         //         WriteIndented = indented
//         //     });

//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static JsonText jtext<T>(JsonSeq<T> src)
//             => new (format(src));

//         [MethodImpl(Inline), Op, Closures(Closure)]
//         static string format<T>(JsonSeq<T> src)
//             => src.Content?.ToString() ?? EmptyString;

//         static IEnumerable<FieldInfo> SettingFields<S>()
//             => typeof(S).InstanceFields();

//         static IEnumerable<PropertyInfo> SettingProperties<S>()
//             => from p in typeof(S).InstanceProperties()
//                 where p.HasPublicGetter() && p.HasPublicSetter()
//                 select p;

//         static IEnumerable<MemberInfo> SettingMembers<S>()
//             => SettingProperties<S>().Cast<MemberInfo>().Union(SettingFields<S>());

//         static IEnumerable<string> SettingNames<S>()
//             => SettingMembers<S>().Select(m => m.Name);

//         static IEnumerable<Setting> PropSettings<S>(object src)
//             => SettingProperties<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));

//         static IEnumerable<Setting> FieldSettings<S>(object src)
//             => SettingFields<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));
//     }
// }