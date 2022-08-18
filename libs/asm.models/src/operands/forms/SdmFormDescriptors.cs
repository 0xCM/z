//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SdmFormDescriptors : SortedLookup<string,SdmFormDescriptor>
    {
        public const string FormKindName = "AsmFormKind";

        public SymSet CalcSymbols()
        {
            var forms = this;
            var identifiers = forms.Keys;
            var count = (uint)identifiers.Length + 1;
            var dst = new SymSet(count, FormKindName, ClrEnumKind.U16, new DataSize(16,16), NumericBaseKind.Base10, false, "asm");
            ref readonly var names = ref dst.Names;
            ref readonly var values = ref dst.Values;
            ref readonly var symbols = ref dst.Symbols;
            ref readonly var descriptions = ref dst.Descriptions;
            ref readonly var positons = ref dst.Positions;
            for(ushort i=0; i<count; i++)
            {
                ref var name = ref names[i];
                ref var symbol = ref symbols[i];
                ref var value = ref values[i];
                ref var desc = ref descriptions[i];
                ref var index = ref positons[i];
                index = i;
                if(i == 0)
                {
                    name = "None";
                    symbol = EmptyString;
                    value = 0;
                    desc = EmptyString;
                }
                else
                {
                    ref readonly var id = ref skip(identifiers,i - 1);
                    var form = forms[id];
                    name = id == "lock" ? "@lock" : id;
                    symbol = form.Sig.Format();
                    value = i;
                    desc = string.Format("{0} | {1} | {2}", symbol, index, form.Description);
                }
            }
            return dst;
        }

        public SdmFormDescriptors(Dictionary<string,SdmFormDescriptor> src)
            : base(src)
        {


        }

        public static implicit operator SdmFormDescriptors(Dictionary<string,SdmFormDescriptor> src)
            => new SdmFormDescriptors(src);
    }
}