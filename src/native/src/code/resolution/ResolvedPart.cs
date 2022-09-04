//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResolvedPart
    {
        public readonly PartName Part;

        public readonly FilePath Location;

        public readonly Index<ResolvedHost> Hosts;

        public readonly uint MethodCount;

        public ResolvedPart(PartName part, FilePath location, Index<ResolvedHost> hosts)
        {
            Part = part;
            Location = location;
            Hosts = hosts;
            MethodCount = (uint)Hosts.Select(x => (int)x.MethodCount).Storage.Sum();
        }

        public static ResolvedPart Empty
        {
            [MethodImpl(Inline)]
            get => new ResolvedPart(PartName.Empty, FilePath.Empty, sys.empty<ResolvedHost>());
        }
    }
}