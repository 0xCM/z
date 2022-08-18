//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures the input and result of a binary evaluation
    /// </summary>
    public struct BinaryEval<K,T,R>
    {
        public K Kind;

        public T A;

        public T B;

        public R Result;
    }

    public struct BinaryEval<T> : IBinaryEval<T>
    {
        public T A {get;}

        public T B {get;}

        public bit Result {get;}

        [MethodImpl(Inline)]
        public BinaryEval(T a, T b, bit success)
        {
            A = a;
            B = b;
            Result = success;
        }

        [MethodImpl(Inline)]
        public static bool operator true(BinaryEval<T> src)
            => src.Result;

        [MethodImpl(Inline)]
        public static bool operator false(BinaryEval<T> src)
            => !src.Result;
    }
}