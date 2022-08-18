// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public abstract class ToolExecutor<E,S>
//         where E : ToolExecutor<E,S>
//         where S : ISettings<S>, new()
//     {
//         S _Settings;

//         readonly WfEmit Emit;

//         protected ToolExecutor(WfEmit channel)
//         {
//             _Settings = new();
//             Emit = channel;
//         }
        
//         protected ToolExecutor(WfEmit channel, S settings)
//         {
//             Emit = channel;
//             _Settings = settings;
//         }

//         public ref S Settings
//         {
//             [MethodImpl(Inline)]
//             get => ref _Settings;
//         }
//     }
// }