//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using global;

    public class XedProject : WfSvc<XedProject>
    {
        public IDbArchive Root() 
            => AppSettings.Sdks().Scoped("intel.xed");
        
        public IDbArchive Build()
            => Root().Scoped("build");

        public IEnumerable<FilePath> Artifacts()
            => Build().Enumerate(true);

        public IDbArchive Kit()
            => Build().Scoped("wkit");

        public IEnumerable<FilePath> KitHeaders()
            => Kit().Scoped("include/xed").Enumerate(true,FileKind.H);
    }
}