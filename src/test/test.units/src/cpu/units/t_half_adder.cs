//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bv_half_adder : UnitTest<t_bv_half_adder>
    {
        public void create()
        {
            var circuit = Gated.half<byte>();
            BitVector8 a = 0b11010110;
            BitVector8 b = 0b10101001;
            (BitVector8 s, BitVector8 c) = circuit.Invoke(a, b);
        }
    }
}