//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct ApiToken : IDataType<ApiToken>
    {
        readonly LocatedSymbol Entry;

        readonly LocatedSymbol Target;

        [MethodImpl(Inline)]
        public ApiToken(LocatedSymbol entry, LocatedSymbol impl)
        {
            Entry = entry;
            Target = impl;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Entry.IsEmpty || Target.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public Hex64 Id
        {
            [MethodImpl(Inline)]
            get => (ulong)EntryAddress.Lo() | ((ulong)TargetAddress.Lo() << 32);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => EntryAddress.Hash | TargetAddress.Hash;
        }

        public Hex32 EntryId
        {
            [MethodImpl(Inline)]
            get => (Hex32)(Entry.Location.Hash | Entry.Name.Address.Hash);
        }

        public Hex32 TargetId
        {
            [MethodImpl(Inline)]
            get => (Hex32)(Target.Location.Hash | Target.Name.Address.Hash);
        }

        public MemoryAddress EntryAddress
        {
            [MethodImpl(Inline)]
            get => Entry.Location;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Target.Location;
        }

        public Label Uri
        {
            [MethodImpl(Inline)]
            get => Entry.Name;
        }

        public Label Sig
        {
            [MethodImpl(Inline)]
            get => Target.Name;
        }

        public _ApiHostUri Host
        {
            get
            {
                if(ApiIdentity.parse(Uri.Format(), out var uri))
                    return uri.Host;
                else
                    return _ApiHostUri.Empty;
            }
        }

        public bool IsStubbed
        {
            [MethodImpl(Inline)]
            get => EntryAddress != TargetAddress;
        }

        public bool Equals(ApiToken src)
            => Entry.Equals(src.Entry) && Target.Equals(src.Target);

        public override int GetHashCode()
            => Hash;

        public int CompareTo(ApiToken src)
        {
            var result = Entry.CompareTo(src.Entry);
            if(result == 0)
                result = Target.CompareTo(src.Target);
            return result;
        }

        public static ApiToken Empty => default;
    }
}