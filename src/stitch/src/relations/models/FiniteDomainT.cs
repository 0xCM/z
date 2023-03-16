//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        public abstract class FiniteDomain<T>
        {
            public @string Name {get;}

            protected Index<T> Data;

            protected FiniteDomain(@string name)
            {
                Name = name;
            }

            public uint MemberCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ReadOnlySpan<T> Members
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public ref readonly T this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref readonly T this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }
        }
    }
}