//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct CmpEval<T>
    {
        public CmpPredKind OpKind;

        public T A;

        public T B;

        public bool Result;

        [MethodImpl(Inline)]
        public CmpEval(CmpPredKind kind, T a, T b, bool result)
        {
            OpKind = kind;
            A = a;
            B = b;
            Result = result;
        }
    }
}