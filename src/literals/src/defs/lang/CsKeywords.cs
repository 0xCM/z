//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using TC = System.TypeCode;

    [LiteralProvider(lang)]
    public class CsKeywords
    {
        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Object'/> = 1
        /// </summary>
        public const string Object = "object";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Boolean'/> = 3
        /// </summary>
        public const string Bool = "bool";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Char'/> = 4
        /// </summary>
        public const string Char = "char";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.SByte'/> = 5
        /// </summary>
        public const string I8 = "sbyte";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Byte'/> = 6
        /// </summary>
        public const string U8 = "byte";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Int16'/> = 7
        /// </summary>
        public const string I16 = "short";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.UInt16'/> = 8
        /// </summary>
        public const string U16 = "ushort";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Int32'/> = 9
        /// </summary>
        public const string I32 = "int";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.UInt32'/> = 10
        /// </summary>
        public const string U32 = "uint";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Int64'/> = 11
        /// </summary>
        public const string I64 = "long";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.UInt64'/> = 12
        /// </summary>
        public const string U64 = "ulong";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Single'/> = 13
        /// </summary>
        public const string F32 = "float";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Double'/> = 14
        /// </summary>
        public const string F64 = "double";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.Decimal'/> = 15
        /// </summary>
        public const string F128 = "decimal";

        /// <summary>
        /// Specifies the cs keyword for <see cref='TC.String'/> = 18
        /// </summary>
        public const string String = "string";

        public const string @sbyte = I8;

        public const string @short = I16;

        public const string @int = I32;

        public const string @long = I64;

        public const string Public = "public";

        public const string Private = "private";

        public const string Protected = "protected";

        public const string Internal = "internal";

        public const string ProtectedInternal = "protected internal";

        public const string ReadOnly = "readonly";

        public const string Const = "const";

        public const string Enum = "enum";

        public const string Struct = "struct";

        public const string Case = "case";

        public const string Fixed = "fixed";

        public const string Static = "static";


    }

    /*
        //
        // Summary:
        //     A null reference.
        Empty = 0,
        //
        // Summary:
        //     A general type representing any reference or value type not explicitly represented
        //     by another TypeCode.
        Object = 1,
        //
        // Summary:
        //     A database null (column) value.
        DBNull = 2,
        //
        // Summary:
        //     A simple type representing Boolean values of true or false.
        Boolean = 3,
        //
        // Summary:
        //     An integral type representing unsigned 16-bit integers with values between 0
        //     and 65535. The set of possible values for the System.TypeCode.Char type corresponds
        //     to the Unicode character set.
        Char = 4,
        //
        // Summary:
        //     An integral type representing signed 8-bit integers with values between -128
        //     and 127.
        SByte = 5,
        //
        // Summary:
        //     An integral type representing unsigned 8-bit integers with values between 0 and
        //     255.
        Byte = 6,
        //
        // Summary:
        //     An integral type representing signed 16-bit integers with values between -32768
        //     and 32767.
        Int16 = 7,
        //
        // Summary:
        //     An integral type representing unsigned 16-bit integers with values between 0
        //     and 65535.
        UInt16 = 8,
        //
        // Summary:
        //     An integral type representing signed 32-bit integers with values between -2147483648
        //     and 2147483647.
        Int32 = 9,
        //
        // Summary:
        //     An integral type representing unsigned 32-bit integers with values between 0
        //     and 4294967295.
        UInt32 = 10,
        //
        // Summary:
        //     An integral type representing signed 64-bit integers with values between -9223372036854775808
        //     and 9223372036854775807.
        Int64 = 11,
        //
        // Summary:
        //     An integral type representing unsigned 64-bit integers with values between 0
        //     and 18446744073709551615.
        UInt64 = 12,
        //
        // Summary:
        //     A floating point type representing values ranging from approximately 1.5 x 10
        //     -45 to 3.4 x 10 38 with a precision of 7 digits.
        Single = 13,
        //
        // Summary:
        //     A floating point type representing values ranging from approximately 5.0 x 10
        //     -324 to 1.7 x 10 308 with a precision of 15-16 digits.
        Double = 14,
        //
        // Summary:
        //     A simple type representing values ranging from 1.0 x 10 -28 to approximately
        //     7.9 x 10 28 with 28-29 significant digits.
        Decimal = 0xF,
        //
        // Summary:
        //     A type representing a date and time value.
        DateTime = 0x10,
        //
        // Summary:
        //     A sealed class type representing Unicode character strings.
        String = 18
    */
}