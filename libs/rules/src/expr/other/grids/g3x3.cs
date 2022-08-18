//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using static core;
    using static expr;

    [StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("g3x3<t:{0}>")]
    public struct g3x3<T> : IGrid<g3x3<T>,N3,T>
        where T : unmanaged
    {
        v3<T> R0;

        v3<T> R1;

        v3<T> R2;

        public uint M => 3;

        public uint N => 3;

        public uint MxN => M*N;

        public GridDim Dim
        {
            [MethodImpl(Inline)]
            get => (M,N);
        }

        public BitWidth StorageWidth
        {
            [MethodImpl(Inline)]
            get => M*N*size<T>();
        }

        public BitWidth ContentWidth
        {
            [MethodImpl(Inline)]
            get => StorageWidth;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cells(ref this);
        }

        public Span<T> this[uint r]
        {
            [MethodImpl(Inline)]
            get => row(ref this, r);
        }

        public ref T this[uint r, uint c]
        {
            [MethodImpl(Inline)]
            get => ref seek(this[r], c);
        }

        public GridSpec Spec
        {
            [MethodImpl(Inline)]
            get => spec<T>(M,N);
        }
    }
}