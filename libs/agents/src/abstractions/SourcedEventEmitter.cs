//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines base type for event originators
    /// </summary>
    public abstract class SourcedEventEmitter : Agent
    {
        protected SourcedEventEmitter(IAgentContext Context, AgentIdentity Identity)
            :base(Context,Identity)
        {

        }
    }
}