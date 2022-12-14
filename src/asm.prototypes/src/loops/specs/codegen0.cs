//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct AsmLoops
    {
        [Op]
        public static void code_gen_0(ref Receiver2 s0, ref Receiver2 s1)
        {
            for(int c0 = 1; c0 <= 8; c0 += 1)
            for(int c1 = 0; c1 <= 7; c1 += 1)
            {
                if(c0 >= 2 && c0 <= 6 && c1 <= 4)
                    s0.Receive(c0, c1);
                if(c1 + 1 >= c0)
                    s0.Receive(c0, c1);
            }
        }

        [Op]
        public static void code_gen_0(int* pDst00, int* pDst01, int* pDst10, int* pDst11)
        {
            var s0 = LoopReceivers.r2(pDst00, pDst01);
            var s1 = LoopReceivers.r2(pDst10, pDst11);
            code_gen_0(ref s0, ref s1);
        }
    }
}