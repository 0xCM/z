// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using E = Microsoft.Build.Evaluation;

//     partial class Build
//     {
//         public record class ProjectItem : IProjectItem
//         {
//             readonly E.ProjectItem Data;

//             public string Type
//                 => Data.ItemType;

//             internal ProjectItem(E.ProjectItem src)
//             {
//                 Data = src;
//             }

//             public string Include
//                 => Data.EvaluatedInclude;

//             public virtual string Format()
//             {
//                 var dst = text.emitter();
//                 dst.Append($"{Type}");
//                 if(text.nonempty(Include))
//                     dst.AppendLine($"={Include}");

//                 return dst.Emit();
//             }


//             public override string ToString()
//                 => Format();
//         }
//     }
// }