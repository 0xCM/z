//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    public class t_nbg_define : t_bits<t_nbg_define>
    {
        public void bg_define_3x5x8()
            => nbg_define_check(n3, n5, z8);

        public void bg_define_17x11x8()
            => nbg_define_check(n17, n11, z8);

        public void bg_define_30x30x32()
            => nbg_define_check(n30, n30, z32);

        public void bg_define_32x32x64()
            => nbg_define_check(n32, n32, z64);

        public void bg_define_32x33x64()
            => nbg_define_check(n32, n33, z64);

        public void bg_define_32x34x64()
            => nbg_define_check(n32, n34, z64);

        public void bg_define_32x35x64()
            => nbg_define_check(n32, n35, z64);

        public void bg_define_42x32x64()
            => nbg_define_check(n42, n32, z64);

        public void bg_define_33x42x64()
            => nbg_define_check(n33,n42, z64);

        public void bg_define_34x37x64()
            => nbg_define_check(n34, n37, z64);

        public void bg_define_35x35x64()
            => nbg_define_check(n35, n35, z64);

        public void bg_define_35x55x64()
            => nbg_define_check(n55, n55, z64);

        public void bg_define_35x55x8()
            => nbg_define_check(n55, n55, z8);

        public void bg_define_32x32x32()
        {
            var n = n32;
            var zero = 0u;
            var matrix = Random.BitMatrix(n);
            var grid = matrix.ToBitSpanBlocks256();
            for(byte row = 0; row < n; row++)
            for(byte col = 0; col < n; col++)
                Claim.eq(grid[row,col], matrix[row,col]);

            nbg_define_check(n,n,zero);
        }

        public void bg_define_64x64x64()
        {
            var n = n64;
            var zero = 0ul;
            var matrix = Random.BitMatrix(n);
            var grid = matrix.ToBitGrid();
            for(byte row = 0; row < n; row++)
            for(byte col = 0; col < n; col++)
                Claim.eq(grid[row,col], matrix[row,col]);

            nbg_define_check(n,n,zero);
        }

        public void nbg_define_basecase()
        {
            //dim: 128x128
            //512 32-bit integers

            //32 32 32 32   row[0]
            //32 32 32 32   row[1]
            // ....
            //32 32 32 32   row[127]

            // Linear index 0 ... 511
            // 0    1   2   3
            // 4    5   6   7
            // 8    9   10  11
            // ...
            // 496 497 498 499
            // 500 501 502 503
            // 504 505 506 507
            // 508 509 510 511

            var w = n512;
            var n = n128;
            var cpr = 4; //cells per row

            var grid = BitGrid.alloc(n128, n128, z32);
            Random.Fill(grid);

            var g128 = grid.Content.Reblock(n128);
            var g32 = grid.Content.Reblock(n32);
            Claim.eq(g32.BlockCount,w);

            ref var g32src = ref g32.First;

            var row124 = cpu.vload(n, g32.BlockLead(124*cpr));
            var row125 = cpu.vload(n, g32.BlockLead(125*cpr));
            var row126 = cpu.vload(n, g32.BlockLead(126*cpr));
            var row127 = cpu.vload(n, g32.BlockLead(127*cpr));

            var diagA = cpu.vgather(n, in g32src, cpu.vparts(n, 496, 501, 506, 511));
            var diagB = cpu.vparts(n, g32[496], g32[501], g32[506], g32[511]);
            Claim.veq(diagA,diagB);
        }

        void nbg_define_check<M,N,T>(M m = default, N n = default, T zero = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var rows = (int)nat64u(m);
            var cols = (int)nat64u(n);
            var points = rows*cols;
            var bytes = points/8 + (points % 8 != 0 ? 1 : 0);
            var bits = bytes*8;
            var segbytes = size<T>();
            var segments = bytes/segbytes + (bytes % segbytes != 0 ? 1 : 0);

            var grid = BitGrid.alloc(m,n,zero);

            for(var i=0; i< RepCount; i++)
            {
                var input = Random.BitString(grid.BitCount);
                for(var index=0u; index<input.Length; index++)
                    grid.SetBit(index, input[(int)index]);

                var output = grid.ToBitString();
                Claim.eq(input,output);
            }
        }
    }
}