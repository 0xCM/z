//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVectorType : ISizedType
    {
        /// <summary>
        /// The vector numeric cell kind
        /// </summary>
        ScalarType CellType {get;}

        uint CellCount => 0;
    }

    /// <summary>
    /// Characterizes an F-bound polymorphic reification that identifies an intrinsic vector generic type definition
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    [Free]
    public interface IVectorType<F,W> : IVectorWidth<F>, IEquatable<F>, IDataWidth
        where F : unmanaged, IVectorType<F,W>
        where W : unmanaged, ITypeWidth
    {
        bool IEquatable<F>.Equals(F other)
            => true;

        DataWidth IDataWidth.DataWidth
            => DataWidths.measure<W>();
    }

    [Free]
    public interface IVectorType<F,W,T> : IVectorType<F,W>, IVectorType
        where F : unmanaged, IVectorType<F,W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        bool INullity.IsEmpty
            => DataWidth == 0;

        bool INullity.IsNonEmpty
            => DataWidth != 0;

        NumericKind CellKind
            => NumericKinds.kind<T>();

        ScalarType IVectorType.CellType
            => default;
    }
}