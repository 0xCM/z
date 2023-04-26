//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FileStitch
    {   
        public readonly FilePath Source;

        public readonly Pair<string> Markers;

        public readonly FilePath Target;

        public FileStitch(FilePath src, Pair<string> markers, FilePath target)
        {
            Source = src;
            Markers = markers;
            Target = target;
        }
    }
}