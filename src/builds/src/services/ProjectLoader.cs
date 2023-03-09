// namespace Z0
// {
//     using System.Xml;
//     using ProjectRootElement = Microsoft.Build.Construction.ProjectRootElement;
//     using E = Microsoft.Build.Evaluation;

//     partial class Build
//     {
//         /// Inspired by:
//         /// https://github.com/dotnet/roslyn/blob/main/src/Workspaces/Core/MSBuild/MSBuild/MSBuildProjectLoader.cs
//         public class ProjectLoader
//         {
//             static readonly XmlReaderSettings s_xmlReaderSettings = new()
//             {
//                 DtdProcessing = DtdProcessing.Prohibit,
//                 XmlResolver = null
//             };

//             public E.Project LoadProject(string path)
//             {
//                 using FileStream stream =
//                     new(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous);

//                 using StreamReader readStream = new(stream);
//                 using var xmlReader = XmlReader.Create(readStream, s_xmlReaderSettings);

//                 var xml = ProjectRootElement.Create(xmlReader);
//                 xml.FullPath = path;

//                 return new E.Project(xml);
//             }
//         }
//     }
// }