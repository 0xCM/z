//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct Rip
    {
        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public Rip(MemoryAddress callsite, byte instsize)
        {
            Address = callsite + instsize;
        }

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Rip((MemoryAddress call, byte instsize) src)
            => new Rip(src.call, src.instsize);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Rip src)
            => src.Address;

        [MethodImpl(Inline)]
        public static explicit operator int(Rip src)
            => (int)src.Address;

        [MethodImpl(Inline)]
        public static explicit operator long(Rip src)
            => (long)src.Address;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Rip src)
            => src.Address;
    }
}