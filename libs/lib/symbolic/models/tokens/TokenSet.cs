// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using System;

//     public sealed class TokenSet : TokenSet<TokenSet>
//     {
//         Index<Type> _Types;

//         public TokenSet()
//         {
//             Name = "set";
//         }

//         internal TokenSet(string name)
//         {
//             Name = name;
//         }

//         public override string Name {get;}

//         internal TokenSet WithTypes(Type[] src)
//         {
//             _Types = src;
//             Load();
//             return this;
//         }

//         public override Type[] Types()
//             => _Types;
//     }
// }