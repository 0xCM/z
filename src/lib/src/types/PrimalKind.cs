//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies type-system primitives
    /// </summary>
    [SymSource("api"), DataWidth(3)]
    public enum _PrimalKind : byte
    {
        /// <summary>
        /// 0
        /// </summary>
        [Symbol("")]
        None = TypeKey.FirstKey,

        /// <summary>
        /// 1
        /// </summary>
        [Symbol("bit")]
        U1 = None + 1,

        /// <summary>
        /// 2
        /// </summary>
        [Symbol("byte")]
        U8 = U1 + 1,

        /// <summary>
        /// 3
        /// </summary>
        [Symbol("ushort")]
        U16 = U8 + 1,

        /// <summary>
        /// 4
        /// </summary>
        [Symbol("uint")]
        U32 = U16 + 1,

        /// <summary>
        /// 5
        /// </summary>
        [Symbol("ulong")]
        U64 = U32 + 1,

        /// <summary>
        /// 6
        /// </summary>
        [Symbol("void")]
        Void = U64 + 1,
    }
}