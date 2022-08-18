//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// http://www.hexacorn.com/blog/2016/12/15/pe-section-names-re-visited
    /// https://github.com/llvm/llvm-project/blob/632ebc4ab4374e53fce1ec870465c587e0a33668/llvm/lib/MC/MCParser/COFFAsmParser.cpp
    /// </summary>
    [SymSource("coff")]
    public enum CoffSectionKind : byte
    {
        Unknown = 0,

        [Symbol(".data")]
        Data,

        [Symbol(".bss")]
        Bss,

        [Symbol(".idata")]
        InitializedData,

        [Symbol(".rdata")]
        ReadOnlyData,

        [Symbol(".pdata")]
        ExceptionData,

        [Symbol(".edata")]
        ExportData,

        // https://stackoverflow.com/questions/47944583/what-does-xdata-section-do
        [Symbol(".xdata")]
        UnwindInfo,

        [Symbol(".rsrc")]
        ResourceSection,

        [Symbol(".text")]
        Text,

        [Symbol(".reloc")]
        RelocationTable,

        [Symbol(".debug")]
        Debug,

        [Symbol(".debug$S")]
        DebugS,

        [Symbol(".debug$T")]
        DebugT,

        [Symbol(".tls")]
        ThreadLocalStorage,

        [Symbol(".drectve")]
        Directive,

        [Symbol(".cormeta")]
        ClrMetadata,
    }
}