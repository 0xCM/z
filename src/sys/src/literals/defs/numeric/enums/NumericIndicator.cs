//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines character representations of the partitions identified by the NumericClass kind
    /// </summary>
    [SymSource(numeric)]
    public enum NumericIndicator : byte
    {
        None = 0,

        /// <summary>
        /// i: Indicates a signed integral type
        /// </summary>
        Signed = AsciCode.i,

        /// <summary>
        /// 'f': Indicates a floating-point type
        /// </summary>
        Float = AsciCode.f,

        /// <summary>
        /// 'u': Indicates an unsigned integral type
        /// </summary>
        Unsigned =  AsciCode.u,
    }
}