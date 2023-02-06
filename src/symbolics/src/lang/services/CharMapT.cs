//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly ref struct CharMap<T>
        where T : unmanaged
    {
        readonly ReadOnlySpan<T> Data;

        [MethodImpl(Inline)]
        public CharMap(ReadOnlySpan<T> data)
        {
            Data = data;
        }

        public ref readonly T this[char c]
        {
            [MethodImpl(Inline)]
            get => ref skip(Data, (ushort)c);
        }

        [MethodImpl(Inline)]
        public bool IsMapped(char c)
            => u16(this[c]) != 0;

        public ReadOnlySpan<T> Terms
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ushort Capacity
        {
            [MethodImpl(Inline)]
            get => (ushort)Data.Length;
        }
    }
}