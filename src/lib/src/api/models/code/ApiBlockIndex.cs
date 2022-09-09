//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public class ApiBlockIndex
    {
        readonly PartCodeAddresses CodeAddresses;

        readonly PartUriAddresses UriLocations;

        readonly PartCodeIndex PartIndex;

        readonly ApiCodeLookup UriCode;

        [MethodImpl(Inline)]
        public ApiBlockIndex(PartCodeAddresses memories, PartUriAddresses memuri, PartCodeIndex parts, ApiCodeLookup code)
        {
            CodeAddresses = memories;
            UriLocations = memuri;
            PartIndex = parts;
            UriCode = code;
        }

        public ApiIndexMetrics CalcMetrics()
        {
            var stats = default(ApiIndexMetrics);
            stats.HostCount = Hosts.Count;
            stats.AddressCount = Addresses.Count;
            stats.BlockCount = Blocks.Count;
            stats.IdentityCount = Identities.Count;
            stats.ByteCount = Blocks.Storage.Sum(x => x.Length);
            return stats;
        }

        /// <summary>
        /// The number of indexed functions
        /// </summary>
        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => CodeAddresses.Count;
        }

        /// <summary>
        /// The base addresses that identify entries in the index
        /// </summary>
        public Index<MemoryAddress> Addresses
        {
            [MethodImpl(Inline)]
            get => CodeAddresses.Addresses;
        }

        /// <summary>
        /// All indexed code
        /// </summary>
        public Index<ApiCodeBlock> Blocks
        {
            [MethodImpl(Inline)]
            get => CodeAddresses.Code;
        }

        public ref ApiCodeBlock this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Blocks[index];
        }

        public uint BlockCount
        {
            [MethodImpl(Inline)]
            get => CodeAddresses.Count;
        }

        /// <summary>
        /// Operation identifiers, each of which are associated with one or more code blocks
        /// </summary>
        public Index<OpUri> Identities
        {
            [MethodImpl(Inline)]
            get => UriLocations.Identities;
        }

        /// <summary>
        /// Hosts with at least one archived code block
        /// </summary>
        public Index<ApiHostUri> Hosts
        {
            [MethodImpl(Inline)]
            get => PartIndex.Hosts;
        }

        /// <summary>
        /// Hosts with at least one archived code block
        /// </summary>
        public Index<ApiHostUri> NonemptyHosts
        {
            [MethodImpl(Inline)]
            get => PartIndex.Hosts.Where(h => h.IsNonEmpty);
        }

        [MethodImpl(Inline)]
        public ApiCodeBlock Code(MemoryAddress location)
            => CodeAddresses[location];

        [MethodImpl(Inline)]
        public bool Code(OpUri uri, out ApiCodeBlock dst)
        {
            return UriCode.TryGetValue(uri, out dst);
        }

        [MethodImpl(Inline)]
        public ApiHostBlocks HostCodeBlocks(ApiHostUri host)
        {
            if(PartIndex.HostCode(host, out var code))
                return code;
            else
                return ApiHostBlocks.Empty;
        }

        // [MethodImpl(Inline)]
        // public ApiPartCode PartCodeBlocks(PartId id)
        //     => ApiPartCode.create(id, Hosts.Map(HostCodeBlocks));

        public ApiCodeBlock this[MemoryAddress location]
        {
            [MethodImpl(Inline)]
            get => Code(location);
        }

        public ApiHostBlocks this[ApiHostUri id]
        {
            [MethodImpl(Inline)]
            get => HostCodeBlocks(id);
        }

        // public ApiPartCode this[PartId id]
        // {
        //     [MethodImpl(Inline)]
        //     get => PartCodeBlocks(id);
        // }

        public static ApiBlockIndex Empty
        {
            [MethodImpl(Inline)]
            get => new ApiBlockIndex(PartCodeAddresses.Empty, PartUriAddresses.Empty, PartCodeIndex.Empty, ApiCodeLookup.Empty);
        }
    }
}