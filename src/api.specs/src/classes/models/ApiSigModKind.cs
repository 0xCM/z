//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x16;

    [Flags]
    public enum ApiSigModKind : ushort
    {
        None,

        /// <summary>
        /// Indicates an operand is an input/readonly value
        /// </summary>
        In = P2ᐞ00,

        /// <summary>
        /// Indicates an operand is an output value that must be assigned prior to operation return
        /// </summary>
        Out = P2ᐞ01,

        /// <summary>
        /// Indicates an operand is a reference value
        /// </summary>
        Ref = P2ᐞ02,

        /// <summary>
        /// Indicates an operand is a pointer
        /// </summary>
        Ptr = P2ᐞ03,

        /// <summary>
        /// Indicates an operand is an immediate value
        /// </summary>
        Imm = P2ᐞ04,
    }
}