//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct WfHostId : ITextual, IEquatable<WfHostId>, IComparable<WfHostId>
    {
        const byte Lo8u = byte.MaxValue;

        const ushort Lo16u = (ushort) Lo8u << 8 | Lo8u;

        const uint Lo24u = (uint) Lo16u << 8 | Lo8u;

        [MethodImpl(Inline), Op]
        public static WfHostId create(WfPartKind kind, Type src)
            => new WfHostId((((uint)src.MetadataToken & Lo24u) | ((uint)kind << 24) ) | (uint)src.AssemblyQualifiedName.GetHashCode());

        [MethodImpl(Inline), Op]
        public static WfHostId create(WfStepId step)
            => new WfHostId((((uint)step.HostKey & Lo24u) | (1u << 24) ) | (uint)(step.HostName?.GetHashCode() ?? 0));

        public ulong Value {get;}

        [MethodImpl(Inline)]
        public WfHostId(ulong value)
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

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Id);
        }

        public ulong Hash64
        {
            [MethodImpl(Inline)]
            get => Id;
        }

        [MethodImpl(Inline)]
        public bool Equals(WfHostId src)
            => Id == src.Id;

        [MethodImpl(Inline)]
        public int CompareTo(WfHostId src)
            => Id.CompareTo(src.Id);

        public override bool Equals(object src)
            => src is WfHostId t && Equals(t);
        public string Format()
            => string.Format("{0}:{1} {2}", Kind.ToString(), Offset, Id);

        public override int GetHashCode()
            => (int)Hash;

        public override string ToString()
            => Format();

        public static WfHostId Empty => default;
    }
}