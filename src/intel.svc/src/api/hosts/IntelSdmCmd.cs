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

    IntelSdm IntelSdm => Wf.IntelSdm();

    IDbArchive AsmDb => EnvDb.Scoped("asm.db");


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

    [CmdOp("sdm/instructions")]
    void LoadInstructions()
    {        
        var dst = bag<SdmOpCodeRow>();
        var files = IntelSdm.InstructionFiles();
        foreach(var file in files)
        {
            var lines = file.ReadLines();
            for(var i=0; i<lines.Count-2; i++)
            {
                if(lines[i].StartsWith( "## OpCodes") && lines[i+1].StartsWith("-----"))
                {
                    i+=2;
                    var header = text.trim(lines[i].Split(Chars.Pipe)).Mapi((i,x) => (i,x));
                    i++;
                    while(i++ < lines.Count)
                    {
                        if(empty(lines[i]))
                            break;
                        
                        var cells = text.trim(text.split(lines[i], Chars.Pipe)).ToSeq();
                        var row = new SdmOpCodeRow();
                        if(cells.Length >= 3)
                        {
                            row.OpCode = cells[0];
                            row.Instruction = cells[1];
                            row.Encoding = cells[2];
                            dst.Add(row);
                        }

                        if(cells.Length >= 4)
                        {
                            row.Mode64 = cells[3];
                        }

                        if(cells.Length >= 5)
                        {
                            row.Description = cells.Last;
                        }

                    }
                }
            }
        }
        Channel.TableEmit(dst.Array().Sort(), AsmDb.Path("sdm.opcodes", FileKind.Csv));
    }    
}
