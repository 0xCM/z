//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record("bitmask.checks.himask")]
    public struct HiMaskLog<T>
    {
        [Render(8)]
        public byte Count;

        [Render(8)]
        public byte PopCount;

        [Render(32)]
        public T Mask;

        [Render(8)]
        public bit Check1;

        [Render(8)]
        public bit Check2;

        [Render(32)]
        public T Lowered;

        [Render(8)]
        public bit Check3;

        [Render(8)]
        public byte PackedWidth;
    }
}