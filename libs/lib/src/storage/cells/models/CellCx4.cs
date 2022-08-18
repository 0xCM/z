//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   public struct Cell<A,B,C,D>  : IDataCell<Cell<A,B,C,D>>
        where A : unmanaged, IDataCell<A>
        where B : unmanaged, IDataCell<B>
        where C : unmanaged, IDataCell<C>
        where D : unmanaged, IDataCell<D>
    {
        public A C0;

        public B C1;

        public C C2;

        public D C3;

        [MethodImpl(Inline)]
        public Cell(in A c0, in B c1, in C c2, in D c3)
        {
            C0 = c0;
            C1 = c1;
            C2 = c2;
            C3 = c3;
        }

        public string Format()
            => string.Format(RpOps.Adjacent4, C0, C1, C2, C3);
    }
}
