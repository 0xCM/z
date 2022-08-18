//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using TC = System.TypeCode;

    /// <summary>
    /// Defines aliases for the subset of <see cref='TC'> codes that correspond to valid <see cref='Enum'/> base types
    /// </summary>
    [SymSource(clr), LiteralAlias(typeof(TC))]
    public enum ClrEnumCode : byte
    {
        None = 0,

        /// <summary>
        /// An alias for <see cref='TC.SByte'/>
        /// </summary>
        I8 = TC.SByte,

        /// <summary>
        /// An alias for <see cref='TC.Byte'/>
        /// </summary>
        U8 = TC.Byte,

        /// <summary>
        /// An alias for <see cref='TC.Int16'/>
        /// </summary>
        I16 = TC.Int16,

        /// <summary>
        /// An alias for <see cref='TC.UInt16'/>
        /// </summary>
        U16 = TC.UInt16,

        /// <summary>
        /// An alias for <see cref='TC.Int32'/>
        /// </summary>
        I32 = TC.Int32,

        /// <summary>
        /// An alias for <see cref='TC.UInt32'/>
        /// </summary>
        U32 = TC.UInt32,

        /// <summary>
        /// An alias for <see cref='TC.Int64'/>
        /// </summary>
        I64 = TC.Int64,

        /// <summary>
        /// An alias for <see cref='TC.UInt64'/>
        /// </summary>
        U64 = TC.UInt64,
    }
}