//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    /// <summary>
    /// Defines intel cpu operating modes
    /// </summary>
    /// <remarks>
    /// See Vol I.3.1
    /// </remarks>
    [Flags,SymSource("asm.encoding")]
    public enum RuntimeModeKind : byte
    {
        None = 0,

        [Symbol("real","Specifies the programming environment of the Intel 8086 processor with extensions")]
        Real = 1,

        [Symbol("protected","The native operating mode")]
        Protected = 2,

        [Symbol("ia32e")]
        IA32e = 4,

        [Symbol("Smm","Specifies the System Management Mode that provides an operating system or executive with a transparent mechanism for implementing power management and OEM differentiation features")]
        Smm = 8,

        [Symbol("v8086","Specifies a protected mode emulation feature that allows the processor execute 8086 software in a protected, multitasking environment")]
        Virtual8086 = 43 | Protected,

        [Symbol("x64","An IA-32e submode that provides 64-bit linear addressing and support for physical address space larger than 64 GByte")]
        Long = 47 | IA32e,

        [Symbol("compat","An IA-32e submode that allows most legacy protected-mode applications to run unchanged")]
        Compatibilty =  51 | IA32e,

        [Symbol("legacy")]
        Legacy = Protected | Virtual8086 | Real,
    }
}