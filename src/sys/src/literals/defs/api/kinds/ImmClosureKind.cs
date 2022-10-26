//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(api_kinds)]
    public enum ImmClosureKind : byte
    {
        None = 0,

        /// <summary>
        /// Indicates closure is specified for an explicitly-specified set of immediates
        /// </summary>
        Individuals = 1,

        /// <summary>
        /// Indicates closure is specified for a range of immediates
        /// </summary>
        Range = 2,

        /// <summary>
        /// Indicates closure is specified for an inclusive range of powers of 2
        /// </summary>
        Powers2 = 3,
    }
}