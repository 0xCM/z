// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    /// <summary>
    ///
    /// </summary>
    public enum CorElementType : byte
    {
        ELEMENT_TYPE_END = 0x0,

        /// <summary>
        /// Identifies the <see cref='void'/> pseudotype
        /// </summary>
        ELEMENT_TYPE_VOID = 0x1,

        /// <summary>
        /// Identifies the <see cref='bool'/> type
        /// </summary>
        ELEMENT_TYPE_BOOLEAN = 0x2,

        /// <summary>
        ///  Identifies the <see cref='char'/> type
        /// </summary>
        ELEMENT_TYPE_CHAR = 0x3,

        /// <summary>
        ///  Identifies the <see cref='sbyte'/> type
        /// </summary>
        ELEMENT_TYPE_I1 = 0x4,

        /// <summary>
        ///  Identifies the <see cref='byte'/> type
        /// </summary>
        ELEMENT_TYPE_U1 = 0x5,

        /// <summary>
        ///  Identifies the <see cref='short'/> type
        /// </summary>
        ELEMENT_TYPE_I2 = 0x6, // Int16

        /// <summary>
        ///  Identifies the <see cref='ushort'/> type
        /// </summary>
        ELEMENT_TYPE_U2 = 0x7,

        /// <summary>
        ///  Identifies the <see cref='int'/> type
        /// </summary>
        ELEMENT_TYPE_I4 = 0x8,

        /// <summary>
        ///  Identifies the <see cref='uint'/> type
        /// </summary>
        ELEMENT_TYPE_U4 = 0x9,

        /// <summary>
        ///  Identifies the <see cref='long'/> type
        /// </summary>
        ELEMENT_TYPE_I8 = 0xA,

        /// <summary>
        ///  Identifies the <see cref='ulong'/> type
        /// </summary>
        ELEMENT_TYPE_U8 = 0xB,

        /// <summary>
        ///  Identifies the <see cref='single'/> type
        /// </summary>
        ELEMENT_TYPE_R4 = 0xC,

        /// <summary>
        ///  Identifies the <see cref='double'/> type
        /// </summary>
        ELEMENT_TYPE_R8 = 0xD,

        /// <summary>
        ///  Identifies the <see cref='string'/> type
        /// </summary>
        ELEMENT_TYPE_STRING = 0xE,

        /// <summary>
        ///  Identifies a PTR type
        /// </summary>
        ELEMENT_TYPE_PTR = 0xF,

        /// <summary>
        ///  Identifies a BYREF type
        /// </summary>
        ELEMENT_TYPE_BYREF = 0x10,

        /// <summary>
        ///  Deprecated
        /// </summary>
        ELEMENT_TYPE_VALUETYPE = 0x11,

        /// <summary>
        ///  Identifies a class type
        /// </summary>
        ELEMENT_TYPE_CLASS = 0x12,     // CLASS <class Token>

        ELEMENT_TYPE_VAR = 0x13,     // a class type variable VAR <U1>

        ELEMENT_TYPE_ARRAY = 0x14,     // MDARRAY <type> <rank> <bcount> <bound1> ... <lbcount> <lb1> ...

        ELEMENT_TYPE_GENERICINST = 0x15,     // GENERICINST <generic type> <argCnt> <arg1> ... <argn>

        ELEMENT_TYPE_TYPEDBYREF = 0x16,     // TYPEDREF  (it takes no args) a typed reference to some other type

        ELEMENT_TYPE_I = 0x18,     // native integer size

        ELEMENT_TYPE_U = 0x19,     // native unsigned integer size

        ELEMENT_TYPE_FNPTR = 0x1B,     // FNPTR <complete sig for the function including calling convention>

        /// <summary>
        /// Identifies the <see cref='object'/> type
        /// </summary>
        ELEMENT_TYPE_OBJECT = 0x1C,     // Shortcut for System.Object

        /// <summary>
        /// Identifies a one-dimensional array with a zero lower-bound
        /// </summary>
        ELEMENT_TYPE_SZARRAY = 0x1D,

        // SZARRAY <type>
        ELEMENT_TYPE_MVAR = 0x1E,     // a method type variable MVAR <U1>

        // This is only for binding
        ELEMENT_TYPE_CMOD_REQD = 0x1F,     // required C modifier : E_T_CMOD_REQD <mdTypeRef/mdTypeDef>

        ELEMENT_TYPE_CMOD_OPT = 0x20,     // optional C modifier : E_T_CMOD_OPT <mdTypeRef/mdTypeDef>

        ELEMENT_TYPE_HANDLE = 0x40,

        ELEMENT_TYPE_SENTINEL = 0x41, // sentinel for varargs

        ELEMENT_TYPE_PINNED = 0x45,
    }
}