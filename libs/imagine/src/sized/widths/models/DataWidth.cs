//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataWidth<W> : WData<DataWidth<W>>
        where W : unmanaged, IDataWidth
    {
        public static W Width => default;

        public uint BitWidth
        {
            [MethodImpl(Inline)]
            get => default(W).BitWidth;
        }

        public DataWidth Kind
        {
            [MethodImpl(Inline)]
            get => (DataWidth)BitWidth;
        }

        public TypeSign Sign
        {
            [MethodImpl(Inline)]
            get => Width.TypeSign;
        }

        [MethodImpl(Inline)]
        public static implicit operator uint(DataWidth<W> src)
            => src.BitWidth;

        [MethodImpl(Inline)]
        public static implicit operator W(DataWidth<W> src)
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator DataWidth(DataWidth<W> src)
            => src.Kind;
    }
}