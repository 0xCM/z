//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout)]
    public readonly struct CliHeapKey<K> : ICliHeapKey<CliHeapKey<K>>
        where K : unmanaged, ICliHeapKey
    {
        public CliHeapKind HeapKind => default(K).HeapKind;

        public readonly uint Value;

        [MethodImpl(Inline)]
        public CliHeapKey(uint value)
        {
            Value = value;
        }

        uint ICliHeapKey.Value
            => Value;


        [MethodImpl(Inline)]
        public bool Equals(CliHeapKey<K> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(CliHeapKey<K> src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator CliHeapKey(CliHeapKey<K> src)
            => new CliHeapKey(src.HeapKind, src.Value);
    }
}