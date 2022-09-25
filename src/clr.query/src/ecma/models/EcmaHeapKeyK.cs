//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout)]
    public readonly struct EcmaHeapKey<K> : IEcmaHeapKey<EcmaHeapKey<K>>
        where K : unmanaged, IEcmaHeapKey
    {
        public EcmaHeapKind HeapKind => default(K).HeapKind;

        public readonly uint Value;

        [MethodImpl(Inline)]
        public EcmaHeapKey(uint value)
        {
            Value = value;
        }

        uint IEcmaHeapKey.Value
            => Value;


        [MethodImpl(Inline)]
        public bool Equals(EcmaHeapKey<K> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(EcmaHeapKey<K> src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(EcmaHeapKey<K> src)
            => new EcmaHeapKey(src.HeapKind, src.Value);
    }
}