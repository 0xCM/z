//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies ComDat sections
    /// </summary>
    /// <remarks>Adapted from https://github.com/llvm/llvm-project/blob/632ebc4ab4374e53fce1ec870465c587e0a33668/llvm/lib/MC/MCParser/COFFAsmParser.cpp</remarks>
    [SymSource("coff")]
    public enum CoffComDatKind : byte
    {
        [Symbol("")]
        None = 0,

        [Symbol("one_only", "IMAGE_COMDAT_SELECT_NODUPLICATES")]
        NoDuplicates = 1,

        [Symbol("discard", "IMAGE_COMDAT_SELECT_ANY")]
        Discard = 2,

        [Symbol("same_size", "IMAGE_COMDAT_SELECT_SAME_SIZE")]
        SameSize = 3,

        [Symbol("same_contents", "IMAGE_COMDAT_SELECT_EXACT_MATCH")]
        ExactMatch = 4,

        [Symbol("associative", "IMAGE_COMDAT_SELECT_ASSOCIATIVE")]
        Associative = 5,

        [Symbol("largest", "IMAGE_COMDAT_SELECT_LARGEST")]
        Largest = 6,

        [Symbol("newest", "IMAGE_COMDAT_SELECT_NEWEST")]
        Newest = 7,

    }
}