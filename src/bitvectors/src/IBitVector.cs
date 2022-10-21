//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IBitVector : ITextual
    {
        BitWidth Width {get;}
    }

    public interface IBitVector<T> : IBitVector
        where T : unmanaged
    {
        /// <summary>
        /// The value over which the bitvector is defined
        /// </summary>
        T State {get;}

        BitWidth IBitVector.Width
            => width<T>();
    }

    public interface IBitVector<V,T> : IBitVector<T>, IEquatable<V>, IComparable<V>
        where V : unmanaged, IBitVector
        where T : unmanaged
    {

    }
}