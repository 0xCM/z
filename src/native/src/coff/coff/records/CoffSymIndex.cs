//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffSymIndex
    {
        readonly Index<CoffSectionRow> SectionData;

        readonly Index<CoffSymRow> SymData;

        public CoffSymIndex(CoffSectionRow[] sections, CoffSymRow[] syms)
        {
            SectionData = sections;
            SymData = syms;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSymRow> Symbols()
            => SymData;

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSymRow> Symbols(Hex32 doc)
            => SymData.Where(x => x.OriginId == doc);

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSymRow> Symbols(Hex32 docid, ushort section)
            => SymData.Where(x => x.OriginId == docid && x.Section == section);

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSectionRow> Sections()
            => SectionData;

        public bool Symbol(Hex32 docid, Address32 address, out CoffSymRow dst)
        {
            var result = false;
            dst = default;
            for(var i=0; i<SymData.Count; i++)
            {
                ref readonly var sym = ref SymData[i];
                if(sym.OriginId == docid && sym.Address == address)
                {
                    dst = sym;
                    result = true;
                    break;

                }
            }
            return result;
        }

        public static CoffSymIndex Empty => new CoffSymIndex(sys.empty<CoffSectionRow>(),sys.empty<CoffSymRow>());
    }
}