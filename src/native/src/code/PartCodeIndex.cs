//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using LU = System.Collections.Generic.Dictionary<ApiHostUri,ApiHostBlocks>;

    public readonly struct PartCodeIndex
    {
        readonly ApiHostCodeLookup Data;

        [MethodImpl(Inline)]
        public PartCodeIndex(ApiHostCodeLookup src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public PartCodeIndex(LU src)
        {
            Data = ApiHostCodeLookup.create(src);
        }

        public PartCodeIndexEntry[] Entries
            => entries(this);

        public bool HostCode(ApiHostUri host, out ApiHostBlocks code)
        {
            if(Data.TryGetValue(host, out code))
                return true;
            else
            {
                code = default;
                return false;
            }
        }

        public int HostCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ApiHostUri[] Hosts
        {
            [MethodImpl(Inline)]
            get => Data.Keys.ToArray();
        }

        public Index<ApiCodeBlock> this[ApiHostUri src]
        {
            [MethodImpl(Inline)]
            get => Data[src].Blocks;
        }

        public static PartCodeIndex Empty
        {
            [MethodImpl(Inline)]
            get => new PartCodeIndex(ApiHostCodeLookup.Empty);
        }

        static PartCodeIndexEntry[] entries(in PartCodeIndex src)
        {
            var buffer = new List<PartCodeIndexEntry>(src.Data.Count);
            foreach(var item in src.Data)
                buffer.Add(new PartCodeIndexEntry(item.Key, item.Value));
            return buffer.ToArray();
        }
    }
}