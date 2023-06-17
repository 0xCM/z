//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    public readonly struct ResolvedPart
    {
        public readonly PartName Part;

        public readonly FileUri Location;

        public readonly Index<ResolvedHost> Hosts;

        public readonly uint MethodCount;

        public ResolvedPart(PartName part, FileUri location, Index<ResolvedHost> hosts)
        {
            Part = part;
            Location = location;
            Hosts = hosts;
            MethodCount = (uint)Hosts.Select(x => (int)x.MethodCount).Storage.Sum();
        }

        public static ResolvedPart Empty
        {
            [MethodImpl(Inline)]
            get => new ResolvedPart(PartName.Empty, FileUri.Empty, sys.empty<ResolvedHost>());
        }
    }
}