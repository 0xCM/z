//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class Polynomials
    {
        [MethodImpl(Inline)]
        public static Polynomial<T> define<T>(params (T scalar, uint exp)[] terms)
            where T : unmanaged
        {
            var expanse = new Monomial<T>[terms[0].exp + 1];
            for(var i = 0; i < terms.Length; i++)
                expanse[terms[i].exp] = terms[i];
            expanse.Reverse();
            return new Polynomial<T>(expanse);
        }
    }
}