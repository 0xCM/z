// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly struct CgSpecs
//     {
//         public static CgSpec define(string ns)
//             => new CgSpec(ns,sys.empty<string>());

//         public static CgSpec define(string ns, string[] usings)
//             => new CgSpec(ns,usings);

//         public static CgSpec<T> define<T>(string ns, string[] usings, T body)
//             => define(ns,usings).WithContent(body);


//     }
// }