//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class WfInit
    {
        public LogSettings LogConfig;

        public IApiCatalog ApiCatalog;

        //public IJsonSettings Settings;

        public TokenDispenser Tokens;

        public IEventBroker EventBroker;

        public WfHost Host;

        public IWfEmissionLog EmissionLog;
    }
}