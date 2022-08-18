//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Chars;

    /// <summary>
    /// Describes an embedded data resource
    /// </summary>
    public readonly struct BinaryAsset
    {
        public readonly string Name;

        public readonly Assembly Owner;

        public readonly ByteSize Size;

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public BinaryAsset(Assembly part, string name, ByteSize size, MemoryAddress address)
        {
            Owner = part;
            Name = name;
            Size = size;
            Address = address;
        }

        public bool IsEmpty
            => Address == 0;

        public string Uri
            => string.Concat("res", Colon, FSlash, FSlash, Owner.Format(), FSlash, Name);

        public unsafe ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => new ReadOnlySpan<byte>(Address.Pointer<byte>(), Size);
        }
    }
}