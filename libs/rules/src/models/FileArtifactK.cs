//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileArtifact<K> : IFileArtifact<FileArtifact<K>,K>
        where K : unmanaged
    {
        public readonly FS.FileUri Source;

        public readonly K Kind;

        [MethodImpl(Inline)]
        public FileArtifact(K kind, FS.FileUri location)
        {
            Kind = kind;
            Source = location;
        }

        public PathPart Name
            => Source.Format();

        FS.FileUri IArtifact<K, FS.FileUri>.Location
            => Source;

        K IArtifact<K>.Kind
            => Kind;

        public string Format()
            => Source.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FileArtifact<K>((K kind, FS.FileUri locator) src)
            => new FileArtifact<K>(src.kind, src.locator);
    }
}