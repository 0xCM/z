// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly struct WfTask
//     {
//         public readonly CmdUri TaskName;

//         [MethodImpl(Inline)]
//         public WfTask(CmdUri name)
//         {
//             TaskName = name;
//         }


//         [MethodImpl(Inline)]
//         public static implicit operator WfTask(CmdUri src)
//             => new WfTask(src);
//     }
// }