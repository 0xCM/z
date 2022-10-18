//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static AppCmdNames;

    public readonly struct AppCmdNames
    {   
        const string Sep = "/";

        public const string files = nameof(files);

        public const string copy = nameof(copy);

        public const string files_copy = files + Sep + copy;
    }

    public class AppCmd
    {
        [MethodImpl(Inline), Op]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var kind = CmdKind.App;
            var host = src.DeclaringType;
            var part = host.Assembly.PartName().Format();
            var attrib = src.Tag<CmdOpAttribute>();
            var name = attrib.MapValueOrElse(a => a.Name, () => src.DisplayName());
            return uri(kind,part, host.DisplayName(), name);        
        }

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AppCmdSpec dst)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new AppCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = sys.@string(SQ.left(src,i));
                var _args = sys.@string(SQ.right(src,i)).Split(Chars.Space);
                dst = new AppCmdSpec(name, Cmd.args(_args));
            }
            return true;
        }

        public static CmdUriSeq uri<S>(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var part = src.Controller;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<defs.Count; i++)
                seek(dst,i) = defs[i].Uri;
            return dst;            
        }

        [Op]
        public static AppCmdRunner runner(string name, object host, MethodInfo method)
            => new AppCmdRunner(name, host, method);

        public static ConstLookup<Name,AppCmdDef> defs(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var dst = dict<Name,AppCmdDef>();
            iter(defs.View, def => dst.Add(def.CmdName, def));
            return dst;
        }

        public static AppCmdDef def(object host, MethodInfo method)
        {
            var attrib = method.Tag<CmdOpAttribute>().Require();
            return new AppCmdDef(attrib.Name, AppCmdRunner.classify(method), method, host);
        }

        [Op]
        public static ReadOnlySeq<AppCmdRunner> runners(object host)
        {
            var methods = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<AppCmdRunner>(methods.Length);
            runners(host, methods, dst);
            return dst;
        }

        static void runners(object host, ReadOnlySpan<MethodInfo> src, Span<AppCmdRunner> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = runner(tag.Name, host, method);
            }
        }

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";        

        public static IAppCmdDispatcher dispatcher<T>(T service, WfEmit channel, ReadOnlySeq<ICmdProvider> providers)
        {
            var flow = channel.Running($"Discovering {service} dispatchers");
            var dst = dict<string,IAppCmdRunner>();
            iter(runners(service), r => dst.TryAdd(r.Def.CmdName, r));
            iter(providers, p => iter(runners(p), r => dst.TryAdd(r.Def.CmdName, r)));            
            return new AppCmdDispatcher(channel, providers, new AppCommands(dst));
        }        

        public static AppCommands distill(IAppCommands[] src)
        {
            var dst = dict<string,IAppCmdRunner>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
            return new AppCommands(dst);
        }

        public static void emit(ICmdSource src, WfEmit channel, FilePath dst)
        {
            var flow = channel.EmittingFile(dst);
            var commands = src.Commands;
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var fmt = cmd.Format();
                channel.Row(fmt);
                writer.WriteLine(fmt);
            }

            channel.EmittedFile(flow, src.Count);
        }

        public static void emit(CmdCatalog src, FilePath dst, WfEmit channel)
        {
            var data = src.Entries;
            iter(data, x => channel.Row(x.Uri.Name));
            Tables.emit(channel, data.View, dst);
        }

        public static CmdCatalog catalog(IAppCmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        static ReadOnlySeq<CmdCatalogEntry> entries(CmdUriSeq src)    
        {
            var entries = alloc<CmdCatalogEntry>(src.Count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var uri = ref src[i];
                ref var entry = ref seek(entries,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            return entries.Sort().Resequence();        
        }        

        [ApiComplete("api.files")]
        public class files
        {
            [Api]
            public static Copy copy(FolderPath src, FolderPath dst)
                => new (src,dst);

            [Api]
            public static Zip zip(FolderPath src, FilePath dst)
                => new (src,dst);

            [Cmd(files_copy)]
            public struct Copy : ICmd<Copy>
            {
                public Copy(FolderPath src, FolderPath dst)
                {
                    Source = src;
                    Target = dst;
                }

                public FolderPath Source;

                public FolderPath Target;
            }

            [Cmd(files_copy)]
            public struct Zip : ICmd<Zip>
            {
                public Zip(FolderPath src, FilePath dst)
                {
                    Source = src;
                    Target = dst;
                }

                public FolderPath Source;

                public FilePath Target;
            }
        }
    }
}