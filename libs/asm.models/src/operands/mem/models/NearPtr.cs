//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [DataTypeAttributeD("asm.nearptr")]
    public readonly struct NearPtr
    {
        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public NearPtr(MemoryAddress address)
        {
            Address = address;
        }

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NearPtr(MemoryAddress src)
            => new NearPtr(src);
    }
}