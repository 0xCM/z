//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrMdRecords
    {
        public readonly record struct PdbInfo
        {
            public readonly Guid Id;

            public readonly int Revision;

            public readonly FS.FilePath Path;

            [MethodImpl(Inline)]
            public PdbInfo(Guid id, int rev, FS.FilePath path)
            {
                Id = id;
                Revision = rev;
                Path = path;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Id != Guid.Empty && Path.IsNonEmpty;
            }

            public static PdbInfo Empty
            {
                [MethodImpl(Inline)]
                get => new PdbInfo(Guid.Empty, 0, FS.FilePath.Empty);
            }

            public string Format()
                => IsNonEmpty ? string.Format("[{0}]{1}", Id, Path.ToUri()) : "Unavailable";

            public override string ToString()
                => Format();
        }
    }
}