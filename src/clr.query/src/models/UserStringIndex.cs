//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct UserStringIndex : IEcmaHeapKey<UserStringIndex>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.UserString;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public UserStringIndex(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(UserStringIndex src)
            => new EcmaHeapKey(src.HeapKind, src.Value);
    }
}