//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using static sys;
    using static expr;

    public struct vector<N,T> : IVector<T>
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        public static ByteSize SZ => size<T>()*Typed.nat32u<N>();

        readonly Index<T> Data;

        [MethodImpl(Inline)]
        internal vector(T[] src)
        {
            Data = src;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref T Cell(uint index)
            => ref Data[index];

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        uint IVector.N
            => Typed.nat32u<N>();

        public static vector<N,T> Empty => default;
    }
}