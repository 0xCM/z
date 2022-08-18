//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using TC = System.TypeCode;

    /// <summary>
    /// Identifies primal system types with 8-bit unsigned integers that capture the (grossly overallocated) 32-bit integer type code values.
    /// </summary>
    [SymSource(clr), LiteralAlias(typeof(TC))]
    public enum PrimalCode : byte
    {
        None = 0,

        /// <summary>
        /// An alias for <see cref='TC.Object'/>
        /// </summary>
        Object = TC.Object,

        /// <summary>
        /// An alias for <see cref='TC.DbNull'/>
        /// </summary>
        DBNull = TC.DBNull,

        /// <summary>
        /// An alias for <see cref='TC.Boolean'/>
        /// </summary>
        U1 = TC.Boolean,

        /// <summary>
        /// An alias for <see cref='TC.Char'/>
        /// </summary>
        C16 = TC.Char,

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

        /// <summary>
        /// An alias for <see cref='TC.Single'/>
        /// </summary>
        F32 = TC.Single,

        /// <summary>
        /// An alias for <see cref='TC.Double'/>
        /// </summary>
        F64 = TC.Double,

        /// <summary>
        /// An alias for <see cref='TC.Decimal'/>
        /// </summary>
        F128 = TC.Decimal,

        /// <summary>
        /// An alias for <see cref='TC.DateTime'/>
        /// </summary>
        DateTime = TC.DateTime,

        /// <summary>
        /// An alias for <see cref='TC.String'/>
        /// </summary>
        String = TC.String
    }
}