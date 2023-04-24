//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class CatalogFilesJob : AnalyticsJob<CatalogFilesJob>
    {
        IDbArchive Source;
        
        IDbArchive Target;

        public CatalogFilesJob()
        {
            
        }

        public CatalogFilesJob WithSource(IDbArchive src)
        {
            Source = src;
            return this;
        }

        public CatalogFilesJob WithTarget(IDbArchive dst)
        {
            Target = dst;
            return this;
        }

        ExecToken Flow()
        {
            return default;
        }

        public override Task<ExecToken> Run()
            => sys.start(Flow);
    }
}