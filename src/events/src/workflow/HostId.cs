//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct HostId : IDataType<HostId>
    {
        const byte Lo8u = byte.MaxValue;

        const ushort Lo16u = (ushort) Lo8u << 8 | Lo8u;

        const uint Lo24u = (uint) Lo16u << 8 | Lo8u;

        [MethodImpl(Inline), Op]
        public static HostId create(WfPartKind kind, Type src)
            => new HostId((((uint)src.MetadataToken & Lo24u) | ((uint)kind << 24) ) | (uint)src.AssemblyQualifiedName.GetHashCode());

        [MethodImpl(Inline), Op]
        public static HostId create(StepId step)
            => new HostId((((uint)step.HostKey & Lo24u) | (1u << 24) ) | (uint)(step.HostName?.GetHashCode() ?? 0));

        public ulong Value {get;}

        [MethodImpl(Inline)]
        public HostId(ulong value)
            => Value = value;

        public WfPartKind Kind
        {
            [MethodImpl(Inline)]
            get => (WfPartKind)((uint)Value >> 24);
        }

        public uint Offset
        {
            [MethodImpl(Inline)]
            get => (uint)Value & Lo24u;
        }

        public uint Id
        {
            [MethodImpl(Inline)]
            get => (uint)(Value >> 32);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Id;
        }

        public Hash64 Hash64
        {
            [MethodImpl(Inline)]
            get => Id;
        }

        [MethodImpl(Inline)]
        public bool Equals(HostId src)
            => Id == src.Id;

        [MethodImpl(Inline)]
        public int CompareTo(HostId src)
            => Id.CompareTo(src.Id);
        public string Format()
            => string.Format("{0}:{1} {2}", Kind.ToString(), Offset, Id);

        public override int GetHashCode()
            => (int)Hash;

        public override string ToString()
            => Format();

        public static HostId Empty => default;
    }
}