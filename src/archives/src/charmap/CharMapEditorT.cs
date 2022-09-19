//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = CharMaps;

    public readonly ref struct CharMapEditor<T>
        where T : unmanaged
    {
        readonly Span<T> Data;

        [MethodImpl(Inline)]
        internal CharMapEditor(Span<T> map)
        {
            Data = map;
        }

        public ref T this[char c]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data, (ushort)c);
        }

        [MethodImpl(Inline)]
        public void Assign(char input, T output)
            => seek(Data, (ushort)input) = output;

        [MethodImpl(Inline)]
        public ushort Assign(ushort offset, ReadOnlySpan<T> src)
            => api.assign(this, offset, src);

        [MethodImpl(Inline)]
        public CharMap<T> Seal()
            => new CharMap<T>(Data);

        [MethodImpl(Inline)]
        public static implicit operator CharMap<T>(CharMapEditor<T> src)
            => src.Seal();
    }
}