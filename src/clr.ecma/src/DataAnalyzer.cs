//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{   
    public abstract class AnalyticsJob<J> : Channeled<J>
        where J : AnalyticsJob<J>,new()
    {
        public abstract Task<ExecToken> Run();
    }

    class CatalogFilesJob : AnalyticsJob<CatalogFilesJob>
    {
        FileCatalogs FileArchives => Channel.Channeled<FileCatalogs>();

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
            var entries = FileArchives.Index(Source, Target);

            return entries;
        }

        public override Task<ExecToken> Run()
            => sys.start(Flow);
    }

    public class DataAnalyzer : WfSvc<DataAnalyzer>
    {
        public ExecToken Run(IDbArchive src, IDbArchive dst)
        {            
            var result = Channel.Channeled<CatalogFilesJob>().WithSource(src).WithTarget(dst).Run().Result;
            return result;
        }
    }
}