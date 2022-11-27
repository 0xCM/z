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
        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => CmdArgs.arg(args,index).Value;

        /// <summary>
        /// Creates a meaningful option
        /// </summary>
        /// <param name="name">The option name</param>
        /// <param name="value">What does it do?</param>
        [MethodImpl(Inline), Op]
        public static CmdOption option(string name, string value)
            => new CmdOption(name, value);

        [MethodImpl(Inline), Op]
        public static CmdArgDef<T> arg<T>(string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(name, value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> arg<T>(ushort pos, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, value.ToString(), value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> arg<T>(ushort pos, string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, name, value, prefix);

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
        public static CmdFlag disable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.Off);

        [MethodImpl(Inline), Op]
        public static CmdFlag enable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.On);

        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);


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
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        public static CmdExecStatus status(ExecutingProcess src)
        {
            var dst = CmdExecStatus.Empty;
            dst.Id = src.Id;
            dst.StartTime = src.Started;
            dst.HasExited = src.Finished;
            if(src.Finished)
            {
                dst.ExitTime = src.Adapted.ExitTime;
                dst.Duration = dst.ExitTime - dst.StartTime;
                dst.ExitCode = src.Adapted.ExitCode;
            }
            return dst;
        }

        public static Task<ExecToken> redirect(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var running = channel.Running("cmd/redirect");
                var outAPath = AppDb.Service.AppData().Path("a", FileKind.Log);
                var outBPath = AppDb.Service.AppData().Path("b", FileKind.Log);
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

                Cmd.start(channel, new SysIO(OnA,OnB), args).Wait();
                return channel.Ran(running, outA);
            }
            return sys.start(Run);
        }

        public static Task<ExecToken> start(IWfChannel channel, ISysIO io, CmdArgs spec, FolderPath? wd = null)
        {
            ExecToken go()
            {
                var running = channel.Running(spec);
                var result = Cmd.run(io,spec,wd);
                return channel.Ran(running);
            }

            return sys.start(go);
        }

        public static void run(IWfChannel channel, string tool, string args, FilePath dst)
        {
            var emitting = channel.EmittingFile(dst);
            using var status = dst.Utf8Writer(true);
            var counter = 0u;

            void OnStatus(string msg)
            {
                status.WriteLine(msg);
                counter++;
            }

            void OnError(string msg)
                => channel.Error(msg);

            string Input()
                => EmptyString;
            
            Cmd.run(new SysIO(OnStatus, OnError, Input), Cmd.args(tool,args), dst.FolderPath);
            channel.EmittedFile(emitting, counter);
        }

        public static CmdExecStatus run(ISysIO io, CmdArgs spec, FolderPath? wd = null)
        {
            var values = spec.Values();
            Demand.gt(values.Count,0u);
            var name = values.First;
            var args = values.ToSpan().Slice(1).ToArray();
            var psi = new ProcessStartInfo(values.First, text.join(Chars.Space,args))
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                WorkingDirectory = wd != null ? wd.Value.Format() : EmptyString
            };

            void OnStatus(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    io.Status(e.Data);
            }
    
            void OnError(object sender, DataReceivedEventArgs e)
            {
                if(sys.nonempty(e.Data))
                    io.Error(e.Data);
            }

            var result = default(CmdExecStatus);
            try
            {                
                using var process = sys.process(psi);
                process.OutputDataReceived += OnStatus;
                process.ErrorDataReceived += OnError;
                process.Start();
                result.StartTime = sys.now();
                result.Id = process.Id;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExitAsync().Wait();                
                result.HasExited = true;
                result.ExitTime = sys.now();
                result.Duration = result.ExitTime - result.StartTime;
                result.ExitCode = process.ExitCode;
            }
            catch(Exception e)
            {
                io.Error(e.ToString());
            }
            return result;
        }

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

        public static CmdArgs args<T>(params T[] src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg<T>(skip(src,i));
            return new (dst);
        }

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

        public static ExecToken exec<C>(IApiContext context, C cmd, Func<IApiContext,C,Outcome> actor)
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