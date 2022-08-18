//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Diagnostics;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection.PortableExecutable;
global using System.Reflection.Emit;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading;
global using System.Threading.Tasks;
global using System.IO;
global using CC = System.Runtime.InteropServices.CallingConvention;
global using Fp = System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute;

global using static Z0.Root;
global using static Z0.ApiAtomic;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;
using NK = Z0.NumericKind;

[assembly: PartId(PartId.Sys)]

namespace Z0.Parts
{
    public sealed class Sys : Part<Sys>
    {

    }
}

namespace Z0
{
    partial struct Root
    {
        public const string EmptyString = "";

        public const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        public const string windows = nameof(windows);

        public const string coff = nameof(coff);

    /// <summary>
    /// Specifies the <see cref='CC.StdCall'/> calling convention where the
    /// callee is responsible for stack management
    /// </summary>
    /// <remarks>
    /// This is the default PInvoke convention
    /// </remarks>
    public const CC StdCall = CC.StdCall;

    /// <summary>
    /// Specifies the <see cref='CC.Cdecl'/> calling convention where the caller
    /// is responsible for stack management
    /// </summary>
    /// <remarks>
    /// According to the runtime documentation, "This enables calling functions with varargs, which
    /// makes it appropriate to use for methods that accept a variable number of parameters,
    /// such as Printf".
    /// </remarks>
    public const CC Cdecl = CC.Cdecl;

    /// <summary>
    /// Specifies the <see cref='CC.ThisCall'/> calling convention where first argument is <see cref='this'/> and is placed in ECX/RCX
    /// </summary>
    public const CC ThisCall = CC.ThisCall;

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