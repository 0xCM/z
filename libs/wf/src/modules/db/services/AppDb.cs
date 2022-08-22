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
        public static readonly Timestamp Ts = Algs.timestamp();

        public static AppDb Service => Instance;

        readonly AppSettings _Settings;

        public IDbArchive EnvRoot()
            => Datasets.archive(folder(_Settings.Setting(Names.EnvRoot)));

        public IDbArchive Control()
            => EnvRoot().Scoped("control");

        public IDbArchive DbRoot()
            => EnvRoot().Scoped("db");

        public IDbArchive Dev()
            => EnvRoot().Scoped("dev");

        public IDbArchive Archives()
            => EnvRoot().Scoped("archives");

        public IDbArchive Tools()
            => EnvRoot().Scoped("tools");

        public IDbArchive Repos()
            => EnvRoot().Scoped("repos");

        public IDbArchive DbIn()
            => DbRoot().Scoped("sources");

        public IDbArchive DbOut()
            => DbRoot().Scoped("targets");

        public IDbArchive Logs()
            => DbRoot().Scoped("logs");

        public IDbArchive AsmDb()
            => DbOut().Scoped("asm.db");

        public IDbArchive Capture()
            => DbRoot().Scoped("capture");

        public IDbArchive EnvSpecs()
            => DbRoot().Scoped("env");

        public IDbArchive DevOps()
            => EnvRoot().Scoped("devops");

        public IDbArchive DevOps(string scope)
            => DevOps().Scoped(scope);

        public IDbArchive AppData()
            => DbRoot().Scoped("apps").Scoped(ExecutingPart.Id.Format());

        public IDbArchive AppData(string scope)
            => AppData().Scoped(scope);

        public IDbArchive Settings()
            => DbRoot().Scoped("settings");

        public IDbArchive Catalogs()
            => DbRoot().Scoped("catalogs");

        public IDbArchive DbOut(string scope)
            => DbOut().Scoped(scope);

        public IDbArchive ApiTargets()
            => DbOut().Scoped("api");

        public IDbArchive ApiTargets(string scope)
            => DbOut($"api/{scope}");

        public IDbArchive EtlTargets(ProjectId project)
            => DbOut().Scoped("projects").Scoped(project.Format());

        public IDbArchive SlnRoot()
            => Dev().Scoped("z0");

        public IDbArchive Jobs()
            => DbRoot().Scoped("jobs");

        public IDbArchive Jobs(string scope)
            => Jobs().Scoped(scope);

        public IDbArchive EnvConfig()
            => DbRoot().Scoped("env");

        public IDbArchive AsmDb(string scope)
            => AsmDb().Scoped(scope);

        public FS.FilePath Settings(string name, FileKind kind)
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
            => DbIn().Scoped(scope);

        public IDbArchive Logs(string scope)
            => Logs().Scoped(scope);

        public IDbArchive Control(string scope)
            => Control().Scoped(scope);

        public IDbArchive Dev(string scope)
            => Dev().Scoped(scope);

        public IDbArchive Tools(string scope)
            => Tools().Scoped(scope);
            
        public IDbArchive CgRoot()
            => Dev().Scoped("z0/cg");

        public IDbArchive CgStage()
            => DbOut("cgstage");

        public IDbArchive CgStage(string scope)
            => DbOut("cgstage").Scoped(scope);

        public FS.FilePath Settings<T>()
            where T : struct
                => Settings().Table<T>();

        public IProjectWorkspace EtlSource(ProjectId src)
            => ProjectWorkspace.load(Dev($"llvm.models/{src}"), src);

        public FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct
                => EtlTargets(project).Table<T>(project.Format());

        public FS.FilePath EtlTable(ProjectId project, string name)
            => EtlTargets(project).Path($"{project}.{name}", FileKind.Csv);

        public IDbArchive Toolbase()
            => Datasets.archive(folder(_Settings.Setting(Names.Toolbase)));  

        public IDbArchive Toolbase(string scope)
            => Datasets.archive(Toolbase().Sources(scope));

        public IDbArchive LlvmRoot()
            => Datasets.archive(folder(_Settings.Setting(Names.LlvmRoot)));

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