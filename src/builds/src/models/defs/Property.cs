// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using E = Microsoft.Build.Evaluation;

//     partial class Build
//     {
//         public readonly record struct Property : IProjectProperty<string>
//         {
//             readonly E.ProjectProperty Data;

//             [MethodImpl(Inline)]
//             internal Property(E.ProjectProperty src)
//             {
//                 Data = src;
//             }

//             public string Name
//             {
//                 [MethodImpl(Inline)]
//                 get => Data.Name;
//             }

//             public string Value
//             {
//                 [MethodImpl(Inline)]
//                 get => Data.EvaluatedValue;
//             }

//             public string Format()
//                 => $"{Name}={Value}";

//             public override string ToString()
//                 => Format();
//         }
//     }
// }