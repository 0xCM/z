//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public class SdmCodeGen : WfSvc<SdmCodeGen>
    {
        IntelSdm Sdm => Wf.IntelSdm();

        const string TargetNamespace = "Z0.Asm";

        const string AsmSigTableName = "AsmSigST";

        const string MnemonicNameProvider = "AsmMnemonicNames";

        CsLang CsLang => Service(Wf.CsLang);

        SymGen SymGen => Channel.Channeled<SymGen>();

        public void Emit(IDbArchive dst)
        {
            GenMnemonicNames(dst);
            GenFormKinds(dst);
            GenSigStrings(dst);
        }

        public void GenMnemonicNames(IDbArchive dst)
        {
            var src = Sdm.CalcMnemonics().Select(x => x.Format(MnemonicCase.Lowercase));
            CsLang.LiteralProviders().Emit(TargetNamespace,
                Literals.seq(MnemonicNameProvider, src.View),
                CsLang.SourceFile(MnemonicNameProvider, dst)
                );
        }

        public void GenFormKinds(IDbArchive dst)
        {
            var descriptors = Sdm.CalcFormDescriptors();
            var src = descriptors.CalcSymbols();
            var buffer = text.buffer();
            var margin = 0u;
            buffer.IndentLineFormat(margin, "namespace {0}", TargetNamespace);
            buffer.IndentLine(margin, Chars.LBrace);
            margin += 4;
            CsRender.@enum(margin, src, buffer);
            margin -=4;
            buffer.Indent(margin, Chars.RBrace);
            CsLang.EmitFile(buffer.Emit(), SdmFormDescriptors.FormKindName, dst);
        }

        public void GenSigStrings(IDbArchive dst)
        {
            var forms = Sdm.CalcFormDescriptors();
            var keys = forms.Keys;
            var count = keys.Length + 1;
            var sigs = alloc<string>(count);
            for(var i=0; i<count; i++)
            {
                if(i==0)
                    seek(sigs,i) = EmptyString;
                else
                    seek(sigs,i) = forms[keys[i-1]].Sig.Format();
            }

            SymGen.EmitStringTable(TargetNamespace, AsmSigTableName, SdmFormDescriptors.FormKindName, sigs, false, dst);
        }
    }
}