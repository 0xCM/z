// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------

// namespace Z0
// {
//     [ApiHost]
//     public readonly struct SymLists
//     {
//         const NumericKind Closure = UInt64k;

//         [Op,Closures(Closure)]
//         public static ItemList<K,string> names<K>(Symbols<K> src, string name = null)
//             where K : unmanaged
//                 => new ItemList<K,string>(name ?? (typeof(K).Name + "Names"),
//                     src.Storage.Select(x => new ListItem<K,string>(x,x.Name)));

//         [Op,Closures(Closure)]
//         public static ItemList<ushort,string> names<K>(Symbols<K> src, W16 w, string name = null)
//             where K : unmanaged
//                 => new ItemList<ushort,string>(name ?? (typeof(K).Name + "Names"),
//                     src.Storage.Select(x => new ListItem<ushort,string>((ushort)x.Value,x.Name)));

//         [Op,Closures(Closure)]
//         public static ItemList<K,string> expressions<K>(Symbols<K> src, string name = null)
//             where K : unmanaged
//                 => new ItemList<K,string>(name ?? (typeof(K).Name + "Expressions"),
//                     src.Storage.Select(x => new ListItem<K,string>(x, x.Expr.Text)));
//         [Op,Closures(Closure)]
//         public static ItemList<ushort,string> expressions<K>(Symbols<K> src, W16 w, string name = null)
//             where K : unmanaged
//                 => new ItemList<ushort,string>(name ?? (typeof(K).Name + "Expressions"),
//                     src.Storage.Select(x => new ListItem<ushort,string>((ushort)x.Value,x.Expr.Text)));



//     }
// }