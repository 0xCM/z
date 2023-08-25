//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static Asm.SdmModels;
using static sys;

partial class IntelSdmCmd : WfAppCmd<IntelSdmCmd>
{
    IntelSdm Sdm => Wf.IntelSdm();

    [CmdOp("sdm/export/charmaps")]
    void ExportCharMaps()
    {
        Sdm.ExportCharMaps();
    }

    [CmdOp("sdm/export/splits")]
    void ExportSplits()
    {
        Sdm.ExportSplitDefs();
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


    [CmdOp("sdm/opcodes")]
    void CheckAsmOpCodes()
    {            
        var src = Sdm.CalcOpCodes();
        var formatter = CsvTables.formatter<SdmOpCodeDetail>();
        iter(src, oc => {
            Channel.Row(formatter.Format(oc));
        });
        // var result = Outcome.Success;
        // var src = Sdm.LoadOcDetails();
        // var count = src.Count;
        // var tokens = list<string>();
        // for(var i=0; i<count; i++)
        // {
        //     ref readonly var detail = ref src[i];
        //     ref readonly var input = ref detail.OpCodeExpr;
        //     tokens.Clear();
        //     SdmOpCodes.tokenize(detail.OpCodeExpr, tokens);
        //     var expr = tokens.Join(EmptyString);
        //     if(expr != detail.OpCodeExpr)
        //     {
        //         Channel.Error($"Equality failure: {expr} != {detail.OpCodeExpr}");
        //         break;
        //     }

        //     Channel.Row(tokens.Join(EmptyString));
        // }            
    }

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

            Channel.Write(buffer.Emit());
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

            Channel.Write(string.Format("{0,-16} | {1,-64} | {2}", form.Mnemonic, form.Sig, form.OpCode));
        }
    }

    [CmdOp("sdm/markers")]
    Outcome SdmMarkers()
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
            Channel.Write(skip(src, m.Match.Line.Value - 1));
        Channel.Write(string.Format("Matched {0} {1} markers", matches.Length, marker.Name));
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
