//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm.clang.index
{
    /// <summary>
    /// Mirrors the SymbolSubKind enum defined in https://github.com/llvm/llvm-project/blob/b2d0c16e91f39def3646b71e5afebfaea262cca1/clang/include/clang/Index/IndexSymbol.h
    /// </summary>
    [SymSource("llvm.clang.index")]
    public enum SymbolSubKind : byte
    {
        None,

        CXXCopyConstructor,

        CXXMoveConstructor,

        AccessorGetter,

        AccessorSetter,

        UsingTypename,

        UsingValue,

        UsingEnum,
    }
}