//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileSplitSpec
    {
        public readonly FS.FilePath SourcePath;

        public readonly Count MaxLineCount;

        public readonly FS.FolderPath TargetDir;

        public readonly TextEncodingKind TargetEncoding;

        [MethodImpl(Inline)]
        public FileSplitSpec(FS.FilePath src, Count maxlines, FS.FolderPath dst, TextEncodingKind encoding)
        {
            SourcePath = src;
            MaxLineCount = maxlines;
            TargetDir = dst;
            TargetEncoding = encoding;
        }
    }
}