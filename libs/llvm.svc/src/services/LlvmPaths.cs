//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static ApiAtomic;

    public class LlvmPaths : WfSvc<LlvmPaths>
    {
        public IDbTargets Targets()
            => AppDb.DbOut(llvm);

        public IDbTargets Targets(string scope)
            => Targets().Targets(scope);

        public IDbSources Sources()
            => AppDb.DbIn(llvm);

        public IDbSources Sources(string scope)
            => Sources().Sources(scope);

        public IDbTargets TestResultTargets()
            => Targets(tests);

        public IDbSources TestResultSources()
            => Sources(logs);

        public IDbTargets Tables()
            => Targets(tables);

        public FS.FilePath DbTable<T>()
            where T : struct
                => Tables().Table<T>();

        public FS.FilePath DbTable<T>(string prefix)
            where T : struct
                => Tables().PrefixedTable<T>(prefix);

        public FS.FilePath DbTable(string id)
            => Tables().Path(FS.file(id, FS.Csv));

        public IDbTargets LineMaps()
            => Targets("maps");

        public IDbTargets ToolImports()
            => Targets(tools);

        public FS.FilePath RecordMap(string project, string kind)
            => Targets("maps").Path($"{project}.{kind}",FileKind.Map);

        public FS.FilePath RecordSource(string project, string kind)
            => Sources("records").Path($"{project}.{kind}", FileKind.Txt);

        public ListedFiles RecordFiles()
            => FS.listing(Sources("records").Files());

        public ListedFiles RecordFiles(string project)
            => FS.listing(Sources("records").Sources(project).Files());

        public IDbTargets QueryOut()
            => Targets(queries);

        public FS.FilePath QueryOut(string name, FileKind kind)
            => QueryOut(FS.file(name,kind));

        public FS.FilePath QueryOut(FS.FileName file)
            => QueryOut().Path(file);

        public FS.FilePath LineMap(string name)
            => LineMaps().Path(name, FileKind.Map);

        public FS.FilePath LineMap(string project, string name)
            => LineMaps().Path($"{project}.{name}", FileKind.Map);

        public FS.FilePath TableGenHeader(LlvmTargetName target, string kind)
            => LlvmSources(include).Path($"{target}.{kind}", FileKind.H);

        public FS.Files TableGenHeaders(LlvmTargetName target)
            => LlvmSources(include).Files(FileKind.H).Where(f => f.FileName.StartsWith($"{target}."));

        public IDbSources LlvmRoot
            => AppDb.LlvmRoot();
        
        public IDbSources LlvmSources(string scope)
            => AppDb.DbIn(llvm).Sources(scope);

        public IDbSources Records(string project)
            => Sources("records").Sources(project);

        public IDbSources HelpSouces()
            => Sources("docs/help");

        public IDbSources SourceSettings()
            => Sources("settings");

        public FS.FilePath RecordSet(string project, string name)
            => Records(project).Path($"{project}.{name}.records", FileKind.Txt);

        public FS.FilePath RecordSet(string project, LlvmTargetName target)
            => Records(project).Path($"{project}.{target}.records", FileKind.Txt);

        public FS.FilePath File(string scope, string name, FileKind kind)
            => Targets(scope).Path(name, kind);

        public FS.Files Lists()
            => Tables().Files(FileKind.Csv).Where(f => f.FileName.StartsWith("llvm.lists."));

        public Index<string> ListNames()
            => Lists().Map(x => x.FileName.WithoutExtension.Format().Remove("llvm.lists."));

        public FS.FilePath ListTargetPath(string name)
            => DbTable(string.Format("llvm.lists.{0}", name));

        public IDbTargets CodeGen()
            => AppDb.CgRoot().Targets("cg.llvm/src");
    }
}