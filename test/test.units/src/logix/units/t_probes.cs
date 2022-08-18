//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    public class t_probes : UnitTest<t_probes>
    {
        public void probe_select()
        {
            var a = BitVectors.load(n8,0b10101010);
            var b = BitVectors.load(n8,0b10101010);
            var c = BitVectors.load(n8,0b01010101);
            var d = BitVectors.load(n8,0b11111111);
            var z = BitVectors.select(a,b,c);
            Claim.eq(z,d);
        }
    }
}