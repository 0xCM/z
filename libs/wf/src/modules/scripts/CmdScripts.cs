//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost,Free]
    public partial class CmdScripts
    {
        const NumericKind Closure = UnsignedInts;

        static AppDb AppDb => AppDb.Service;

        public static CmdLine create(FilePath src)
        {
            if(src.Is(FileKind.Cmd))
                return cmd(src);
            else if(src.Is(FileKind.Ps1))
                return pwsh(src);
            else
                return sys.@throw<CmdLine>();
        }

        [MethodImpl(Inline), Op]
        public static CmdScript create(Name name, CmdScriptExpr src)
            => new CmdScript(name, src);

        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));

        public static CmdLine cmd(FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(ScriptTemplate src)
            => new CmdScriptExpr(src);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(ScriptTemplate src, CmdVars vars)
            => new CmdScriptExpr(src, vars);

        [MethodImpl(Inline), Op]
        public static ScriptTemplate template(string name, string content)
            => new ScriptTemplate(name, content);

        [MethodImpl(Inline), Op]
        public static CmdFlag disable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.Off);

        [MethodImpl(Inline), Op]
        public static CmdFlag enable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.On);
    }
}