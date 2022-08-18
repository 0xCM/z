//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public readonly struct FixedLineSegment
    {
        public readonly ushort Index;

        public readonly ushort Min;

        public readonly ushort Max;

        [MethodImpl(Inline)]
        public FixedLineSegment(ushort index, ushort min, ushort max)
        {
            Index = index;
            Min = min;
            Max = max;
        }

        public ushort Length
        {
            [MethodImpl(Inline)]
            get => (ushort)(Max - Min);
        }

        public string Format()
            => string.Format("[{0}:({1},{2})]", Index, Min, Max);

        public override string ToString()
            => Format();
    }

}