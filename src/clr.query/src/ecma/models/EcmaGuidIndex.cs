//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaGuidIndex : IEcmaHeapKey<EcmaGuidIndex>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.Guid;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public EcmaGuidIndex(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public EcmaGuidIndex(GuidHandle value)
        {
            Value = sys.u32(value);
        }

        [MethodImpl(Inline)]
        public static implicit operator EcmaGuidIndex(GuidHandle src)
            => new EcmaGuidIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator GuidHandle(EcmaGuidIndex src)
            => sys.@as<EcmaGuidIndex,GuidHandle>(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(EcmaGuidIndex src)
            => new EcmaHeapKey(src.HeapKind, src.Value);
    }
    
}