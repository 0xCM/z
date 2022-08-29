//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout, Pack=1)]
    public readonly struct CliHeapKey : ICliHeapKey<CliHeapKey>
    {
        public readonly CliHeapKind HeapKind;

        public readonly uint Value;

        [MethodImpl(Inline)]
        public CliHeapKey(CliHeapKind heap, uint value)
        {
            HeapKind = heap;
            Value = value;
        }

        CliHeapKind ICliHeapKey.HeapKind
            => HeapKind;

        uint ICliHeapKey.Value
            => Value;
    }
}