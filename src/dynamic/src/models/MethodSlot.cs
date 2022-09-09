//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct MethodSlot
    {
        public readonly MemoryAddress Address;

        public readonly NameOld Name;

        [MethodImpl(Inline)]
        public MethodSlot(NameOld name, MemoryAddress address)
        {
            Name = name;
            Address = address;
        }

        public string Format()
            => string.Format("{0}: {1}", Address, Name);

        public override string ToString()
            => Format();
    }
}