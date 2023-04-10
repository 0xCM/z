// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     /// <summary>
//     /// Defines classifers corresponding to each recognized argument aspect
//     /// </summary>
//     /// <remarks>
//     /// This classification scheme is applicable to arguments of the form [Prefix][name][qualifier]<value/>
//     /// For example --foo:3 or -foo 3 or 3
//     /// </remarks>
//     [Flags, SymSource("cmd")]
//     public enum ArgPartKind : byte
//     {
//         None = 0,

//         /// <summary>
//         /// Indicates the 0-based position of an argument relative to other arguments in a sequence
//         /// </summary>
//         Position = 1,

//         /// <summary>
//         /// Indicates the semantic content of an agument
//         /// </summary>
//         Value = 2,

//         /// <summary>
//         /// Indicates an argument prefix
//         /// </summary>
//         Prefix = 4,

//         /// <summary>
//         /// Indicates an argument name
//         /// </summary>
//         Name = 8,

//         /// <summary>
//         /// Indicates a symbol (other than a space) interposed between the argument name and value
//         /// </summary>
//         Qualifier = 16,
//     }
// }