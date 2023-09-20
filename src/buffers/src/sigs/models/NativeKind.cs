//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Classifies type-system primitives
/// </summary>
[SymSource("api")]
public enum NativeKind : byte
{
    /// <summary>
    /// 0
    /// </summary>
    [Symbol("")]
    None,

    /// <summary>
    /// Specifies a 1-bit value
    /// </summary>
    [Symbol("bit")]
    U1,

    /// <summary>
    /// Specifies a signed 8-bit integer
    /// </summary>
    [Symbol("sbyte")]
    I8,

    /// <summary>
    /// Specifies an unsigned 8-bit integer
    /// </summary>
    [Symbol("byte")]
    U8,

    /// <summary>
    /// Specifies a signed 16-bit integer
    /// </summary>
    [Symbol("short")]
    I16,

    /// <summary>
    /// Specifies an unsigned 16-bit integer
    /// </summary>
    [Symbol("ushort")]
    U16,

    /// <summary>
    /// Specifies a signed 32-bit integer
    /// </summary>
    [Symbol("int")]
    I32,

    /// <summary>
    /// Specifies an unsigned 32-bit integer
    /// </summary>
    [Symbol("uint")]
    U32,

    /// <summary>
    /// Specifies a signed 64-bit integer
    /// </summary>
    [Symbol("long")]
    I64,

    /// <summary>
    /// Specifies an unsigned 64-bit integer
    /// </summary>
    [Symbol("ulong")]
    U64,

    /// <summary>
    /// Specifies a 32-bit float
    /// </summary>
    [Symbol("float")]
    F32,

    /// <summary>
    /// Specifies a 64-bit float
    /// </summary>
    [Symbol("double")]
    F64,


    /// <summary>
    /// Void
    /// </summary>
    [Symbol("void")]
    Void,
}
