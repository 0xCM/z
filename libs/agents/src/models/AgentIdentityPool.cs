//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AgentIdentityPool
    {
        const uint FirstAgentId = 1;

        const uint FirstServerId = 1;

        /// <summary>
        /// Retrieves the next server-relative agent identity
        /// </summary>
        /// <param name="ServerId">The owning server</param>
        [MethodImpl(Inline)]
        public static AgentIdentity NextAgentId(uint ServerId)
            => (ServerId, TheOnly.Agents.AddOrUpdate(ServerId, _ => FirstAgentId, (_,v) => ++v));

        /// <summary>
        /// Retrieves the next server id
        /// </summary>
        public static uint NextServerId()
            => (uint)Interlocked.Increment(ref TheOnly.LastServerId);

        int LastServerId = (int)(FirstServerId - 1);

        static AgentIdentityPool TheOnly = new AgentIdentityPool();

        ConcurrentDictionary<uint,uint> Agents {get;}
            = new ConcurrentDictionary<uint, uint>();

        AgentIdentityPool()
        {

        }
    }
}