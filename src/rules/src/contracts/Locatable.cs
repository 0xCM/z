// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly struct Locatable : ILocatable
//     {
//         public dynamic Location {get;}

//         [MethodImpl(Inline)]
//         public Locatable(dynamic location)
//             => Location = location;

//         public static Locatable Empty
//         {
//             [MethodImpl(Inline)]
//             get => new Locatable(0ul);
//         }

//         public string Format()
//             => Location?.ToString() ?? EmptyString;

//         public override string ToString()
//             => Format();
//     }
// }