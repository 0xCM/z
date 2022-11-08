//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        public readonly struct ContentMarkers
        {
            [TextMarker]
            public const string ChapterNumber = "CHAPTER ";

            [TextMarker]
            public const string TableNumber = "Table ";

            [TextMarker]
            public const string TocTitle = " . . . . . . . . . .";

            [TextMarker]
            public const string VolNumber = "Vol. ";
        }
    }
}