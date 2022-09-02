//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SeqProduct<T>
    {
        public readonly Index<T> Left;

        public readonly Index<T> Right;

        public readonly Pairs<T> Result;

        public SeqProduct(T[] left, T[] rigth, Pairs<T> result)
        {
            Result = result;
            Left = left;
            Right = rigth;
        }
    }
}