//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CoffObject
    {
        readonly CoffObjectData Data;

        public CoffObject(CoffObjectData data)
        {
            Data = data;
        }
        
        public FilePath Path => Data.Path;
 
        public ByteSize Size => Data.Size;

        CoffObjectView View
        {
            [MethodImpl(Inline)]
            get => CoffObjectView.cover(Data.Bytes());
        }

        public ref readonly CoffHeader Header
        {
            [MethodImpl(Inline)]
            get => ref View.Header;
        }

        public ByteSize HeaderSize
        {
            [MethodImpl(Inline)]
            get => size<CoffHeader>();
        }

        public ReadOnlySpan<CoffSectionHeader> SectionHeaders
        {
            [MethodImpl(Inline)]
            get => View.SectionHeaders;
        }

        public Timestamp Timestamp
        {
            [MethodImpl(Inline)]
            get => View.Timestamp;
        }

        public ReadOnlySpan<CoffSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => View.Symbols;
        }

        public CoffStringTable Strings
        {
            [MethodImpl(Inline)]
            get => View.StringTable;
        }
    }
}