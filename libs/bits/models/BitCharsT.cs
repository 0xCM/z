//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct BitChars<T>
        where T : unmanaged
    {
        T Data;

        [MethodImpl(Inline)]
        public BitChars(T data)
        {
            Data = data;
        }

        public Span<BitChar> Edit
        {
            [MethodImpl(Inline)]
            get => recover<BitChar>(bytes(Data));
        }

        public ReadOnlySpan<BitChar> View
        {
            [MethodImpl(Inline)]
            get => recover<BitChar>(bytes(Data));
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => size<T>();
        }

        public ref BitChar this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,index);
        }
    }
}