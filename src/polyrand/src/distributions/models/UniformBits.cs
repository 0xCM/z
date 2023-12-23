//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a uniform distribution
    /// </summary>
    /// <typeparam name="T">The sample value type</typeparam>
    /// <remarks>See https://en.wikipedia.org/wiki/Uniform_distribution</remarks>
    public readonly struct UniformBitsSpec<T> :  IDistributionSpec<T>
        where T : unmanaged
    {
        /// <summary>
        /// Classifies the distribution spec
        /// </summary>
        public DistributionKind DistKind
            => DistributionKind.UniformBits;

        [MethodImpl(Inline)]
        public UniformBitsSpec<uint> ToUInt32()
            => new ();

        [MethodImpl(Inline)]
        public UniformBitsSpec<ulong> ToUInt64()
            => new ();
   }
}