//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines supported asm comment markers
    /// </summary>
    public enum AsmCommentMarker : byte
    {
        None = 0,

        /// <summary>
        /// Specifies the ';' marker
        /// </summary>
        Semicolon = AsciCode.Semicolon,

        /// <summary>
        /// Specifies the '#' marker
        /// </summary>
        Hash = AsciCode.Hash
    }
}