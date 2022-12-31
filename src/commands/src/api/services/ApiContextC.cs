// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     class ApiContext<C> : ApiContext, IApiContext<C>
//         where C : IApiService<C>,new()
//     {
//         public ApiContext(C commander, IWfChannel channel, ICmdDispatcher dispatcher)
//             : base(commander, channel, dispatcher)
//         {
//             //Commander = commander;
//         }

//         //public new readonly C Commander;

//         // C IApiContext<C>.Commander
//         //     => Commander;
//     }
// }