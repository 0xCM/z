//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public class t_gbb_dot : t_bits<t_gbb_dot>
    {
        public void gbb_dot_10x32()
            => gbb_dot_check<uint>(10);

        public void gbb_dot_20x32()
            => gbb_dot_check<uint>(20);

        public void gbb_dot_63x64()
            => gbb_dot_check<uint>(63);

        public void gbb_dot_84x64()
            => gbb_dot_check<ulong>(84);

        public void gbb_dot_87x64()
            => gbb_dot_check<ulong>(87);

        public void gbb_dot_87x8()
            => gbb_dot_check<byte>(87);

        public void gbb_dot_128x16()
            => gbb_dot_check<ushort>(128);

        public void gbb_dot_25x16()
            => gbb_dot_check<ushort>(25);

        public void gbb_dot_256x64()
            => gbb_dot_check<ulong>(256);

        public void gbb_dot_2048x32()
            => gbb_dot_check<uint>(2048);

        /// <summary>
        /// Verifies the generic bit cell dot product operation
        /// </summary>
        /// <param name="n">The maximum effective width of a cell</param>
        /// <typeparam name="T">The cell type</typeparam>
        protected void gbb_dot_check<T>(int n)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitBlock<T>(n);
                var y = Random.BitBlock<T>(n);
                var a = x % y;
                var b = BitBlocks.modprod(x,y);
                Claim.require(a == b);
            }
        }
    }
}
