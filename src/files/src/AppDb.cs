//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Settings;

    using Names = SettingNames;

    public class AppDb : IAppDb
    {
        public static readonly Timestamp Ts = sys.timestamp();

        public static AppDb Service => Instance;

        readonly AppSettings _Settings;

        public DbArchive EnvRoot()
            => folder(_Settings.Setting(SettingNames.EnvRoot));

        public DbArchive Control()
            => folder(_Settings.Setting(SettingNames.Control));

        public DbArchive DbRoot()
            => folder(_Settings.Setting(SettingNames.DbRoot));

        public DbArchive Dev()
            => folder(_Settings.Setting(SettingNames.DevRoot));

        public DbArchive DevOps()
            => folder(_Settings.Setting(SettingNames.DevOps));

        public DbArchive ProcDumps()
            => folder(_Settings.Setting(SettingNames.ProcDumps));

        public DbArchive Archives()
            => EnvRoot().Scoped("archives");

        public DbArchive Tools()
            => EnvRoot().Scoped("tools");

        public DbArchive Repos()
            => EnvRoot().Scoped("repos");

        public DbArchive DbIn()
            => DbRoot().Scoped("sources");

        public DbArchive DbOut()
            => DbRoot().Scoped("targets");

        public DbArchive Logs()
            => DbRoot().Scoped("logs");

        public DbArchive AsmDb()
            => DbOut().Scoped("asm.db");

        public DbArchive Capture()
            => DbRoot().Scoped("capture");

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

        public DbArchive DbTargets(string scope)
            => DbOut().Scoped(scope);

        public DbArchive ApiTargets()
            => DbOut().Scoped("api");

        public DbArchive ApiTargets(string scope)
            => DbTargets($"api/{scope}");

        public DbArchive EtlTargets(ProjectId project)
            => DbOut().Scoped("projects").Scoped(project.Format());

        public DbArchive SlnRoot()
            => Dev().Scoped("z0");

        public DbArchive Jobs()
            => DbRoot().Scoped("jobs");

        public DbArchive Jobs(string scope)
            => Jobs().Scoped(scope);

        public DbArchive EnvConfig()
            => DbRoot().Scoped("env");

        public DbArchive AsmDb(string scope)
            => AsmDb().Scoped(scope);

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
            => DbIn().Scoped(scope);

        public DbArchive Logs(string scope)
            => Logs().Scoped(scope);

        public DbArchive Control(string scope)
            => Control().Scoped(scope);

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

        public FilePath Settings<T>()
            where T : struct
                => Settings().Table<T>();

        public IProjectWorkspace EtlSource(ProjectId src)
            => Projects.load(Dev($"llvm.models/{src}").Root, src);

        public FilePath EtlTable<T>(ProjectId project)
            where T : struct
                => EtlTargets(project).Table<T>(project.Format());

        public FilePath EtlTable(ProjectId project, string name)
            => EtlTargets(project).Path($"{project}.{name}", FileKind.Csv);

        public DbArchive Toolbase()
            => folder(_Settings.Setting(Names.Toolbase));  

        public DbArchive Toolbase(string scope)
            => Toolbase().Sources(scope);

        public DbArchive LlvmRoot()
            => folder(_Settings.Setting(Names.LlvmRoot));

        AppDb()
        {
            _Settings = AppSettings.Default;
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}