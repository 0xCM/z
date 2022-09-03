//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NameResolver<T> : INameResolver<T>
        where T : NameResolver<T>, new()
    {
        public int NameId {get; private set;}

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
            get => NameResolvers<T>.Instance.Resolve((T)this);
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
        public T WithId(int id)
        {
            NameId = id;
            return (T)this;
        }

        public virtual string Format()
            => Name;

        public override string ToString()
            => Format();

        public static T Empty => new T().WithId(-1);

        [MethodImpl(Inline)]
        public static explicit operator int(NameResolver<T> src)
            => src.NameId;

        [MethodImpl(Inline)]
        public static explicit operator uint(NameResolver<T> src)
            => (uint)src.NameId;

        [MethodImpl(Inline)]
        public static explicit operator NameResolver<T>(int src)
            => new NameResolver<T>(src);
    }
}