//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public sealed partial class ProcessControl : Control<ProcessControl>
    {
        public static IControl Control()
            => Instance;    

        static AppDb AppDb => AppDb.Service;

        static void enlist(ExecutingProcess spec)
            => _Executing.TryAdd(spec.Id,spec);

        static void remove(ExecutedProcess exec)
        {
            if(_Executing.TryRemove(exec.Id))
            {
                _Completed.TryAdd(exec.Id, exec);
            }
        }

        static ConcurrentDictionary<ProcessId,ExecutingProcess> _Executing = new();

        static ConcurrentDictionary<ProcessId,ExecutedProcess> _Completed = new();

        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var running = channel.Running("cmd/redirect");
                var outAPath = AppDb.AppData().Path("a", FileKind.Log);
                var outBPath = AppDb.AppData().Path("b", FileKind.Log);
                using var outA = outAPath.Utf8Writer();
                using var outB = outBPath.Utf8Writer();

                void OnA(string msg)
                {
                    channel.Row(msg, FlairKind.Data);
                    outA.WriteLine(msg);
                }

                void OnB(string msg)
                {
                    channel.Row(msg, FlairKind.StatusData);
                    outB.WriteLine(msg);
                }

                start(channel, new SysIO(OnA,OnB), args).Wait();
                return channel.Ran(running, outA);
            }
            return sys.start(Run);
        }

        public static ReadOnlySeq<ExecutingProcess> Executing()
            => _Executing.Values.Array();

        public static ReadOnlySeq<ExecutedProcess> Finished()
            => _Completed.Values.Array();

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

        protected override void Disposing()
        {
            sys.iter(_Executing.Values, p => p.Adapted.Close());
        }


        static ProcessControl Instance = new();

    }
}