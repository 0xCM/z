//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Tools
    {
        static Tools Instance;

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, params string[] src)
            => new ToolCmdLine(tool, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        public static string format(IToolCmd src)
        {
            var count = src.Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        [Op, Closures(UInt64k)]
        public static ToolCmd cmd<T>(Tool tool, in T src)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(src, fields, reflected);
            var buffer = sys.alloc<ToolCmdArg>(count);
            var target = span(buffer);
            var values = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(values,i);
                seek(target,i) = new ToolCmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmd(tool, ApiCmd.identify(t), buffer);
        }        

        public static ref readonly Tools Service => ref Instance;

        public static void develop(IWfChannel channel, CmdArgs args)
        {
            var cd = Env.cd();
            var launcher = cd + FS.file("develop", FileKind.Cmd);
            if(launcher.Exists)
                CmdRunner.start(channel, Cmd.args(launcher)); 
            else
            {
                var workspaces = cd.Files(FS.ext("code-workspace"));
                if(workspaces.IsNonEmpty)
                    vscode(channel, cd + workspaces[0].FileName);
                else
                    vscode(channel, cd); 
            }
        }

        public static Task<ExecToken> vscode<T>(IWfChannel channel, T target)
            => CmdRunner.start(channel, FS.path("code.exe"), Cmd.args(target));

        public static Task<ExecToken> devenv<T>(IWfChannel channel, T target)
            => CmdRunner.start(channel, FS.path("devenv.exe"), Cmd.args(target));

        public ReadOnlySpan<ToolKey> Known => Lookup.Keys;

        static bool tool(ToolKey key, out LocatedTool tool)
            => Lookup.Find(key, out tool);

        static SortedLookup<ToolKey,LocatedTool> Lookup;

        public static ToolKey key(uint seq, FileName name)
            => new (seq,name);
                
        static SortedLookup<ToolKey,LocatedTool> discover()
        {
            var paths = Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            var dst = dict<ToolKey,LocatedTool>();
            var seq = 0u;
            for(var i=0u; i<paths.Count; i++)
            {
                ref readonly var dir = ref paths[i];
                iter(DbArchive.enumerate(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {
                    var k = key(seq++,path.FileName());
                    dst.TryAdd(k, new (seq++, k, path));
                });
            }
            return dst;
        }

        public static void emit(IWfChannel channel, ReadOnlySpan<ToolKey> src, IDbArchive dst)
        {
            var emitter = text.emitter();
            foreach(var key in src)
            {               
                if(tool(key, out var t))
                {
                    var info = string.Format("{0:D5} | {1,-48} | {2}", t.Seq, t.Name, t.Path); 
                    emitter.AppendLine(info);
                    channel.Row(info);
                }
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.Csv)));
        }

        static Tools()
        {
            Lookup = discover();
            Instance = new();
        }
    }
}