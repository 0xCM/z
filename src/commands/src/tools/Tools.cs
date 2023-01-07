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
        public static ToolCatalog ambient()
        {
            var paths = Env.path(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
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
            return new (dst);
        }

        public static void tools(IWfChannel channel, IDbArchive dst)
        {
            var buffer = bag<FilePath>();
            var paths = Env.path(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            iter(paths, dir => {
                iter(DbArchive.enumerate(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {
                    buffer.Add(path);
                });
            }, true);

            var tools = buffer.Array().Sort(new FileNameComparer());
            var counter = 0u;
            var emitter = text.emitter();
            foreach(var tool in tools)
            {               
                var info = string.Format("{0:D5} {1,-36} {2}", counter++, tool.FileName.WithoutExtension, tool); 
                emitter.AppendLine(info);
                channel.Row(info);
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.List)));
        }


        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => new (CmdArgs.arg(args,index).Value);

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, params string[] src)
            => new ToolCmdLine(tool, src);

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
            return new ToolCmd(tool, Cmd.identify(t), buffer);
        }        

        public static Task<ExecToken> vscode<T>(IWfChannel channel, T target, CmdContext? context = null)
            => CmdRunner.start(channel, FS.path("code.exe"), Cmd.args(target), context);

        public static Task<ExecToken> devenv<T>(IWfChannel channel, T target, CmdContext? context = null)
            => CmdRunner.start(channel, FS.path("devenv.exe"), Cmd.args(target), context);

        public static ToolKey key(uint seq, FileName name)
            => new (seq,name);
                
        public static void emit(IWfChannel channel, ToolCatalog src, IDbArchive dst)
        {
            var emitter = text.emitter();
            foreach(var key in src.Keys)
            {               
                if(src.Find(key, out var t))
                {
                    var info = string.Format("{0:D5} | {1,-48} | {2}", t.Seq, t.Name, t.Path); 
                    emitter.AppendLine(info);
                    channel.Row(info);
                }
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.Csv)));
        }
    }
}