//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct EcmaStringKey : IEcmaHeapKey<EcmaStringKey>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.SystemString;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public EcmaStringKey(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public EcmaStringKey(StringHandle value)
            => Value = u32(value);

        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(EcmaStringKey src)
            => new EcmaHeapKey(src.HeapKind, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator EcmaStringKey(StringHandle src)
            => new EcmaStringKey(src);

        [MethodImpl(Inline)]
        public static implicit operator StringHandle(EcmaStringKey src)
            => @as<EcmaStringKey,StringHandle>(src);
    }
}