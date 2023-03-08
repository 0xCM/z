//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct EcmaStringIndex : IEcmaHeapKey<EcmaStringIndex>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.SystemString;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public EcmaStringIndex(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public EcmaStringIndex(StringHandle value)
            => Value = u32(value);

        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(EcmaStringIndex src)
            => new EcmaHeapKey(src.HeapKind, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator EcmaStringIndex(StringHandle src)
            => new EcmaStringIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator StringHandle(EcmaStringIndex src)
            => @as<EcmaStringIndex,StringHandle>(src);
    }
}