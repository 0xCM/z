//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using static core;
    using static expr;

    [StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("g4x4<t:{0}>")]
    public struct g4x4<T> : IGrid<g4x4<T>,N4,T>
        where T : unmanaged
    {
        v4<T> R0;

        v4<T> R1;

        v4<T> R2;

        v4<T> R3;

        public uint M => 4;

        public uint N => 4;

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