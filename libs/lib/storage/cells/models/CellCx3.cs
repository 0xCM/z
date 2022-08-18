//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct Cell<A,B,C> : IDataCell<Cell<A,B,C>>
        where A : unmanaged, IDataCell<A>
        where B : unmanaged, IDataCell<B>
        where C : unmanaged, IDataCell<C>
    {
        public A C0;

        public B C1;

        public C C2;

        [MethodImpl(Inline)]
        public Cell(in A c0, in B c1, in C c2)
        {
            C0 = c0;
            C1 = c1;
            C2 = c2;
        }

        public string Format()
            => string.Format(RpOps.Adjacent3, C0, C1, C2);
    }
}