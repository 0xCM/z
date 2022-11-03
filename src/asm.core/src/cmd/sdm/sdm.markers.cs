//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Asm.SdmModels;
    using static sys;

    partial class AsmCoreCmd
    {
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