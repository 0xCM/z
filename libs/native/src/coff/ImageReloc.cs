//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ImageReloc
    {
        /// <summary>
        /// The virtual address (or count)
        /// </summary>
        public Address32 Value;

        /// <summary>
        /// The symbol table index
        /// </summary>
        public uint SymbolIndex;

        /// <summary>
        /// The relocation type
        /// </summary>
        public ImageRelocKind Kind;

        [MethodImpl(Inline)]
        public ImageReloc(Address32 value, uint index, ImageRelocKind kind)
        {
            Value = value;
            SymbolIndex = index;
            Kind = kind;
        }
    }
}