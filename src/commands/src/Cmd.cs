//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    // msvsmon.exe, 0, 67532, 7, 0:00:00:00:046, 10:48:46 PM 11/30/2022, 148.39 MB, 142.04 MB, "D:\tools\msvs\msvs.2022\Common7\IDE\Remote Debugger\x64\msvsmon.exe" /__dbgautolaunch 0x0000000000001578 0x8c3c /hostname [anon-pipe:0000000000001570:000000000000156C] /port 1 /__pseudoremote /__workerProcess
    // msvsmon.exe, 0, 57404, 10, 0:00:00:00:453, 10:48:44 PM 11/30/2022, 143.1 MB, 83.48 MB, "D:\tools\msvs\msvs.2022\Common7\IDE\Remote Debugger\x64\msvsmon.exe" /__dbgautolaunch 0x00000000000019EC 0x8c3c /hostname [anon-pipe:0000000000001380:0000000000001A30] /port 1 /__pseudoremote /VsReliabilityPath "D:\tools\msvs\msvs.2022\common7\ide\VSReliability.dll"


    [ApiHost]
    public class Cmd
    {        
        public static string format(ApiCmdSpec src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            dst.Append(src.Name);
            var count = src.Args.Count;
            for(ushort i=0; i<count; i++)
            {
                var arg = src.Args[i];
                if(nonempty(arg.Name))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Name);
                }

                if(nonempty(arg.Value))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Value);
                }
            }
            return dst.Emit();
        }

        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => CmdArgs.arg(args,index).Value;

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

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

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

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, params string[] src)
            => new ToolCmdLine(tool, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);        

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