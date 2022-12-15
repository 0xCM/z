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

        public readonly MemoryAddress BaseAddress;

        public readonly MemoryAddress LastAddress;

        [MethodImpl(Inline)]
        public IlEncodingMap(Address32 il, MemoryAddress min, MemoryAddress max)
        {
            IlOffset = il;
            BaseAddress = min;
            LastAddress = max;
        }
    }
}