//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    /// <summary>
    /// Defines immediate value classifiers
    /// </summary>
    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum ImmRefinementKind : byte
    {
        None = 0,

        /// <summary>
        /// Indicates immediate is a primal literal with no additional type information
        /// </summary>
        Unrefined = 1,

        /// <summary>
        /// Indicates immediate is is a refined primitive, constrained to a particular domain
        /// </summary>
        Refined = 2,

        All = Unrefined | Refined
    }
}