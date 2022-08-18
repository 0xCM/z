//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct SizedLocation
    {
        [MethodImpl(Inline), Op]
        public static SizedLocation define(ushort seq, ushort size, uint offset)
            => new SizedLocation(seq, size, offset);

        public readonly ushort Seq;

        public readonly ushort Size;

        public readonly uint Offset;

        [MethodImpl(Inline)]
        public SizedLocation(ushort seq, ushort size, uint offset)
        {
            Seq = seq;
            Size = size;
            Offset = offset;
        }

        public string Format()
            => string.Format("{0}:{1}:{2}", Seq.ToString("D4"), Size.FormatHex(), Offset.FormatHex(zpad:false));

        public override string ToString()
            => Format();
    }
}