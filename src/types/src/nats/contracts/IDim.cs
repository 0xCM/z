//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TypeNats;

    /// <summary>
    /// Characterizes a dimension of arbitrary order
    /// </summary>
    public interface IDim
    {
        /// <summary>
        /// Specifies the number of axes in the dimension
        /// </summary>
        int Order {get;}

        /// <summary>
        /// Specifies the maximum number of cells that may inhabit the associated space
        /// </summary>
        ulong Volume {get;}

        /// <summary>
        /// Gets the dimension axis determined by its 0-based index, an integer in the interval [0,Order-1]
        /// </summary>
        ulong this[int axis] {get;}
    }

    public interface IDim1 : IDim
    {
        ulong I {get;}
    }

    public interface IDim2<T> : ITextual
        where T : unmanaged
    {
        T I {get;}

        T J {get;}

        string ITextual.Format()
            => $"{I}x{J}";
    }

    public interface IDim2 : IDim
    {
        ulong I {get;}

        ulong J {get;}
    }

    public interface IDim<M,N>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
    {
        /// <summary>
        /// Specifies the first component of the dimension
        /// </summary>
        int RowCount => (int)value<M>();

        /// <summary>
        /// Specifies the second component of the dimension
        /// </summary>
        int ColCount => (int)value<M>();
    }
}