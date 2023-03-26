//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LlvmSettings
    {
        readonly DbArchive Root;

        internal LlvmSettings(DbArchive root)
        {
            Root = root;
        }

        public IDbArchive LlvmRoot()
            => Root;

        public IDbArchive Vendor()
            => LlvmRoot().Scoped("vendor");

        public IDbArchive Kit()
            => Vendor().Scoped("kit");

        public IDbArchive Kit(string scope)
            => Kit().Scoped(scope);

        public IDbArchive Source()
            => LlvmRoot().Scoped("src");

        public IDbArchive Source(string scope)
            => Source().Scoped(scope);

        public IDbArchive Build()
            => LlvmRoot().Scoped("build");

        public IDbArchive Build(string scope)
            => Build().Scoped(scope);

        public FilePath Tool(string name)
            =>  Kit("bin").Path(FS.file(name,FileKind.Exe));
    }
}