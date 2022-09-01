// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using System.IO;

//     public sealed class ClangQuery : ToolService<ClangQuery>
//     {
//         public const string ToolId = "clang-query";

//         Interpreter Controller;

//         FilePath SourceFile;

//         StreamWriter QueryWriter;

//         uint Sequence;

//         uint Counter;

//         public ClangQuery()
//             : base(ToolId)
//         {
//             Counter = 0;
//         }

//         FilePath NextOutFile()
//             => AppDb.AppData("clang-query").Path(string.Format("QueryOut{0}", Sequence++), FileKind.Log);

//         void CloseQuery()
//         {
//             if(QueryWriter != null)
//             {
//                 QueryWriter.Flush();
//                 QueryWriter.Dispose();
//                 QueryWriter = null;
//             }
//         }

//         void QueryBegin()
//         {
//             CloseQuery();
//             SourceFile = NextOutFile();
//             QueryWriter = (SourceFile).Writer();
//             QueryWriter.AutoFlush = true;
//             Write(string.Format("Sending query output to {0}", SourceFile.ToUri()));
//         }

//         DbArchive LlvmRoot => FS.dir("v:/repos/llvm");

//         public DbArchive LlvmRepo 
//             => LlvmRoot.Scoped("llvm-project");

//         public DbArchive LlvmBuild 
//             => LlvmRoot.Scoped("build");

//         public DbArchive LlvmBin 
//             => LlvmBuild.Scoped("bin");

//         public FilePath CompileCommands 
//             => LlvmBuild.Path("compile_commands", FileKind.Json);

//         public void QueryFile(FilePath src)
//         {
//             //QueryBegin();
//             var tool = LlvmBin.Path("clang-query",FileKind.Exe);
//             var args = string.Format("-p=\"{0}\" \"{1}\"", CompileCommands, src);
//             Controller = Interpreter.create(Emitter, tool, args);
//             Controller.Start();
//             Controller.Submit("help");
//             Controller.Submit("set output dump");
//             Controller.Submit("match enumDecl()");
//         }
//     }
// }