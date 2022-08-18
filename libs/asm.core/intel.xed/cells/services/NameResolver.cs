//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NameResolver : INameResolver<NameResolver>
    {
        public int NameId {get;}

        public NameResolver()
        {
            NameId = -1;
        }

        public NameResolver(int id)
        {
            NameId = id;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => NameResolvers.Instance.Resolve(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => NameId < 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => NameId >= 0;
        }

        [MethodImpl(Inline)]
        public NameResolver WithId(int id)
            => new NameResolver(id);

        public string Format()
            => Name;

        public override string ToString()
            => Format();

        public static NameResolver Empty => new NameResolver(-1);

        [MethodImpl(Inline)]
        public static explicit operator int(NameResolver src)
            => src.NameId;

        [MethodImpl(Inline)]
        public static explicit operator uint(NameResolver src)
            => (uint)src.NameId;

        [MethodImpl(Inline)]
        public static explicit operator NameResolver(int src)
            => new NameResolver(src);

        [MethodImpl(Inline)]
        public static explicit operator ulong(NameResolver src)
            => (ulong)src.NameId;

        [MethodImpl(Inline)]
        public static explicit operator NameResolver(ulong src)
            => new NameResolver((int)src);
    }
}