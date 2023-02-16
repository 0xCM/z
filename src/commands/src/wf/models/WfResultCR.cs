// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly struct WfResult<C,R>
//         where C : IApiCmd<C>, new()        
//     {
//         public readonly WfTask<C> Task;

//         public readonly ExecToken Token;

//         public readonly R Data;

//         [MethodImpl(Inline)]
//         public WfResult(WfTask<C> task, ExecToken token, R data)
//         {
//             Task = task;
//             Token = token;
//             Data = data;
//         }
//     }
// }