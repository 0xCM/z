//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckSettings
    {
        int RepCount => 128;

        /// <summary>
        /// Specifies whether the test is enabled
        /// </summary>
        bool Enabled  => true;

        /// <summary>
        /// The number times to repeat an action
        /// </summary>
        int CycleCount => Pow2.T03;

        /// <summary>
        /// The number of times to repeat a cycle
        /// </summary>
        int RoundCount => Pow2.T01;
    }
}