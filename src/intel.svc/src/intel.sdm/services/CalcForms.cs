//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public SdmFormSeq CalcForms()
            => map(CalcFormDescriptors().Values, v => v.Form);

        public SdmFormDescriptors CalcFormDescriptors()
            => CalcFormsDescriptors(LoadOcDetails());

        SdmFormDescriptors CalcFormsDescriptors(Index<SdmOpCodeDetail> src)
        {
            return Data(nameof(CalcFormDescriptors), Calc);

            SdmFormDescriptors Calc()
            {
                var result = Outcome.Success;
                var count = src.Length;
                var counter = 0u;
                var forms = list<SdmFormDescriptor>();
                var modified = list<SdmFormDescriptor>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var detail = ref src[i];
                    result = AsmSigs.parse(detail.AsmSig.View, out var sig);
                    if(result.Fail)
                        break;

                    result = SdmOpCodes.parse(detail.OpCodeExpr, out var opcode);
                    if(result.Fail)
                        break;

                    var terms = AsmSigs.terminate(SdmForms.form(sig,opcode));
                    var kTerms = terms.Count;
                    for(var j=0; j<kTerms; j++)
                    {
                        ref readonly var term = ref terms[j];
                        forms.Add(new SdmFormDescriptor(term, detail));
                        if(AsmSigs.modified(term.Sig))
                            modified.Add(new SdmFormDescriptor(term, detail));
                    }
                }

                var tmp = list<SdmFormDescriptor>();
                tmp.AddRange(SdmForms.unmodify(forms.ViewDeposited()));
                tmp.AddRange(modified);
                return IdentifyForms(tmp.ToArray());
            }
        }
    }
}