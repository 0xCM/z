//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVectorWidth : ICellWidth
    {
        /// <summary>
        /// Defines a class specifier for use as a discriminator
        /// </summary>
        NativeVectorWidth VectorWidth
            => (NativeVectorWidth)BitWidth;
    }

    public interface IVectorWidth<F> : IVectorWidth, ICellWidth<F>, IFixedWidth<F>
        where F : unmanaged, IVectorWidth<F>
    {

    }
}