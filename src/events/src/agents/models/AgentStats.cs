//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AgentStats
    {
        public readonly int AgentCount;

        [MethodImpl(Inline)]
        public AgentStats(int count)
        {
            AgentCount = count;
        }
    }
}