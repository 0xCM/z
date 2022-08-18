//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines configuration parameters for pulse emission
    /// </summary>
    public readonly struct PulseEmitterConfig
    {
        /// <summary>
        /// Specifies the emission frequency
        /// </summary>
        public TimeSpan Frequency {get;}

        public PulseEmitterConfig(TimeSpan frequency)
            => Frequency = frequency;
    }
}