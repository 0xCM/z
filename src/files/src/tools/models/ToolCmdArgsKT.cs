// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class ToolCmdArgs<K,T> : Seq<ToolCmdArgs<K,T>,ToolCmdArg<K,T>>
//         where K : unmanaged
//     {
//         public ToolCmdArgs()
//         {

//         }

//         [MethodImpl(Inline)]
//         public ToolCmdArgs(ToolCmdArg<K,T>[] src)
//             : base(src)
//         {

//         }

//         [MethodImpl(Inline)]
//         public static implicit operator ToolCmdArgs<K,T>(ToolCmdArg<K,T>[] src)
//             => new ToolCmdArgs<K,T>(src);

//         [MethodImpl(Inline)]
//         public static implicit operator ToolCmdArgs(ToolCmdArgs<K,T> src)
//             => new ToolCmdArgs(src.Data.Select(x => (ToolCmdArg)x));
//     }
// }