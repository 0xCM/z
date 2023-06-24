//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public class XedKit
    {
        readonly IDbArchive XedRoot;

        public XedKit(IDbArchive root)
        {
            XedRoot = root;
        }

        public IDbArchive Build()
            => XedRoot.Scoped("build");

        public IDbArchive Distribution()        
            => Build().Scoped("wkit");

        public ParallelQuery<FilePath> Artifacts()
            => Build().Enumerate(true).AsParallel();
        
        public ParallelQuery<FilePath> Headers()
            => Distribution().Scoped("include/xed").Enumerate(true, FileKind.H).AsParallel();
    }
}