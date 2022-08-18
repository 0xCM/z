//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MemoryScales
    {
        [MethodImpl(Inline), Op]
        public static ScaledIndex index(ushort cell, sbyte dx, uint i)
            => new ScaledIndex(cell, dx, i);

        [MethodImpl(Inline), Op]
        public static MemoryScale scale(byte value)
            => scale((ScaleFactor)value);

        [MethodImpl(Inline), Op]
        public static MemoryScale scale(ScaleFactor factor)
            => new MemoryScale(factor);
    }
}