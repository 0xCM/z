//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct Operational
    {
        public interface IFiniteInt<T> : IInteger<T>, IBoundReal<T>
            where T : unmanaged
        {

        }
    }
}