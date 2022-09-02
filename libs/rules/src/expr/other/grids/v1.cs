//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using static sys;
    using static expr;

    /// <summary>
    /// Defines a 1-cell T-vector
    /// </summary>
    public struct v1<T> : IVector<T>
        where T : unmanaged
    {
        T C0;

        [MethodImpl(Inline)]
        public v1(T src)
        {
            C0 = src;
        }

        public uint N => 1;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cells(ref this);
        }

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells, i);
        }

        public BitWidth StorageWidth
        {
            [MethodImpl(Inline)]
            get => N*size<T>();
        }

        public BitWidth ContentWidth
        {
            [MethodImpl(Inline)]
            get => StorageWidth;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator v1<T>(T src)
            => new v1<T>(src);
    }
}