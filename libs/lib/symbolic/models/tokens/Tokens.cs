// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static core;

//     [ApiHost]
//     public readonly struct Tokens
//     {
//         public static TokenSet set(Type[] src)
//         {
//             var dst = new TokenSet();
//             dst.WithTypes(src);
//             return dst;
//         }

//         public static TokenSet set(string name, Type[] src)
//         {
//             var dst = new TokenSet(name);
//             dst.WithTypes(src);
//             return dst;
//         }
//     }
// }