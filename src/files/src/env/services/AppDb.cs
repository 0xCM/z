//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Names = SettingNames;

    public class AppDb
    {
        public static readonly Timestamp Ts = sys.timestamp();

        public static AppDb Service => Instance;

        readonly AppSettings Data;

        public DbArchive DbRoot()
            => Data.DbRoot();

        public DbArchive Dev()
            => Data.DevRoot();

        public DbArchive DevOps()
            => Data.DevOps();

        public DbArchive Capture()
            => Data.Capture();

        public DbArchive Archives()
            => Data.Archives();

        public DbArchive Tools()
            => folder(Data.Setting(SettingNames.DevTools));

        public DbArchive DbSources()
            => DbRoot().Scoped("sources");

        public DbArchive DbSources(string scope)
            => DbSources().Scoped(scope);

        public DbArchive DbTargets()
            => DbRoot().Scoped("targets");

        public DbArchive DbTargets(string scope)
            => DbTargets().Scoped(scope);

        public DbArchive DbIn()
            => DbRoot().Scoped("sources");

        public DbArchive DbOut()
            => DbRoot().Scoped("targets");

        public DbArchive DbOut(string scope)
            => DbTargets().Scoped(scope);

        public DbArchive Logs()
            => DbRoot().Scoped("logs");

        public DbArchive AsmDb()
            => DbTargets().Scoped("asm.db");

        public DbArchive AsmDb(string scope)
            => AsmDb().Scoped(scope);

        // public IEnvDb EnvDb()
        //     => new (Data.EnvDb());

        public DbArchive EnvSpecs()
            => DbRoot().Scoped("env");

        public DbArchive DevOps(string scope)
            => DevOps().Scoped(scope);

        public DbArchive AppData()
            => DbRoot().Scoped("apps").Scoped(ExecutingPart.Name.Format());

        public DbArchive AppData(string scope)
            => AppData().Scoped(scope);

        public DbArchive Settings()
            => DbRoot().Scoped("settings");

        public DbArchive Catalogs()
            => DbRoot().Scoped("catalogs");

        public DbArchive ApiTargets()
            => DbTargets().Scoped("api");

        public DbArchive ApiTargets(string scope)
            => DbTargets($"api/{scope}");

        public DbArchive EtlTargets(string name)
            => DbTargets().Scoped("projects").Scoped(name);

        public DbArchive SlnRoot()
            => Dev().Scoped("z0");

        public DbArchive Jobs()
            => DbRoot().Scoped("jobs");

        public DbArchive Jobs(string scope)
            => Jobs().Scoped(scope);

        public DbArchive Env()
            => DbRoot().Scoped("env");

        public FilePath Settings(string name, FileKind kind)
            => Settings().Path(name,kind);

        public DbArchive Archive(string name)
            => Archives().Scoped(name);

        public DbArchive ProjectRoot<T>(string area, T name)
            => SlnRoot().Scoped($"{area}/{name}");

        public DbArchive ProjectLib<T>(T name)
            => ProjectRoot("libs", name);

        public DbArchive Catalogs(string scope)
            => Catalogs().Scoped(scope);

        public DbArchive DbIn(string scope)
            => DbSources().Scoped(scope);

        public DbArchive Logs(string scope)
            => Logs().Scoped(scope);

        public DbArchive Dev(string scope)
            => Dev().Scoped(scope);

        public DbArchive Tools(string scope)
            => Tools().Scoped(scope);
            
        public DbArchive CgRoot()
            => Dev().Scoped("z0/cg");

        public DbArchive CgStage()
            => DbTargets("cgstage");

        public DbArchive CgStage(string scope)
            => DbTargets("cgstage").Scoped(scope);

        public FilePath EtlTable<T>(string name)
            where T : struct
                => EtlTargets(name).Table<T>(name);

        public FilePath EtlTable(string scope, string name)
            => EtlTargets(scope).Path($"{scope}.{name}", FileKind.Csv);

        public DbArchive Toolbase()
            => folder(Data.Setting(Names.Toolbase));  

        public DbArchive Toolbase(string scope)
            => Toolbase().Sources(scope);

        public DbArchive LlvmRoot()
            => folder(Data.Setting(Names.LlvmRoot));

        [MethodImpl(Inline)]
        static FolderPath folder(in Setting src)
            => FS.dir(src.ValueText);

        AppDb()
        {
            Data = AppSettings.Default;
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}