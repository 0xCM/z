//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;

    partial struct Root
    {
        /// <summary>
        /// Specifies unsigned integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK UnsignedInts = NK.UnsignedInts;

        /// <summary>
        /// Specifies signed integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK SignedInts = NK.SignedInts;

        /// <summary>
        /// Specifies signed and unsigned integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK Integers = NK.Integers;

        /// <summary>
        /// Specifies floating-point primitive kinds
        /// </summary>
        public const NK Floats = NK.Floats;

        /// <summary>
        /// Specifies all numeric primitive kinds
        /// </summary>
        public const NK AllNumeric = NK.All;

        /// <summary>
        /// Specifies numeric types of width <see cref='W8'/>
        /// </summary>
        public const NK Numeric8k = NK.Width8;

        /// <summary>
        /// Specifies numeric types of width <see cref='W64'/>
        /// </summary>
        public const NK Numeric64k = NK.Width64;

        /// <summary>
        /// Specifies numeric types of width <see cref='W8'/>, <see cref='W16'/> and <see cref='W32'/>
        /// </summary>
        public const NK Numeric8x16x32k = NK.Width8 | NK.Width16 | NK.Width32;

        /// <summary>
        /// Specifies numeric types of width <see cref='W16'/>, <see cref='W32'/>, and <see cref='W64'/>
        /// </summary>
        public const NK Numeric16x32x64k = NK.Width16 | NK.Width32 | NK.Width64;

        /// <summary>
        /// Specifies numeric types of width <see cref='W32'/>, and <see cref='W64'/>
        /// </summary>
        public const NK Numeric32x64k = NK.Width32 | NK.Width64;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W8'/>
        /// </summary>
        public const NK UInt8k = NK.U8;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W16'/>
        /// </summary>
        public const NK UInt16k = NK.U16;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W32'/>
        /// </summary>
        public const NK UInt32k = NK.U32;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W64'/>
        /// </summary>
        public const NK UInt64k = NK.U64;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W8'/>
        /// </summary>
        public const NK Int8k = NK.I8;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W16'/>
        /// </summary>
        public const NK Int16k = NK.I16;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W32'/>
        /// </summary>
        public const NK Int32k = NK.I32;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W64'/>
        /// </summary>
        public const NK Int64k = NK.I64;

        /// <summary>
        /// Specifies a floating point type of width <see cref='W32'/>
        /// </summary>
        public const NK Float32k = NK.F32;

        /// <summary>
        /// Specifies a floating point type of width <see cref='W64'/>
        /// </summary>
        public const NK Float64k = NK.F64;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W8'/> and <see cref='W16'/>
        /// </summary>
        public const NK Int8x16k = NK.I8 | NK.U8 | NK.I16 | NK.U16;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W8'/>, <see cref='W16'/>, and <see cref='W32'/>
        /// </summary>
        public const NK Int8x16x32k = NK.I8 | NK.U8 | NK.I16 | NK.U16 | NK.I32 | NK.U32;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W16'/>, <see cref='W32'/>, and <see cref='W64'/>
        /// </summary>
        public const NK Int16x32x64k = NK.I16 | NK.U16 | NK.I32 | NK.U32 | NK.I64 | NK.U64;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W8'/> and <see cref='W64'/>
        /// </summary>
        public const NK Int8x64k = NK.I8 | NK.U8 | NK.I64 | NK.U64;

        public const NK Integers8x64k = Int8x64k;

        public const NK Numeric8x16k = Int8x16k;

        public const NK UInt8x64k = Int8x64k;

        public const NK UInt8x16k = Int8x16k;

        public const NK UInt8x16x32k = Int8x16x32k;

        public const NK UInt16x32x64k = Int16x32x64k;
    }
}