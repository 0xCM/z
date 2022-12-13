//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static Asm.SdmModels;
    using static sys;

    public class IntelSdmCmd : WfAppCmd<IntelSdmCmd>
    {
        IntelSdm Sdm => Wf.IntelSdm();

        [CmdOp("sdm/export/tokens")]
        void ExportTokens()
        {
            Sdm.ExportTokens();
        }

        [CmdOp("sdm/export/charmaps")]
        void ExportCharMaps()
        {
            Sdm.ExportCharMaps();
        }

        [CmdOp("sdm/export/opcodes")]
        void ExportOpCodes()
        {
            Sdm.ExportOpCodes();
        }

        [CmdOp("sdm/export/sigops")]
        void ExportSigOps()
        {
            Sdm.ExportSigOps();
        }


        [CmdOp("sdm/import/forms")]
        void ImportForms()
        {
            Sdm.ImportForms();
        }

        [CmdOp("sdm/check/opcodes")]
        Outcome CheckAsmOpCodes(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Sdm.LoadOcDetails();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref src[i];
                ref readonly var input = ref detail.OpCodeExpr;
                SdmOpCodes.parse(detail.OpCodeExpr, out var opcode).Require();
                result = CheckEquality(input.Format(), opcode);
                if(result.Fail)
                {
                    result = (false, string.Format("Equality check failed for <{0}>", input.Format().Trim()));
                    break;
                }

                Write(string.Format("{0,-6} | {1,-16} | {2,-28} | {3}", detail.OpCodeKey, opcode.OcValue(), opcode, detail.AsmSig));
            }

            return result;
        }

        static bool CheckEquality(in CharBlock36 input, in SdmOpCode parsed)
            => input.Format().Trim().Equals(parsed.Format());

        [CmdOp("sdm/check/sigs")]
        Outcome CheckAsmSigs(CmdArgs args)
        {
            var details = Sdm.LoadOcDetails();
            var count = details.Count;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                AsmSigs.parse(detail.AsmSig.View, out var sig);
                buffer.Append(sig.Mnemonic.Format());
                if(sig.OpCount != 0)
                {
                    buffer.Append("<");
                    for(var j=0; j<sig.OpCount; j++)
                    {
                        if(j != 0)
                            buffer.Append(", ");

                        buffer.Append(AsmSigs.identify(sig[j]));
                    }
                    buffer.Append(">");
                }

                Write(buffer.Emit());
            }

            return true;
        }

        [CmdOp("sdm/forms/query")]
        Outcome AsmFormQuery(CmdArgs args)
        {
            var forms = Sdm.CalcForms();
            var count = forms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                ref readonly var opcode = ref form.OpCode;
                if(SdmOpCodes.imm(opcode, out var token))
                    Write(string.Format("{0} | {1}", token, form));
            }

            return true;
        }
 
         [CmdOp("sdm/inst")]
        void ShowInstInfo(CmdArgs args)
        {
            var details = Sdm.LoadOcDetails();
            var forms  = SdmOps.forms(details);
            for(var i=0; i<forms.Count; i++)
            {
                ref readonly var form = ref forms[i];
                ref readonly var opcode = ref details[i];

                Write(string.Format("{0,-16} | {1,-64} | {2}", form.Mnemonic, form.Sig, form.OpCode));
            }
        }

        [CmdOp("sdm/markers")]
        Outcome SdmMarkers(CmdArgs args)
        {
            var result = Outcome.Success;
            var markers = TextMarkers.discover(typeof(BinaryFormatMarkers));
            var lines = Sdm.LoadImportedVolume(VolDigit.V2);
            var count = (uint)lines.Length;
            var marker = TextMarkers.define(nameof(SdmEncodingSigs.RexW), SdmEncodingSigs.RexW);
            var matches = SdmMarkers(n5, lines, marker);
            DisplayMatches(lines, marker, matches);
            marker = TextMarkers.define(nameof(SdmEncodingSigs.ModRm), SdmEncodingSigs.ModRm);
            matches = SdmMarkers(n6, lines, marker);
            DisplayMatches(lines, marker, matches);
            return result;
        }

        void DisplayMatches(ReadOnlySpan<UnicodeLine> src, TextMarker marker, ReadOnlySpan<TextMatch> matches)
        {
            foreach(var m in matches)
                Write(skip(src, m.Match.Line.Value - 1));
            Write(string.Format("Matched {0} {1} markers", matches.Length, marker.Name));
        }

        ReadOnlySpan<TextMatch> SdmMarkers(N5 n, ReadOnlySpan<UnicodeLine> src, TextMarker marker)
        {
            var matches = list<TextMatch>();
            Unicodes.match(n, src, marker, m => matches.Add(m));
            return matches.ViewDeposited();
        }

        ReadOnlySpan<TextMatch> SdmMarkers(N6 n, ReadOnlySpan<UnicodeLine> src, TextMarker marker)
        {
            var matches = list<TextMatch>();

            void OnMatch(TextMatch match)
            {
                matches.Add(match);
            }

            Unicodes.match(n,src,marker,OnMatch);
            return matches.ViewDeposited();
        }
    }
}