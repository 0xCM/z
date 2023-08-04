//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAgent
    {
        /// <summary>
        /// Starts agent execution
        /// </summary>
        Task Start();

        /// <summary>
        /// Stops agent execution
        /// </summary>
        Task Stop();
    }
}