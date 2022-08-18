//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_bitview : t_bits<t_bitview>
    {
        public void bitview_8()
            => bitview_check<byte>();

        public void bitview_16()
            => bitview_check<ushort>();

        public void bitview_32()
            => bitview_check<uint>();

        public void bitview_64()
            => bitview_check<ulong>();

        void bitview_check<T>(T t = default)
            where T : unmanaged
        {
            var src = Limits.maxval<T>();
            var view = bits.editor(src);
            var bytecount = size<T>();

            for(var i=0; i<bytecount; i++)
            for(byte j=0; j<8; j++)
                view[i,j] = j % 2 == 0;

            var bs = BitStrings.scalar(src);
            for(var i=0; i<bytecount*8; i++)
                Claim.require(bs[i] == (i%2 == 0));
        }
    }
}