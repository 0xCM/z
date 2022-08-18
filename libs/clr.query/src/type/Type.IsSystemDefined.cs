// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     partial class ClrQuery
//     {
//         /// <summary>
//         /// Determines whether a type is system-defined primitive
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsSystemDefined(this Type t)
//             => t.IsPrimalNumeric() || t.IsBool() || t.IsVoid() || t.IsChar() || t.IsString() || t.IsObject() || t.IsDynamic();

//         /// <summary>
//         /// Determines whether a type is a directly instantiable <see cref='Z0.PrimalKind'/>
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsConreteClrPrimitive(this Type t)
//             => t.IsPrimalNumeric() || t.IsBool() || t.IsChar() || t.IsString();

//         /// <summary>
//         /// Determines whether a type is a system-defined and architecture-suppored numeric type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsPrimalNumeric(this Type t)
//             => t.IsFloatingPoint() || t.IsIntegral() && !t.IsEnum;

//         /// <summary>
//         /// Determines whether a type is a system-defined and architecture-supported integral type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsIntegral(this Type t)
//             => t.IsSignedInt() || t.IsUnsignedInt();

//         /// <summary>
//         /// Determines whether a type is a system-defined and architecture-supported signed integral type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline)]
//         public static bool IsUnsignedInt(this Type t)
//             => t.IsUInt8() || t.IsUInt16() || t.IsUInt32() || t.IsUInt64();

//         /// <summary>
//         /// Determines whether a type is a system-defined and architecture-supported unsigned integral type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsSignedInt(this Type t)
//             => t.IsInt8() || t.IsInt16() || t.IsInt32() || t.IsInt64();

//         /// <summary>
//         /// Determines whether a type is a system-defined and architecture-supported floating-point type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline)]
//         public static bool IsFloatingPoint(this Type t)
//             => t.IsFloat32() || t.IsFloat64();

//         /// <summary>
//         /// Determines whether a supplied type is predicated on a bool, including nullable wrappers and references
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsBool(this Type t)
//             => t.IsTypeOf<bool>();

//         /// <summary>
//         /// Determines whether a supplied type is predicated on a string, including references
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsString(this Type t)
//             => t.IsTypeOf<string>();

//         /// <summary>
//         /// Determines whether a supplied type is predicated on a string, including references
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsObject(this Type t)
//             => t.IsTypeOf<object>();

//         /// <summary>
//         /// Determines whether a supplied type is predicated on a string, including references
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsDynamic(this Type t)
//             => t.IsTypeOf<dynamic>();

//         /// <summary>
//         /// Determines whether a supplied type is of type Void
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsVoid(this Type t)
//             => t == typeof(void);

//         /// <summary>
//         /// Determines whether a supplied type is predicated on a char, including nullable wrappers and references
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsChar(this Type t)
//             => t.IsTypeOf<Char>();

//         /// <summary>
//         /// Determines whether a type is the system-defined 8-bit unsigned integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsByte(this Type t)
//             => t.IsTypeOf<byte>();

//         /// <summary>
//         /// Determines whether a type the system-defined 8-bit signed integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsSByte(this Type t)
//             => t.IsTypeOf<sbyte>();

//         /// <summary>
//         /// Determines whether a type the system-defined 8-bit unsigned integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsUInt8(this Type t)
//             => t.IsTypeOf<byte>();

//         /// <summary>
//         /// Determines whether a type the system-defined 8-bit signed integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsInt8(this Type t)
//             => t.IsTypeOf<sbyte>();

//         /// <summary>
//         /// Determines whether a type the system-defined 16-bit unsigned integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsUInt16(this Type t)
//             => t.IsTypeOf<ushort>();

//         /// <summary>
//         /// Determines whether a type the system-defined 16-bit signed integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsInt16(this Type t)
//             => t.IsTypeOf<short>();

//         /// <summary>
//         /// Determines whether a type the system-defined 32-bit unsigned integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsUInt32(this Type t)
//             => t.IsTypeOf<uint>();

//         /// <summary>
//         /// Determines whether a type the system-defined 32-bit signed integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsInt32(this Type t)
//             => t.IsTypeOf<int>();

//         /// <summary>
//         /// Determines whether a type the system-defined 64-bit unsigned integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsUInt64(this Type t)
//             => t.IsTypeOf<ulong>();

//         /// <summary>
//         /// Determines whether a type the system-defined 64-bit signed integer type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsInt64(this Type t)
//             => t.IsTypeOf<long>();

//         /// <summary>
//         /// Determines whether a type the system-defined 32-bit floating-point type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsSingle(this Type t)
//             => t.IsTypeOf<float>();

//         /// <summary>
//         /// Determines whether a type the system-defined 32-bit floating-point type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsFloat32(this Type t)
//             => t.IsTypeOf<float>();

//         /// <summary>
//         /// Determines whether a type the system-defined 64-bit floating-point type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsDouble(this Type t)
//             => t.IsTypeOf<double>();

//         /// <summary>
//         /// Determines whether a type the system-defined 64-bit floating-point type or a system-defined variation thereof
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         /// <remarks>
//         /// Variations accounted for include
//         /// A) System-defined nullable parametric closures over the type
//         /// B) System-defined reference types that cover the type, including ref/out parameters and such
//         /// C) THe system-defined pseudo-refinement mechanism known as an Enum
//         /// </remarks>
//         [MethodImpl(Inline), Op]
//         public static bool IsFloat64(this Type t)
//             => t.IsTypeOf<double>();

//         /// <summary>
//         /// Determines whether a supplied type is predicated on a double, including enums, nullable wrappers and references
//         /// </summary>
//         /// <param name="t">The type to examine</param>
//         [MethodImpl(Inline), Op]
//         public static bool IsDecimal(this Type t)
//             => t.IsTypeOf<decimal>();
//     }
// }