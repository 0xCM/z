//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines lower/upper bounds for <see cref='long'/> values
    /// </summary>
    [SymSource("limits", NumericBaseKind.Base16)]
    public enum Limits64i : long
    {
        /// <summary>
        /// The minimum representable <see cref='long'/> value
        /// </summary>
        Min = long.MinValue,

        /// <summary>
        /// The maximum representable <see cref='long'/> value
        /// </summary>
        Max = long.MaxValue,
    }
}