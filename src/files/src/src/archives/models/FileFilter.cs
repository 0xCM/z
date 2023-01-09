//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FileFilter
    {
        public Seq<FileExt> FileTypes;

        public Seq<FileKind> FileKinds;

        public Seq<SearchPattern> Inclusions;

        public Seq<SearchPattern> Exclusions;

        public FileFilter()
        {
            FileTypes = sys.empty<FileExt>();
            FileKinds = sys.empty<FileKind>();
            Inclusions = sys.empty<SearchPattern>();
            Exclusions = sys.empty<SearchPattern>();
        }

        public static FileFilter Empty => new();
    }
}