//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm.clang.index
{
    /// <summary>
    /// Mirrors the SymbolRole enum defined in https://github.com/llvm/llvm-project/blob/b2d0c16e91f39def3646b71e5afebfaea262cca1/clang/include/clang/Index/IndexSymbol.h
    /// </summary>
    [SymSource("llvm.clang.index")]
    public enum SymbolRole : uint
    {
        Declaration = 1 << 0,

        Definition = 1 << 1,

        Reference = 1 << 2,

        Read = 1 << 3,

        Write = 1 << 4,

        Call = 1 << 5,

        Dynamic = 1 << 6,

        AddressOf = 1 << 7,

        Implicit = 1 << 8,

        // FIXME: this is not mirrored in CXSymbolRole.
        // Note that macro occurrences aren't currently supported in libclang.
        Undefinition = 1 << 9, // macro #undef

        // Relation roles.
        RelationChildOf = 1 << 10,

        RelationBaseOf = 1 << 11,

        RelationOverrideOf = 1 << 12,

        RelationReceivedBy = 1 << 13,

        RelationCalledBy = 1 << 14,

        RelationExtendedBy = 1 << 15,

        RelationAccessorOf = 1 << 16,

        RelationContainedBy = 1 << 17,

        RelationIBTypeOf = 1 << 18,

        RelationSpecializationOf = 1 << 19,

        // Symbol only references the name of the object as written. For example, a
        // constructor references the class declaration using that role.
        NameReference = 1 << 20,
    }
}