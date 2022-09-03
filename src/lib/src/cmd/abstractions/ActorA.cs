//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class Actor<A> : IActor
        where A : Actor<A>, new()
    {
        public Name Name {get;}

        static A _Instance = new();

        public static ref readonly A Instance
        {
            [MethodImpl(Inline)]
            get => ref _Instance;
        }

        protected Actor(Name name)
        {
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

    }
}