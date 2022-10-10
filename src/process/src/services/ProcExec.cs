//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public sealed partial class ProcExec
    {
        static AppDb AppDb => AppDb.Service;

        static void running(ExecutingProcess spec)
            => ExecutingLookup.TryAdd(spec.Id,spec);

        static void finished(ExecutedProcess exec)
        {
            if(ExecutingLookup.TryRemove(exec.Id))
            {
                FinishedLookup.TryAdd(exec.Id,exec);
            }
        }


        static ConcurrentDictionary<ProcessId,ExecutingProcess> ExecutingLookup = new();

        static ConcurrentDictionary<ProcessId,ExecutedProcess> FinishedLookup = new();

        public static ReadOnlySeq<ExecutingProcess> Executing()
            => ExecutingLookup.Values.Array();

        public static ReadOnlySeq<ExecutedProcess> Finished()
            => FinishedLookup.Values.Array();

        [MethodImpl(Inline), Op]
        public static CmdScript script(string name, CmdScriptExpr src)
            => new CmdScript(name, src);

        public static CmdLine cmdline(FilePath src)
        {
            if(src.Is(FileKind.Cmd))
                return cmd(src);
            else if(src.Is(FileKind.Ps1))
                return pwsh(src);
            else
                return sys.@throw<CmdLine>();
        }

        [Op]
        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        [Op]
        public static bool arg(ToolCmdArgs src, string name, out ToolCmdArg dst)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src[i];
                if(string.Equals(arg.Name, name, NoCase))
                {
                    dst=arg;
                    return true;
                }
            }
            dst = ToolCmdArg.Empty;
            return false;
        }
    }
}