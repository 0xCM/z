//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class WfInit
    {
        public ReadOnlySeq<string> Args;
        
        public LogSettings LogConfig;

        public IApiCatalog ApiCatalog;

        public TokenDispenser Tokens;

        public IEventBroker EventBroker;

        public KillMe Host;

        public IWfEmissions EmissionLog;
    }
}