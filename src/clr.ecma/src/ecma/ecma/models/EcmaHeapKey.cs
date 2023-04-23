//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout, Pack=1)]
    public readonly struct EcmaHeapKey : IEcmaHeapKey<EcmaHeapKey>
    {
        public readonly EcmaHeapKind HeapKind;

        public readonly uint Value;

        [MethodImpl(Inline)]
        public EcmaHeapKey(EcmaHeapKind heap, uint value)
        {
            HeapKind = heap;
            Value = value;
        }

        EcmaHeapKind IEcmaHeapKey.HeapKind
            => HeapKind;

        uint IEcmaHeapKey.Value
            => Value;
    }
}