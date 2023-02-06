// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public struct CgSpec
//     {
//         public @string TargetNs;

//         public Index<string> Usings;

//         public CgSpec(@string ns, string[] usings)
//         {
//             TargetNs = ns;
//             Usings = usings;
//         }

//         public CgSpec<T> WithContent<T>(T content)
//             => new CgSpec<T>(TargetNs, Usings, content);
//     }
// }