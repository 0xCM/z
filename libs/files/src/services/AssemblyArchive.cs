//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Loader;
    using System.Linq;

    public sealed class AssemblyArchive : AssemblyLoadContext, IDisposable
    {
        public static AssemblyArchive init()
            => rooted(ExecutingPart.Assembly);

        public static AssemblyArchive rooted(Assembly src)
            => new AssemblyArchive(src.Path());

        public static AssemblyArchive rooted(FilePath src)
            => new AssemblyArchive(src);

        public static Assembly load(AssemblyArchive archive, FilePath src)
            => archive.LoadFromAssemblyPath(src.Name);

        public static ReadOnlySeq<Assembly> deps(AssemblyArchive archive, Assembly src)
            => deps(archive, src, src.Path().FolderPath).Distinct().ToSeq();

        public static IEnumerable<Assembly> deps(AssemblyArchive archive, Assembly src, FolderPath location)
        {
            var names = src.ReferenceNames();
            foreach(var name in names)
            {
                var component = load(archive, name.DllPath(location));
                yield return component;
                foreach(var r in deps(archive, component, location))
                    yield return r;
            }
        }

        public readonly DbArchive Root;

        public readonly Assembly Component;

        public readonly ReadOnlySeq<Assembly> Dependencies;

        public AssemblyArchive(FilePath src)
            : base(true)
        {
            Root = src.FolderPath;
            Component = LoadFromAssemblyPath(src.Name);
            Dependencies = deps(this, Component);
        }


        public void Dispose()
        {
            Unload();
        }
    }
}