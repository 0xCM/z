//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct GuidIndex : IEcmaHeapKey<GuidIndex>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.Guid;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public GuidIndex(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public GuidIndex(GuidHandle value)
        {
            Value = sys.u32(value);
        }

        [MethodImpl(Inline)]
        public static implicit operator GuidIndex(GuidHandle src)
            => new GuidIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(GuidIndex src)
            => new EcmaHeapKey(src.HeapKind, src.Value);
    }
}