// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public abstract class ApiAction<A>
//         where A : ApiAction<A>
//     {
//         protected IWfRuntime Wf;

//         protected IWfChannel Channel;

//         public readonly string ActionName;

//         protected ApiAction(IWfRuntime wf, string action)
//         {
//             Wf = wf;
//             Channel = wf.Channel;
//             ActionName = action;
//         }
//     }
// }