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

        readonly ProjectSettings WsArchives;

        public IDbSources Settings()
            => DbRoot().Sources("settings");

        public FS.FilePath Settings(string name, FileKind kind)
            => Settings().Path(name,kind);

        public IDbArchive Jobs()
            => DbRoot().Scoped("jobs");
            
        public IDbArchive Jobs(string scope)
            => Jobs().Scoped(scope);

        public FS.FilePath Settings<T>()
            where T : struct
                => Settings().Table<T>();

        public IDbArchive AsmDb()
            => Datasets.archive(DbOut().Targets("asm.db"));

        public IDbArchive AsmDb(string scope)
            => AsmDb().Scoped(scope);

        public FS.FilePath SettingsPath(string name, FileKind kind)
            => Settings().Path(name,kind);

        public FS.FilePath SettingsPath<S>(FileKind kind)
            => Settings().Path(Z0.Settings.name<S>(), kind);

        public IDbArchive Archives()
            => Datasets.archive(setting(WsArchives.Path(Names.Archives), FS.dir));

        public IDbArchive Archive(string name)
            => Datasets.archive(Archives().Sources(name).Root);

        public IDbSources LlvmRoot()
            => Datasets.archive(setting(WsArchives.Path(Names.LlvmRoot), FS.dir));

        public IDbSources LlvmDist()
            => Datasets.archive(setting(WsArchives.Path(Names.LlvmDist), FS.dir));

        public IDbTargets DbOut()
            => Datasets.archive(setting(WsArchives.Path(Names.DbTargets), FS.dir));

        public IDbArchive Repos()
            => Datasets.archive(setting(WsArchives.Path(Names.Repos), FS.dir));

        public IDbArchive Symbols()
            => Datasets.archive(setting(WsArchives.Path(Names.Repos), FS.dir));

        public IDbArchive Env()
            => Datasets.archive(DbRoot().Targets("env"));

        public IDbArchive Repos(string scope)
            => Repos().Scoped(scope);

        public IDbTargets DbOut(string scope)
            => DbOut().Targets(scope);

        public IDbTargets Apps()
            => DbRoot().Targets("apps");

        public IDbTargets Commands()
            => DbRoot().Targets("commands");

        public IDbArchive Catalogs()
            => Datasets.archive(DbRoot().Sources("catalogs"));

        public IDbArchive SlnRoot()
            => Datasets.archive(setting(WsArchives.Path(Names.SlnRoot), FS.dir));

        public IDbArchive ProjectRoot<T>(string area, T name)
            => SlnRoot().Scoped($"{area}/{name}");

        public IDbArchive ProjectLib<T>(T name)
            => ProjectRoot("libs", name);

        public IDbArchive Catalogs(string scope)
            => Catalogs().Scoped(scope);

        public IDbTargets Commands(string scope)
            => Commands().Targets(scope);
        
        public IDbTargets App(PartId part)
            => Apps().Targets(part.Format());

        public IDbTargets App()
            => Apps().Targets(ExecutingPart.Id.Format());

        public IDbTargets App(string scope)
            => App().Targets(scope);

        public IDbTargets App(PartId part, string scope)
            => App(part).Targets(scope);

        public IDbSources DbIn()
            => Datasets.archive(setting(WsArchives.Path(Names.DbSources), FS.dir));

        public IDbSources DbCapture()
            => Datasets.archive(setting(WsArchives.Path(Names.DbCapture), FS.dir));

        public IDbSources DbIn(string scope)
            => DbIn().Sources(scope);

        public IDbTargets Logs()
            => Datasets.archive(setting(WsArchives.Path(Names.Logs), FS.dir));

        public IDbArchive DbRoot()
            => Datasets.archive(setting(WsArchives.Path(Names.DbRoot), FS.dir));

        public IDbTargets Logs(string scope)
            => Logs().Targets(scope);

        public IDbArchive Control()
            => new DbArchive(setting(WsArchives.Path(Names.Control), FS.dir));

        public IDbArchive Control(string scope)
            => Datasets.archive(Control().Sources(scope));

        public IDbArchive Tools()
            => Datasets.archive(setting(WsArchives.Path(Names.Tools), FS.dir));        

        public IDbSources Tools(string scope)
            => Tools().Sources(scope);

        public IDbArchive Views()
            => Datasets.archive(setting(WsArchives.Path(Names.Views), FS.dir));

        public IDbArchive Toolsets()
            => Views(toolsets);

        public IDbArchive Toolset(string name)
            => Datasets.archive(Views(toolsets).Sources(name));

        public IDbArchive Views(string scope)
            => Datasets.archive(Views().Sources(scope));

        public IDbArchive Toolbase()
            => Toolset(toolbase);

        public IDbArchive Toolbase(string scope)
            => Datasets.archive(Toolbase().Sources(scope));
            
        public IDbSources Dev()
            => new DbSources(setting(WsArchives.Path(Names.DevRoot), FS.dir));

        public IDbSources Dev(string scope)
            => Dev().Sources(scope);

        public IDbTargets CgRoot()
            => new DbTargets(setting(WsArchives.Path(Names.CgRoot), FS.dir));

        public IDbArchive Capture()
            => Datasets.archive(setting(WsArchives.Path(Names.DbCapture), FS.dir));

        public IDbSources EnvConfig()
            => new DbSources(setting(WsArchives.Path(Names.EnvConfig), FS.dir));

        public IProjectWorkspace EtlSource(ProjectId src)
            => ProjectWorkspace.load(Dev($"llvm.models/{src}"), src);

        public IDbTargets EtlTargets(ProjectId project)
            => DbOut().Targets("projects").Targets(project.Format());

        public FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct
                => EtlTargets(project).Table<T>(project.Format());

        public FS.FilePath EtlTable(ProjectId project, string name)
            => EtlTargets(project).Path($"{project}.{name}", FileKind.Csv);

        public IDbTargets CgStage()
            => DbOut("cgstage");

        public IDbTargets CgStage(string scope)
            => DbOut("cgstage").Targets(scope);

        public IDbTargets ApiTargets()
            => DbOut().Targets("api");

        public IDbTargets ApiTargets(string scope)
            => DbOut($"api/{scope}");

        AppDb()
        {
            WsArchives = ProjectSettings.load();
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}