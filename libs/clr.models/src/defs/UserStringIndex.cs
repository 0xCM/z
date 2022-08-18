//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct UserStringIndex : ICliHeapKey<UserStringIndex>
    {
        public CliHeapKind HeapKind => CliHeapKind.UserString;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public UserStringIndex(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator CliHeapKey(UserStringIndex src)
            => new CliHeapKey(src.HeapKind, src.Value);
    }
}