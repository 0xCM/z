// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     [CmdReactor]
//     public abstract class CmdReactor<R,S> :  WfSvc<R>, ICmdReactor<S>
//         where S : struct, ICmd<S>
//         where R : CmdReactor<R,S>, new()
//     {
//         public static S Spec() => new S();

//         public CmdId CmdId => Spec().CmdId;

//         protected abstract CmdResult Run(S cmd);

//         public CmdResult<S> Invoke(S cmd)
//         {
//             try
//             {
//                 var flow = Wf.Running(cmd);
//                 var ran = Run(cmd);
//                 var result = new CmdResult<S>(cmd, ran.Succeeded, ran.Message);
//                 Wf.Ran(flow, result);
//                 return result;
//             }
//             catch(Exception e)
//             {
//                 Wf.Error(e);
//                 return new CmdResult<S>(cmd, e);
//             }
//         }

//         CmdResult ICmdReactor.Invoke(ICmd src)
//             => Invoke((S)src);
//     }
// }