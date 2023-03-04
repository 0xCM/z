//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static ApiAtomic;

    public class LlvmPaths : WfSvc<LlvmPaths>
    {
        public DbArchive Targets()
            => AppDb.DbTargets(llvm);

        public DbArchive Targets(string scope)
            => Targets().Targets(scope);

        public DbArchive Sources()
            => AppDb.DbSources(llvm);

        public DbArchive Sources(string scope)
            => Sources().Sources(scope);

        public DbArchive TestResultTargets()
            => Targets(tests);

        public DbArchive TestResultSources()
            => Sources(logs);

        public DbArchive Tables()
            => Targets(tables);

        public FilePath DbTable<T>()
            where T : struct
                => Tables().Table<T>();

        public FilePath DbTable<T>(string prefix)
            where T : struct
                => Tables().PrefixedTable<T>(prefix);

        public FilePath DbTable(string id)
            => Tables().Path(FS.file(id, FS.Csv));

        public DbArchive LineMaps()
            => Targets("maps");

        public DbArchive ToolImports()
            => Targets(tools);

        public FilePath RecordMap(string project, string kind)
            => Targets("maps").Path($"{project}.{kind}",FileKind.Map);

        public FilePath RecordSource(string project, string kind)
            => Sources("records").Path($"{project}.{kind}", FileKind.Txt);

        public ListedFiles RecordFiles()
            => Archives.listing(Sources("records").Files());

        public ListedFiles RecordFiles(string project)
            => Archives.listing(Sources("records").Sources(project).Files());

        public DbArchive QueryOut()
            => Targets(queries);

        public FilePath QueryOut(string name, FileKind kind)
            => QueryOut(FS.file(name,kind));

        public FilePath QueryOut(FileName file)
            => QueryOut().Path(file);

        public FilePath LineMap(string name)
            => LineMaps().Path(name, FileKind.Map);

        public FilePath LineMap(string project, string name)
            => LineMaps().Path($"{project}.{name}", FileKind.Map);

        public FilePath TableGenHeader(LlvmTargetName target, string kind)
            => LlvmSources(include).Path($"{target}.{kind}", FileKind.H);

        public Files TableGenHeaders(LlvmTargetName target)
            => LlvmSources(include).Files(FileKind.H).Array().Where(f => f.FileName.StartsWith($"{target}."));

        public IDbArchive LlvmRoot
            => AppDb.LlvmRoot();
        
        public IDbArchive LlvmSources(string scope)
            => AppDb.DbSources(llvm).Sources(scope);

        public IDbArchive Records(string project)
            => Sources("records").Sources(project);

        public IDbArchive HelpSouces()
            => Sources("docs/help");

        public IDbArchive SourceSettings()
            => Sources("settings");

        public FilePath RecordSet(string project, string name)
            => Records(project).Path($"{project}.{name}.records", FileKind.Txt);

        public FilePath RecordSet(string project, LlvmTargetName target)
            => Records(project).Path($"{project}.{target}.records", FileKind.Txt);

        public FilePath File(string scope, string name, FileKind kind)
            => Targets(scope).Path(name, kind);

        public Files Lists()
            => Tables().Files(FileKind.Csv).Where(f => f.FileName.StartsWith("llvm.lists."));

        public Index<string> ListNames()
            => Lists().Map(x => x.FileName.WithoutExtension.Format().Remove("llvm.lists."));

        public FilePath ListTargetPath(string name)
            => DbTable(string.Format("llvm.lists.{0}", name));

        public DbArchive CodeGen()
            => AppDb.CgRoot().Targets("cg.llvm/src");
    }
}