//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Build;

    using E = Microsoft.Build.Evaluation;
    using B = Build;

    [ApiHost]
    public partial class MsBuild : AppService<MsBuild>
    {
        const NumericKind Closure = UnsignedInts;

        ConcurrentDictionary<FilePath, ProjectSpec> ProjectLookup = new();

        [MethodImpl(Inline), Op]
        internal static B.Property property(E.ProjectProperty src)
            => new B.Property(src);

        [MethodImpl(Inline), Op]
        internal static ProjectItem item(E.ProjectItem src)
            => new ProjectItem(src);

        public ProjectSpec LoadProject(FilePath src)
            => ProjectLookup.GetOrAdd(src, Build.project);

        [Op]
        public static ProjectSpec resbytes()
        {
            var itemBuffer = alloc<IProjectItem>(4);
            var items = span(itemBuffer);
            // seek(items,0) = BuildSvc.resource("asm/**/*.asm");
            // seek(items,1) = BuildSvc.resource("docs/**/*.csv");
            // seek(items,2) = BuildSvc.resource("index/**/*.csv");
            // seek(items,3) = BuildSvc.resource("metadata/**/*.csv");
            var props = alloc<IProjectProperty>(4);
            return default;
        }
    }
}