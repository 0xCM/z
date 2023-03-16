//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EcmaGuidKey : IEcmaHeapKey<EcmaGuidKey>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.Guid;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public EcmaGuidKey(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public EcmaGuidKey(GuidHandle value)
        {
            Value = sys.u32(value);
        }

        [MethodImpl(Inline)]
        public static implicit operator EcmaGuidKey(GuidHandle src)
            => new EcmaGuidKey(src);

        [MethodImpl(Inline)]
        public static implicit operator GuidHandle(EcmaGuidKey src)
            => sys.@as<EcmaGuidKey,GuidHandle>(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(EcmaGuidKey src)
            => new EcmaHeapKey(src.HeapKind, src.Value);
    }
    
}