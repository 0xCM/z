//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Enumerates the identifiable things
    /// </summary>
    [SymSource(api_kinds), Flags]
    public enum IdentityTargetKind : byte
    {
        None = 0,

        /// <summary>
        /// Designates type identity
        /// </summary>
        Type = 2,

        /// <summary>
        /// Designates operation identity
        /// </summary>
        Method = 4,
    }
}