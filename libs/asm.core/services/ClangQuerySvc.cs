//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.IO;

    public sealed class ClangQuerySvc : ToolService<ClangQuerySvc>
    {
        public const string ToolId = "clang-query";

        Interpreter Controller;

        FilePath QueryFile;

        StreamWriter QueryWriter;

        uint Sequence;

        uint Counter;

        public ClangQuerySvc()
            : base(ToolId)
        {
            Counter = 0;
        }

        FilePath NextOutFile()
            => AppDb.AppData("clang-query").Path(string.Format("QueryOut{0}", Sequence++), FileKind.Log);

        void CloseQuery()
        {
            if(QueryWriter != null)
            {
                QueryWriter.Flush();
                QueryWriter.Dispose();
                QueryWriter = null;
            }
        }

        void QueryBegin()
        {
            CloseQuery();
            QueryFile = NextOutFile();
            QueryWriter = (QueryFile).Writer();
            QueryWriter.AutoFlush = true;
            Write(string.Format("Sending query output to {0}", QueryFile.ToUri()));
        }

        Outcome Dispatch(string command, CmdArgs args)
        {
            QueryBegin();
            var query = string.Format("{0} {1}", command, args.Format());
            QueryWriter.WriteLine(string.Format("query:{0}", query));
            return Controller.Submit(query);
        }

        DbArchive LlvmRoot => FS.dir("v:/repos/llvm");

        DbArchive LlvmRepo => LlvmRoot.Scoped("llvm-project");

        DbArchive LlvmBuild => LlvmRoot.Scoped("build");

        DbArchive LlvmBin => LlvmBuild.Scoped("bin");

        FilePath CompileCommands => LlvmBuild.Path("compile_commands", FileKind.Json);

        void SelectSource()
        {
            QueryBegin();
            var src = LlvmRepo.Path("llvm/include/llvm/Support/DJB.h", FileKind.H);
            var tool = LlvmBin.Path("clang-query",FileKind.Exe);
            var args = string.Format("-p=\"{0}\" \"{1}\"", CompileCommands, src);
            Controller = Interpreter.create(tool, args, OnStatus, OnError, OnExit);
            Controller.Start();
            Controller.Submit("set output dump");
        }

        void OnStatus(string msg)
        {
            QueryWriter.WriteLine(msg);
            if(msg.EndsWith(" matches."))
            {
                Write(msg);
            }
        }

        void OnError(string msg)
        {
            Write(msg);
        }

        void OnExit(int code)
        {
            Write(string.Format("Exit ({0})", code));
        }
    }
}