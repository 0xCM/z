//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IMultiplicativeSemigroup<T> : ISemigroup<T>, IMultiplicative<T>
        {

        }
    }
}