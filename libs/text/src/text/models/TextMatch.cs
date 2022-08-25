//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TextMatch
    {
        [MethodImpl(Inline), Op]
        public static TextMatch matched(TextMarker marker, LineOffset offset)
            => new TextMatch(marker,offset);

        public TextMarker Marker {get;}

        public LineOffset Match {get;}

        [MethodImpl(Inline)]
        public TextMatch(TextMarker marker, LineOffset match)
        {
            Marker = marker;
            Match = match;
        }
    }
}