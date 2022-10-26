//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(api_kinds)]
    public enum NatClosureKind : byte
    {
        None = 0,

        /// <summary>
        /// Indicates closure is specified for an explicitly-specified set naturals
        /// </summary>
        Individuals = 1,

        /// <summary>
        /// Indicates closure is specified for an inclusive range of naturals
        /// </summary>
        Range = 2,

        /// <summary>
        /// Indicates closure is specified for an inclusive power-of-two range specified by a min/max pair
        /// </summary>
        Powers2 = 3,

        /// <summary>
        /// Indicates closure is specified for explicit pairs of natural numbers
        /// </summary>
        ExplicitPairs,
    }
}