//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct FileFilter
    {
        public Seq<FileExt> FileTypes;

        public Seq<FileKind> FileKinds;

        public Seq<SearchPattern> Inclusions;

        public Seq<SearchPattern> Exclusions;
    }
}