//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResolvedPart
    {
        public readonly PartId Part;

        public readonly FS.FilePath Location;

        public readonly Index<ResolvedHost> Hosts;

        public readonly uint MethodCount;

        public ResolvedPart(PartId part, FS.FilePath location, Index<ResolvedHost> hosts)
        {
            Part = part;
            Location = location;
            Hosts = hosts;
            MethodCount = (uint)Hosts.Select(x => (int)x.MethodCount).Storage.Sum();
        }

        public static ResolvedPart Empty
        {
            [MethodImpl(Inline)]
            get => new ResolvedPart(0, FS.FilePath.Empty, core.array<ResolvedHost>());
        }
    }
}