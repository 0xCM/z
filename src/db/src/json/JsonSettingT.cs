// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using System.Text.Json;

//     public sealed record class JsonSetting<T>
//     {
//         public readonly string Name;

//         public readonly T Value;

//         [MethodImpl(Inline)]
//         public JsonSetting(string name, T value)
//         {
//             Name = name;
//             Value = value;
//         }
//         public string Format()
//             => JsonSerializer.Serialize(this);

//         public override string ToString()
//             => Format();
//     }
// }