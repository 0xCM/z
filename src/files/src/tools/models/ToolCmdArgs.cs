// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class ToolCmdArgs : Seq<ToolCmdArgs,ToolCmdArg>
//     {
//         public ToolCmdArgs()
//         {

//         }

//         [MethodImpl(Inline)]
//         public ToolCmdArgs(ToolCmdArg[] src)
//             :base(src)
//         {

//         }

//         [MethodImpl(Inline)]
//         public static implicit operator ToolCmdArgs(ToolCmdArg[] src)
//             => new ToolCmdArgs(src);
//     }
// }