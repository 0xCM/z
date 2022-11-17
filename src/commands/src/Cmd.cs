//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public partial class Cmd
    {
        public static ReadOnlySpan<CmdResponse> response(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var parsed = list<CmdResponse>();
            for(var i=0; i<count; i++)
            {
                if(parse(skip(src,i).Content, out var response))
                    parsed.Add(response);
            }
            return parsed.ViewDeposited();
        }

        public static bool parse(string src, out CmdResponse dst)
        {
            dst = CmdResponse.Empty;
            var i = text.index(src, Chars.Colon);
            if(i > 0)
            {
                var left = text.left(src, i);
                var right = text.right(src,i);
                dst = (left,right);
                return true;
            }
            else
                return false;
        }


        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, params string[] src)
            => new ToolCmdLine(tool, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [Op]
        public static void parse(ReadOnlySpan<TextLine> src, out ReadOnlySpan<CmdFlow> dst)
            => dst = Cmd.flows(src);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);        

        public static ReadOnlySpan<CmdFlow> flows(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    Tool tool = text.left(content, j);
                    var flow = Fenced.unfence(text.right(content,j), Fenced.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

        const NumericKind Closure = UnsignedInts;    

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";

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

        [MethodImpl(Inline), Op, Closures(NumericKind.U64)]
        public static CmdArg<T> arg<T>(T value)
            where T : ICmdArg<T>, IEquatable<T>, IComparable<T>
                => value;
        [Op]
        public static CmdArg arg(CmdArgs src, int index)
        {
            if(src.IsEmpty)
                @throw(EmptyArgList.Format());

            var count = src.Count;
            if(count < index - 1)
                @throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

        public static string join(CmdArgs args)
        {
            var dst = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(args[i].Value);
            }

            return dst.Emit();
        }

        public static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg($"{skip(src,i)}");
            return new (dst);
        }

        public static ExecToken exec<C>(IWfContext context, C cmd, Func<IWfContext,C,Outcome> actor)
            where C : ICmd<C>, new()
        {
            var outcome = Outcome.Success;
            var running = context.Channel.Running($"{cmd.CmdId}");
            try
            {
                outcome = actor(context,cmd);
            }
            catch(Exception e)
            {
                outcome = e;
            }

            return context.Channel.Ran(running);
        }

        public static ConstLookup<Name,ApiOp> defs(IApiDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,ApiOp>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }

        public static CmdActorKind classify(MethodInfo src)
        {
            var dst = CmdActorKind.None;
            var arity = src.ArityValue();
            var @void = src.HasVoidReturn();
            switch(arity)
            {
                case 0:
                    switch(@void)
                    {
                        case false:
                            dst = CmdActorKind.Pure;
                        break;
                        case true:
                            dst = CmdActorKind.Emitter;
                        break;
                    }
                break;
                case 1:
                    switch(@void)
                    {
                        case true:
                            dst = CmdActorKind.Receiver;
                        break;
                        case false:
                            dst = CmdActorKind.Func;
                        break;
                    }
                break;
            }
            return dst;
        }
   }
}