//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileSplitSpec
    {
        public readonly FilePath SourcePath;

        public readonly Count MaxLineCount;

        public readonly FolderPath TargetDir;

        public readonly TextEncodingKind TargetEncoding;

        [MethodImpl(Inline)]
        public FileSplitSpec(FilePath src, Count maxlines, FolderPath dst, TextEncodingKind encoding)
        {
            SourcePath = src;
            MaxLineCount = maxlines;
            TargetDir = dst;
            TargetEncoding = encoding;
        }
    }
}