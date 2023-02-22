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
            var a = ScalarBits.load(n8,0b10101010);
            var b = ScalarBits.load(n8,0b10101010);
            var c = ScalarBits.load(n8,0b01010101);
            var d = ScalarBits.load(n8,0b11111111);
            var z = ScalarBits.select(a,b,c);
            Claim.eq(z,d);
        }
    }
}