//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm.clang.index
{
    /// <summary>
    /// Mirrors the SymbolPropertySet enum defined in https://github.com/llvm/llvm-project/blob/b2d0c16e91f39def3646b71e5afebfaea262cca1/clang/include/clang/Index/IndexSymbol.h
    /// </summary>
    [SymSource("llvm.clang.index")]
    public enum SymbolPropertySet : ushort
    {
        Generic = 1 << 0,

        TemplatePartialSpecialization = 1 << 1,

        TemplateSpecialization = 1 << 2,

        UnitTest = 1 << 3,

        IBAnnotated = 1 << 4,

        IBOutletCollection = 1 << 5,

        GKInspectable = 1 << 6,

        Local = 1 << 7,

        /// Symbol is part of a protocol interface.
        ProtocolInterface = 1 << 8,
    }
}