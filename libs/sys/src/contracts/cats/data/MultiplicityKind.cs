//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines multiplicity categories
    /// </summary>
    [Flags]
    public enum MultiplicityKind : byte
    {
        Unknown = 0,

        Zero = 1,

        One = 2,

        ZeroOrOne = Zero | One,

        Many = 8,

        ZeroOrMany = Zero | Many,

        OneOrMany = One | Many,
    }
}