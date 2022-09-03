// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static core;

//     public abstract class TokenSet<T> : ITokenSet
//         where T : TokenSet<T>, new()
//     {
//         public static T create()
//         {
//             var dst = new T();
//             dst.Load();
//             return dst;
//         }

//         public abstract Type[] Types();

//         public virtual string Name
//             => typeof(T).Name;

//         public ReadOnlySpan<Token> View
//             => _Tokens.ViewDeposited();

//         List<Token> _Tokens;

//         protected TokenSet()
//         {
//             _Tokens = new();
//         }

//         protected void Load()
//         {
//             _Tokens.Clear();
//             var types = Types();
//             var count = types.Length;
//             for(var i=0; i<count; i++)
//                 _Tokens.AddRange(Symbols.tokenize(skip(types,i)));
//         }
//     }
// }