//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Windows;

    [ApiHost]
    public class Env
    {
        static AppSettings AppSettings => AppSettings.Default;

        public static EnvVar<EnvPath> INCLUDE()
            => new (EnvTokens.INCLUDE, path(EnvPathKind.Include));

        public static EnvVar<EnvPath> LIB()
            => new (EnvTokens.LIB, path(EnvPathKind.Lib));

        public static EnvVar<EnvPath> PATH()
            => new (EnvTokens.PATH, path(EnvPathKind.Bin));

        public static IDbArchive root()
            => AppSettings.EnvRoot();

        public static EnvId id()
            => EnvId;
        
        public static EnvId id(EnvId src)
        {
            EnvId = src;
            return EnvId;
        }

        static EnvId EnvId 
        {
            get => var(EnvVarKind.Process, EnvTokens.EnvId, x => new EnvId(x));
            set => apply(new EnvVar(EnvTokens.EnvId, value.Format()), EnvVarKind.Process);
        }

        public static IDbArchive ShellData
            => AppSettings.EnvDb().Scoped("shells");

        public static IEnvDb db(FolderPath root)
            => new EnvDb(root);

        public static IEnvDb db()
            => AppSettings.EnvDb();

        public static ProcessId pid() 
            => ProcessId.current();

        public static CpuCore cpucore()
            => new(Kernel32.GetCurrentProcessorNumber());

        public static ThreadId tid()
            => new(Kernel32.GetCurrentThreadId());

        public static FolderPath cd()
            => new(text.ifempty(Environment.CurrentDirectory, AppSettings.Control().Root.Format()));

        public static FolderPath cd(CmdArgs args)
        {
            if(args.Length == 1)
                Environment.CurrentDirectory = args.First.Value;
            return cd();
        }

        public static void cd(FolderPath dst)
            => Environment.CurrentDirectory = dst.Format(PathSeparator.BS);

        // public static EnvPath path(string name, EnvVarKind kind = EnvVarKind.Process)
        // {
        //     var value = Environment.GetEnvironmentVariable(name, (EnvironmentVariableTarget)kind);
        //     var values = text.split(value,Chars.Semicolon);
        //     return map(values, FS.dir);
        // }

        public static string varname(EnvPathKind kind)
            => kind switch {
              EnvPathKind.Bin => EnvTokens.PATH,
              EnvPathKind.Include => EnvTokens.INCLUDE,
              EnvPathKind.Lib => EnvTokens.LIB,
                _ => EmptyString
            };

        public static EnvPath path(EnvPathKind kind, EnvVarKind varkind = EnvVarKind.Process)
        {
            var name = varname(kind);
            var value = Environment.GetEnvironmentVariable(name, (EnvironmentVariableTarget)varkind);
            var folders = map(text.split(value,Chars.Semicolon), FS.dir);
            return new EnvPath(kind, folders);
        }

        public static ExecToken<EnvPath> emit(IWfChannel channel, EnvPath src, IDbArchive dst)
        {
            var data = src.Delimit(Chars.NL);
            var emitted = channel.FileEmit(data, dst.Path(FS.file($"paths.{src.Kind}", FileKind.List)));
            return (emitted, src);
        }

        public static ExecToken<EnvPath> path(IWfChannel channel, EnvPathKind kind, IDbArchive dst, EnvVarKind envkind = EnvVarKind.Process)
        {            
            return emit(channel, path(kind,envkind), dst);
            // var name = varname(kind);
            // var folders = path(kind, envkind);
            // var data = folders.Delimit(Chars.NL);
            // channel.Row(data);
            // var emitted = channel.FileEmit(data, dst.Path(FS.file($"paths.{kind}", FileKind.List)));
            // return (emitted, folders);
        }

        public static EnvVar<T> var<T>(string name, Func<string,T> parser)
            where T : IEquatable<T>
                => var(EnvVarKind.Process, name, parser);

        public static EnvVar<T> var<T>(EnvVarKind kind, string name, Func<string,T> parser)
            where T : IEquatable<T>
        {
            var dst = EnvVar<T>.Empty;
            var value = Environment.GetEnvironmentVariable(name, (EnvironmentVariableTarget)kind);
            if(nonempty(value))
                dst = new(name,parser(value));
            return dst;
        }

        public static EnvVars vars(EnvVarKind kind)
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables((EnvironmentVariableTarget)kind))
                 dst.Add(new EnvVar(kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ToArray().Sort();
        }
        
        public static EnvVars machine()
            => vars(EnvVarKind.Machine);

        public static EnvVars user()
            => vars(EnvVarKind.User);

        public static EnvVars process()
            => vars(EnvVarKind.Process);

        public static void apply(EnvVar src, EnvVarKind kind)
            => Environment.SetEnvironmentVariable(src.Name, src.Value, (EnvironmentVariableTarget)kind);

        public static ToolCatalog tools(bool reload = false)
        {
            if(_Tools == null || reload)
            {
                var paths = Env.path(EnvPathKind.Bin).Delimit(Chars.NL);
                var buffer = hashset<LocatedTool>();
                iter(paths, dir => {
                    iter(FS.files(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {                
                        var include = path.FolderPath != FS.dir("C:/WINDOWS/System32/");
                        include &= (path.FolderPath != FS.dir("C:/WINDOWS"));
                        if(include)
                        {
                            buffer.Add(located(path));
                        }
                    });
                });

                _Tools = new (buffer.Array().Sort());
            }
            return _Tools;
        }       
 
        public static EnvVars merge(EnvVars a, EnvVars b)
        {
            var dst = a.View.Map(x => (x.Name, x)).ToDictionary();
            iter(b.View, v => {
                var name = v.Name;
                switch(name)
                {
                    case EnvTokens.PATH:
                    case EnvTokens.LIB:
                    case EnvTokens.INCLUDE:
                        dst[name] = new (name,text.join(';',v.Value, dst[name]));
                    break;
                }
            });
            return dst.Values.Array();
        }

        static ToolCatalog _Tools;

        static uint KeySeq = 0;
        
        static LocatedTool located(FilePath path)
            => new(inc(ref KeySeq), path);
    }
}