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

        public static ref readonly AppSettings AppSettings
            => ref Service._Settings;

        public DbArchive Control()
            => _Settings.Control();

        public DbArchive DbRoot()
            => _Settings.DbRoot();

        public DbArchive Dev()
            => _Settings.DevRoot();

        public DbArchive DevOps()
            => _Settings.DevOps();

        public DbArchive ProcDumps()
            => _Settings.ProcDumps();

        public DbArchive Capture()
            => _Settings.Capture();

        public DbArchive DevPacks()
            => _Settings.DevPacks();

        public DbArchive Archives()
            => _Settings.Archives();

        public DbArchive DevProjects()
            => Dev().Scoped("projects");

        public DbArchive DevProject(string name)
            => DevProjects().Scoped(name);

        public DbArchive Tools()
            => folder(_Settings.Setting(SettingNames.DevTools));

        public DbArchive DbIn()
            => DbRoot().Scoped("sources");

        public DbArchive DbOut()
            => DbRoot().Scoped("targets");

        public DbArchive Logs()
            => DbRoot().Scoped("logs");

        public DbArchive AsmDb()
            => DbOut().Scoped("asm.db");

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