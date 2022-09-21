//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Events;

    public class t_gbb_create : t_bits<t_gbb_create>
    {
        public void gbb_create_124x8()
            => check_gbb_create<byte>(124, caller());

        public void gbb_create_128x8()
            => check_gbb_create<byte>(128, caller());

        public void gbb_create_13x16()
            => check_gbb_create<ushort>(13, caller());

        public void gbb_create_125x16()
            => check_gbb_create<ushort>(125, caller());

        public void gbb_create_128x16()
            => check_gbb_create<ushort>(128, caller());

        public void gbb_create_13x32()
            => check_gbb_create<uint>(13, caller());

        public void gbb_create_64x32()
            => check_gbb_create<uint>(64, caller());

        public void gbb_create_125x32()
            => check_gbb_create<uint>(125, caller());

        public void gbb_create_128x32()
            => check_gbb_create<uint>(128, caller());

        public void gbb_create_63x64()
            => check_gbb_create<ulong>(63, caller());

        public void gbb_create_127x64()
            => check_gbb_create<ulong>(127, caller());

        public void gbb_create_128x64()
            => check_gbb_create<ulong>(128, caller());

        protected void check_gbb_create<T>(int bitcount, in CallingMember caller)
            where T : unmanaged
        {
            var kCells = (int)CellCalcs.mincells<T>((ulong)bitcount);

            if(DiagnosticMode)
                term.print($"Executing {caller.CallerName}: {bitcount} bits covered by {kCells} cells of kind {typeof(T).DisplayName()}");

            var src = Random.Span<T>(RepCount);
            for(var i=0; i<RepCount; i += kCells)
            {
                var data = src.Slice(i, kCells);
                var bc = data.ToBitBLock(bitcount);
                var bs = data.ToBitString(bitcount);
                Claim.eq(bc.BitCount, bitcount);
                Claim.eq(bs.Length, bitcount);

                for(var j=0; j<bc.BitCount; j++)
                    Claim.eq(bc[j], bs[j]);
            }
        }
    }
}