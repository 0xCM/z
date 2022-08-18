//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines lower/upper bounds for <see cref='ulong'/> values
    /// </summary>
    [SymSource("limits", NumericBaseKind.Base16)]
    public enum Limits64u : ulong
    {
        /// <summary>
        /// The minimum representable <see cref='ulong'/> value
        /// </summary>
        Min = ulong.MinValue,

        /// <summary>
        /// The maximum representable <see cref='ulong'/> value
        /// </summary>
        Max = ulong.MaxValue,
    }
}