// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static core;

//     public abstract class TokenSet<T,K> : ITokenSet<K>
//         where T : TokenSet<T,K>, new()
//         where K : unmanaged
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

//         public ReadOnlySpan<Token<K>> View
//             => _Tokens.ViewDeposited();

//         List<Token<K>> _Tokens;

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
//             {
//                 var tokens = Symbols.tokenize(skip(types,i));
//                 for(var j=0; j<tokens.Count; j++)
//                 {
//                     ref readonly var token = ref tokens[j];
//                 }

//                 //_Tokens.AddRange(Symbols.tokenize<K>(skip(types,i)));
//             }
//         }
//     }
// }