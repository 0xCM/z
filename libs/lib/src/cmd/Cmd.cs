//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    [ApiHost]
    public partial class Cmd
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArg<T> arg<T>(uint index, T value)
            => (index,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArg<T> arg<T>(uint index, string name, T value)
            => new CmdArg<T>(index, name, value);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(string name, string value)
            => new CmdArg(name,value);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(string name)
            => new CmdArg(name);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(uint index, string name, string value)
            => new CmdArg(index, name, value);

        public static CmdVar<K> var<K>(string name, K kind, string value)
            where K : unmanaged
                => new CmdVar<K>(name,kind,value);

        public static CmdVar<K,T> var<K,T>(string name, K kind, T value)
            where K : unmanaged
                => new CmdVar<K,T>(name, kind, value);

        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(Name name)
            => new CmdScriptVar(name);

        [MethodImpl(Inline), Op]
        public static CmdVar var(Name name, string value)
            => new CmdVar(name, value);

        [MethodImpl(Inline), Op]
        public static CmdVar var(string name, object value)
            => new CmdVar(name, value);

        public static Symbols<CmdKind> kinds()
            => Symbols.index<CmdKind>();

        [MethodImpl(Inline)]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        public static CmdArg arg(CmdArgs src, int index)
        {
            if(src.IsEmpty)
                sys.@throw(EmptyArgList.Format());

            var count = src.Count;
            if(count < index - 1)
                sys.@throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

        public static CmdArgs args(ReadOnlySpan<string> src)
        {
            var dst = sys.alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg(skip(src,i));
            return CmdArgs.create(dst);
        }

        [MethodImpl(Inline), Op]
        public static CmdVarInfo varinfo(Name name, TextBlock purpose)
            => new (name,purpose);

        public static CmdSource source<S>(S provider, IAppCmdDispatcher src)
            where S : ICmdProvider, new()
        {
            var specs = src.Commands.Specs.Index().Sort().Index();
            var part = src.Controller;
            var count = specs.Count;
            var buffer = sys.alloc<Setting64>(count);
            var dst = Settings.from(buffer);
            for(var i=0; i<specs.Count; i++)
                seek(buffer,i) = Settings.setting(string.Format("{0}[{1:D3}]", part, i), (asci64)specs[i]);
            return new CmdSource(provider.Name, dst);
        }

        public static Index<ICmdReactor> reactors(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }

        [MethodImpl(Inline), Op]
        public static CmdProcess process(CmdLine cmd)
            => new CmdProcess(cmd);

        [Op]
        public static CmdProcess process(CmdLine cmd, CmdVars? vars)
        {
            var options = new CmdProcessOptions();
            CmdProcess.include(vars, options);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess process(CmdLine cmd, CmdVars? vars, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions();
            CmdProcess.include(vars, options);
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess process(CmdLine cmd, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions();
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        [Op]
        public static CmdProcess process(CmdLine cmd, TextWriter dst)
            => new CmdProcess(cmd, new CmdProcessOptions(dst));

        [Op]
        public static CmdProcess process(CmdLine cmd, TextWriter dst, Receiver<string> status, Receiver<string> error)
        {
            var options = new CmdProcessOptions(dst);
            options.WithReceivers(status, error);
            return new CmdProcess(cmd, options);
        }

        public static CmdProcess process(FS.FilePath path, CmdKind kind, string args)
            => process(Cmd.cmdline(path,kind,args));

        [Op]
        public static CmdProcess process(CmdLine command, CmdProcessOptions config)
            => new CmdProcess(command, config);        
    }
}