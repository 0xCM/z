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

    public class DataAnalyzer : WfSvc<DataAnalyzer>
    {
        public ExecToken Run(IDbArchive src, IDbArchive dst)
        {            
            var result = Channel.Channeled<CatalogFilesJob>().WithSource(src).WithTarget(dst).Run().Result;
            return result;
        }
    }
}