//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Cmd : AppService<Cmd>
    {   
        public static CmdArgs args<T>(T src)
            where T : ICmd
                => typeof(T).DeclaredInstanceFields().Select(f => new CmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        public static CmdResult<C,P> result<C,P>(C spec, ExecToken token, bool suceeded, P payload = default)
            where C : ICmd, new()
            where P : INullity, new()
                => new CmdResult<C, P>(spec,token,suceeded,payload);

        public static ReadOnlySeq<ICmdExecutor> executors(params Assembly[] src)
            => src.Types().Tagged<CmdExecutorAttribute>().Concrete().Map(x => (ICmdExecutor)Activator.CreateInstance(x));


        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => CmdArgs.arg(args,index).Value;

        public static string format(CmdField src)
            => string.Format($"{src.FieldName}:{src.Expr}");

        public static ReadOnlySeq<CmdFlagSpec> flags(FilePath src)
        {
            var k = z16;
            var dst = list<CmdFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.Eq);
                if(i == NotFound)
                    continue;

                var name = text.trim(Asci.format(SQ.left(content,i)));
                var desc = text.trim(Asci.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        public static CmdArgs args<T>(params T[] src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg<T>(skip(src,i));
            return new (dst);
        }

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool.Format(), modifier, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, params string[] src)
            => new ToolCmdLine(tool.Format(), new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath, src.TargetPath));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);        

        [MethodImpl(Inline), Op]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        [Op]
        public static CmdLine pwsh(string spec)
            => $"pwsh.exe {spec}";

        public static CmdLine pwsh(FilePath src, string args)
            => string.Format("pwsh.exe {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));        

        [Op]
        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        [Op]
        public static CmdLine cmd(FilePath src, string args)
            => string.Format("cmd.exe /c {0} {1}", src.Format(PathSeparator.BS), args);

        [Op]
        public static CmdLine cmd(FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path),
                CmdKind.Tool => cmd(path),
                CmdKind.Pwsh => pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind, string args)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path, args),
                CmdKind.Tool => cmd(path, args),
                CmdKind.Pwsh => pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg($"{skip(src,i)}");
            return new (dst);
        }
   }
}