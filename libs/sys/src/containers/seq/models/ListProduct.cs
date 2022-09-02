//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ListProduct<T>
    {
        public readonly Index<T> Left;

        public readonly Index<T> Right;

        public readonly Pairings<T,Index<T>> Result;

        public ListProduct(T[] left, T[] rigth, Pairings<T,Index<T>> result)
        {
            Result = result;
            Left = left;
            Right = rigth;
        }
    }
}