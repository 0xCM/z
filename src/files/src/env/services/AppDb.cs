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

        public IEnvDb EnvDb
            => Data.EnvDb();

        public IDbArchive DbRoot()
            => Data.DbRoot();

        public IDbArchive Dev()
            => Data.DevRoot();

        public IDbArchive DevOps()
            => Data.DevOps();

        public IDbArchive Capture()
            => Data.Capture();

        public IDbArchive Archives()
            => Data.Archives();

        public IDbArchive Tools()
            => Data.Setting(SettingNames.DevTools).DbArchive();

        public IDbArchive DbSources()
            => DbRoot().Scoped("sources");

        public IDbArchive DbSources(string scope)
            => DbSources().Scoped(scope);

        public IDbArchive DbTargets()
            => DbRoot().Scoped("targets");

        public IDbArchive DbTargets(string scope)
            => DbTargets().Scoped(scope);

        public IDbArchive DbIn()
            => DbRoot().Scoped("sources");

        public IDbArchive DbOut()
            => DbRoot().Scoped("targets");

        public IDbArchive DbOut(string scope)
            => DbTargets().Scoped(scope);

        public IDbArchive Logs()
            => DbRoot().Scoped("logs");

        public IDbArchive AsmDb()
            => DbTargets().Scoped("asm.db");

        public IDbArchive AsmDb(string scope)
            => AsmDb().Scoped(scope);

        // public IEnvDb EnvDb()
        //     => new (Data.EnvDb());

        public IDbArchive EnvSpecs()
            => DbRoot().Scoped("env");

        public IDbArchive DevOps(string scope)
            => DevOps().Scoped(scope);

        public IDbArchive AppData()
            => DbRoot().Scoped("apps").Scoped(ExecutingPart.Name.Format());

        public IDbArchive AppData(string scope)
            => AppData().Scoped(scope);

        public IDbArchive Settings()
            => DbRoot().Scoped("settings");

        public IDbArchive Catalogs()
            => DbRoot().Scoped("catalogs");

        public IDbArchive ApiTargets()
            => DbTargets().Scoped("api");

        public IDbArchive ApiTargets(string scope)
            => DbTargets($"api/{scope}");

        public IDbArchive EtlTargets(string name)
            => DbTargets().Scoped("projects").Scoped(name);

        public IDbArchive SlnRoot()
            => Dev().Scoped("z0");

        public IDbArchive Jobs()
            => DbRoot().Scoped("jobs");

        public IDbArchive Jobs(string scope)
            => Jobs().Scoped(scope);

        public IDbArchive Env()
            => DbRoot().Scoped("env");

        public FilePath Settings(string name, FileKind kind)
            => Settings().Path(name,kind);

        public IDbArchive Archive(string name)
            => Archives().Scoped(name);

        public IDbArchive ProjectRoot<T>(string area, T name)
            => SlnRoot().Scoped($"{area}/{name}");

        public IDbArchive ProjectLib<T>(T name)
            => ProjectRoot("libs", name);

        public IDbArchive Catalogs(string scope)
            => Catalogs().Scoped(scope);

        public IDbArchive DbIn(string scope)
            => DbSources().Scoped(scope);

        public IDbArchive Logs(string scope)
            => Logs().Scoped(scope);

        public IDbArchive Dev(string scope)
            => Dev().Scoped(scope);

        public IDbArchive Tools(string scope)
            => Tools().Scoped(scope);
            
        public IDbArchive CgRoot()
            => Dev().Scoped("z0/cg");

        public IDbArchive CgStage()
            => DbTargets("cgstage");

        public IDbArchive CgStage(string scope)
            => DbTargets("cgstage").Scoped(scope);

        public FilePath EtlTable<T>(string name)
            where T : struct
                => EtlTargets(name).Table<T>(name);

        public FilePath EtlTable(string scope, string name)
            => EtlTargets(scope).Path($"{scope}.{name}", FileKind.Csv);

        public IDbArchive Toolbase()
            => Data.Setting(Names.Toolbase).DbArchive();  

        public IDbArchive Toolbase(string scope)
            => Toolbase().Sources(scope);

        public IDbArchive LlvmRoot()
            => Data.Setting(Names.LlvmRoot).DbArchive();

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