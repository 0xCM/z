//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_full_adder : UnitTest<t_full_adder>
    {
        bit on => bit.On;

        bit off => bit.Off;

        public void fulladder_logical()
        {
            FullAdder.Compute(off, off, off, out bit s0, out bit c0);
            Claim.eq(s0, off);
            Claim.eq(c0, off);

            FullAdder.Compute(on, off, off, out bit s1, out bit c1);
            Claim.eq(s1, on);
            Claim.eq(c1, off);

            FullAdder.Compute(on, on, off, out bit s2, out bit c2);
            Claim.eq(s2, off);
            Claim.eq(c2, on);

            FullAdder.Compute(on, on, on, out bit s3, out bit c3);
            Claim.eq(s3, on);
            Claim.eq(c3, on);

            FullAdder.Compute(off, off, on, out bit s4, out bit c4);
            Claim.eq(s4, on);
            Claim.eq(c4, off);
        }

        public void vfulladder_256x64u()
        {
            var x = Random.CpuVector<ulong>(n256);
            var y = Random.CpuVector<ulong>(n256);
            var cin = Random.CpuVector<ulong>(n256);
            (var sum, var cout) = FullAdder.Compute(x,y, cin);

            var sumbs = sum.ToBitString();
            var coutbs = cout.ToBitString();
            var xbs = x.ToBitString();
            var ybs = y.ToBitString();
            var cinbs = cin.ToBitString();
            for(var i=0; i<xbs.Length; i++)
            {
                var expect = FullAdder.Compute(xbs[i],ybs[i],cinbs[i]);
                Claim.eq(expect.A, sumbs[i]);
                Claim.eq(expect.B, coutbs[i]);
            }
        }

        public void bvfulladder_32x32x64()
        {
            var x = Random.BitVector(n32);
            var y = Random.BitVector(n32);
            var cin = BitVector32.Zero;

            var v64 = FullAdder.Compute(x,y,cin);
            var sum = v64.Lo;
            var cout = v64.Hi;
            for(var i=0; i<sum.Width; i++)
            {
                var expect = FullAdder.Compute(x[i], y[i], cin[i]);
                Claim.eq(expect.A, sum[i]);
                Claim.eq(expect.B, cout[i]);
            }
        }
    }
}