//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct CoffSymbol
    {
        public CoffSymbolName Name;

        public Hex32 Value;

        public ushort Section;

        public ImageSymType Type;

        public SymStorageClass Class;

        public byte NumberOfAuxSymbols;
    }
}
