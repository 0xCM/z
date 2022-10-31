//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WfScripts : WfSvc<WfScripts>
    {
        public FolderPath CleanOutDir(IProjectWorkspace project)
            => project.BuildOut().Clear(true);

        public void BuildAsm(IProjectWorkspace src)
            => RunScripts(src, FileKind.Asm, src.Script("build-asm"), false);

        public void BuildC(IProjectWorkspace src, bool runexe = false)
            => RunScripts(src, FileKind.C, src.Script("build-c"), runexe);

        public void BuildCpp(IProjectWorkspace src, bool runexe = false)
            => RunScripts(src, FileKind.Cpp, src.Script("build-cpp"), runexe);

        public void RunScripts(IProjectWorkspace project, FileKind kind, FilePath script, bool runexe)
        {
            if(!script.Exists)
                sys.@throw(AppMsg.NotFound.Format(script));
                
            RunScript(project, kind, script, flow => OnExec(flow, runexe));
        }

        void RunExe(CmdFlow flow)
        {
            var running = Running(string.Format("Executing {0}", flow.TargetPath.ToUri()));
            var result = OmniScript.Run(flow.TargetPath, CmdVars.Empty, quiet: true, out var response);
            if (result.Fail)
                Error(result.Message);
            else
            {
                for (var i=0; i<response.Length; i++)
                    Write(string.Format("exec >> {0}",skip(response, i).Content), FlairKind.StatusData);

                Ran(running, string.Format("Executed {0}", flow.TargetPath.ToUri()));
            }
        }

        Outcome RunToolScript(FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<CmdFlow> flows)
        {
            flows = default;
            var result = Outcome.Success;
            if(!src.Exists)
                return (false, FS.missing(src));

            result = ProcessControl.run(
                new CmdLine(src.Format(PathSeparator.BS)),
                vars,
                quiet ? ReceiveCmdStatusQuiet : ReceiveCmdStatus, ReceiveCmdError,
                out var response
                );

            if(result.Fail)
                return result;

            CmdFlows.parse(response, out flows);

            return result;
        }

        void OnExec(CmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }

        void ReceiveCmdStatusQuiet(in string src)
        {

        }

        void ReceiveCmdStatus(in string src)
        {
            Write(src);
        }

        void ReceiveCmdError(in string src)
        {
            Write(src, FlairKind.Error);
        }

        Outcome RunProjectScript(IProjectWorkspace project, string srcid, FilePath script, bool quiet, out ReadOnlySpan<CmdFlow> flows)
        {
            var result = Outcome.Success;
            var vars = WsCmdVars.create();
            vars.SrcId = srcid;
            return RunToolScript(script, vars.ToCmdVars(), quiet, out flows);
        }

        Outcome<Index<CmdFlow>> RunScript(IProjectWorkspace project, FilePath script, string srcid)
        {
            var cmdflows = list<CmdFlow>();
            var result = RunProjectScript(project, srcid, script, true, out var flows);
            if(result)
            {
                var count = flows.Length;
                for(var j=0; j<count; j++)
                    cmdflows.Add(skip(flows,j));
                return (true, cmdflows.ToArray());
            }

            return result;
        }

        void RunScript(IProjectWorkspace project, FileKind kind, FilePath script, Action<CmdFlow> receiver)
        {
            var flows = list<CmdFlow>();
            var files = project.SourceFiles(kind, false);
            int length = files.Length;
            for(var i=0; i<length; i++)
            {
                var path = files[i];
                var srcid = path.FileName.WithoutExtension.Format();
                var result = RunScript(project, script, srcid);
                if(result)
                {
                    flows.AddRange(result.Data);
                    foreach(var flow in result.Data)
                    {
                        Status(flow.Format());
                        receiver.Invoke(flow);
                    }
                }
            }

            if(flows.Count != 0)
                TableEmit(flows.ViewDeposited(), Projects.build(project));
        }
    }
}