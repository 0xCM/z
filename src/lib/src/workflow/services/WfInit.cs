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

        public IWfEventBroker EventBroker;

        public WfHost Host;

        public IWfEmissions EmissionLog;
    }
}