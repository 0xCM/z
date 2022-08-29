//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class PartId<P> : IPartId<P>
        where P : PartId<P>, IPartId<P>,  new()
    {
        public PartId Id {get;}

        protected PartId(PartId id)
            => Id = id;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Id;
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Id.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PartId(PartId<P> src)
            => src.Id;

        [MethodImpl(Inline)]
        public static bool operator ==(PartId<P> p1, PartId<P> p2)
            => p1.Id == p2.Id;

        [MethodImpl(Inline)]
        public static bool operator !=(PartId<P> p1, PartId<P> p2)
            => p1.Id != p2.Id;

        [MethodImpl(Inline)]
        public bool Equals(P src)
            => Id == src.Id;

        public override bool Equals(object src)
            => src is P x && Equals(x);
    }
}