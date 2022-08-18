//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an equivalence class over types of integral numeric kind
    /// </summary>
    [SymSource(api_kinds)]
    public enum TypeSignKind : sbyte
    {
        /// <summary>
        /// Specifies that a type is defined over both signed and unsigned values
        /// </summary>
        Signed = -1,

        /// <summary>
        /// Specifies that a type is defined only over unsigned values
        /// </summary>
        Unsigned = 0,
    }
}