//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct IlEncodingMap
    {
        public readonly Address32 IlOffset;

        public readonly MemoryAddress MinAddress;

        public readonly MemoryAddress MaxAddress;

        [MethodImpl(Inline)]
        public IlEncodingMap(Address32 il, MemoryAddress min, MemoryAddress max)
        {
            IlOffset = il;
            MinAddress = min;
            MaxAddress = max;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => (ByteSize)(MaxAddress - MinAddress);
        }
    }
}