//-----------------------------------------------------------------------------
// Copyright   :  Microsoft/DotNet Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace System.Reflection.Metadata
{
    [Flags]
    public enum MetadataVisualizerOptions
    {
        None = 0,

        ShortenBlobs = 1,

        NoHeapReferences = 1 << 1
    }
}