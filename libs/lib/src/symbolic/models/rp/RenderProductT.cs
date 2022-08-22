//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = MsgOps;


    public readonly struct RenderProduct<T> : IRenderProduct<T>
    {
        public IFormatPattern Pattern {get;}

        public T Product {get;}

        [MethodImpl(Inline)]
        public RenderProduct(IFormatPattern pattern, T product)
        {
            Pattern = pattern;
            Product = product;
        }

        [MethodImpl(Inline)]
        public static implicit operator T(RenderProduct<T> src)
            => src.Product;
    }
}