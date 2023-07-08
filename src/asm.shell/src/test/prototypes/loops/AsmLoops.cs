//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [ApiHost]
    public unsafe readonly partial struct AsmLoops
    {
        /// <summary>
        /// isl/test_inputs/codegen/isolate5.c
        /// </summary>
        [Op]
        public static void isolate5(ref Receiver2 A, ref Receiver2 B)
        {
            for (int c0 = 0; c0 <= 9; c0 += 1)
            {
                if ((c0 + 1) % 2 == 0)
                {
                    for (int c1 = 0; c1 <= 1; c1 += 1)
                        B.Receive((c0 - 1) / 2, c1);
                }
                else
                {
                    for (int c1 = 0; c1 <= 1; c1 += 1)
                        A.Receive(c0 / 2, c1);
                }
            }
            for (int c0 = 10; c0 <= 89; c0 += 1)
            {
                if ((c0 + 1) % 2 == 0)
                {
                    for (int c1 = 0; c1 <= 1; c1 += 1)
                        B.Receive((c0 - 1) / 2, c1);
                }
                else
                {
                    for (int c1 = 0; c1 <= 1; c1 += 1)
                        A.Receive(c0 / 2, c1);
                }
            }
            for (int c0 = 90; c0 <= 199; c0 += 1)
            {
                if ((c0 + 1) % 2 == 0)
                {
                    for (int c1 = 0; c1 <= 1; c1 += 1)
                        B.Receive((c0 - 1) / 2, c1);
                }
                else
                {
                    for (int c1 = 0; c1 <= 1; c1 += 1)
                        A.Receive(c0 / 2, c1);
                }
            }
        }        
        /// <summary>
        /// isl/test_inputs/codegen/gemm.c
        /// </summary>
        public static void gemm(in AsmLoopLimits n, ref Receiver2 S_2, ref Receiver3 S_4)
        {
            for(int c0 = 0; c0 < n.I; c0 += 1)
            for(int c1 = 0; c1 < n.J; c1 += 1)
            {
                S_2.Receive(c0, c1);
                for (int c2 = 0; c2<n.K; c2 += 1)
                    S_4.Receive(c0, c1, c2);
            }
        }

        public static void gemm(in AsmLoopLimits n, int* pDst00, int* pDst01,  int* pDst10, int* pDst11, int* pDst13)
        {
            var S_2 = LoopReceivers.r2(pDst00, pDst01);
            var S_4 = LoopReceivers.r3(pDst10, pDst11, pDst13);
            gemm(n, ref S_2, ref S_4);
        }

        public static void gemm(in AsmLoopLimits n, Span<int> dst00, Span<int> dst01, Span<int> dst10, Span<int> dst11, Span<int> dst12)
        {
            var S_2 = LoopReceivers.r2(pfirst(dst00), pfirst(dst01));
            var S_4 = LoopReceivers.r3(pfirst(dst10), pfirst(dst11), pfirst(dst12));
            gemm(n, ref S_2, ref S_4);
        }


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

        /// <summary>
        /// isl/test_inputs/codegen/omega/basics-0.c
        /// </summary>
        /// <param name="s0"></param>
        [Op]
        public static void basics_0(ref Receiver1 s0)
        {
            for (int c0 = 5; c0 <= 8; c0 += 1)
                s0.Receive(c0);
            for (int c0 = 10; c0 <= 16; c0 += 2)
                s0.Receive(c0);
            for (int c0 = 20; c0 <= 25; c0 += 1)
                s0.Receive(c0);
        }

        [Op]
        public static int basics_0(int* pDst0)
        {
            var receiver = LoopReceivers.r1(pDst0);
            basics_0(ref receiver);
            return receiver.ReceiptCount;
        }

        [Op]
        public static void atomic(ref Receiver1 a, ref Receiver1 b)
        {
            for (int c0 = 0; c0 <= 10; c0 += 1)
            {
                if(c0 <= 9)
                    a.Receive(c0);
                if(c0 >= 1)
                    b.Receive(c0 - 1);
            }
        }

        [Op]
        public static void loop1(Action<uint> f)
        {
            for(var i=0u; i<0xFF; i++)
                f(i);
        }

        [Op]
        public static void loop2(Action<uint,uint> f)
        {
            for(var i=0u; i<0xFF; i++)
                for(var j=0u; j<0xFF; j++)
                    f(i,j);
        }

        [Op]
        public static void loop3(Action<uint,uint,uint> f)
        {
            for(var c0=0u; c0<0xFF; c0++)
                for(var c1=0u; c1<0xFF; c1++)
                    for(var c2=0u; c2<0xFF; c2++)
                        f(c0,c1,c2);
        }

        [Op]
        public static void loop4(Action<uint,uint,uint,uint> f)
        {
            for(var c0=0u; c0<0xFF; c0++)
                for(var c1=0u; c1<0xFF; c1++)
                    for(var c2=0u; c2<0xFF; c2++)
                        for(var c3=0u; c3<0xFF; c3++)
                            f(c0,c1,c2,c3);
        }

        [Op]
        public static void loop5(uint a0, uint a1, uint a2, uint a3, Action<uint,uint,uint,uint> f)
        {
            for(var c0=0u; c0<a0; c0++)
                for(var c1=0u; c1<a1; c1++)
                    for(var c2=0u; c2<a2; c2++)
                        for(var c3=0u; c3<a3; c3++)
                            f(c0,c1,c2,c3);
        }

        [Op]
        public static void loop6(ulong a0, ulong a1, ulong a2, ulong a3, Action<ulong,ulong,ulong,ulong> f)
        {
            for(var c0=0ul; c0<a0; c0++)
                for(var c1=0ul; c1<a1; c1++)
                    for(var c2=0ul; c2<a2; c2++)
                        for(var c3=0ul; c3<a3; c3++)
                            f(c0,c1,c2,c3);
        }

        [Op]
        public static void loop5x64u_f(ulong a0, ulong a1, ulong a2, ulong a3,ulong a4, Action<ulong,ulong,ulong,ulong,ulong> f)
        {
            for(var c0=0ul; c0<a0; c0++)
            for(var c1=0ul; c1<a1; c1++)
            for(var c2=0ul; c2<a2; c2++)
            for(var c3=0ul; c3<a3; c3++)
            for(var c4=0ul; c4<a4; c4++)
                f(c0,c1,c2,c3,c4);
        }


        [Op]
        public static void loop7(ulong a0, ulong a1, ulong a2, ulong a3, Func<ulong,ulong,ulong,ulong,ulong> f, Action<ulong> g)
        {
            for(var c0=0ul; c0<a0; c0++)
                for(var c1=0ul; c1<a1; c1++)
                    for(var c2=0ul; c2<a2; c2++)
                        for(var c3=0ul; c3<a3; c3++)
                            g(f(c0,c1,c2,c3));
        }

        [Op]
        public static void loop8(byte a0, byte a1, byte a2, byte a3, Func<byte,byte,byte,byte,byte> f, Action<byte, byte, byte, byte, byte> g)
        {
            for(var c0=z8; c0<a0; c0++)
                for(var c1=z8; c1<a1; c1++)
                    for(var c2=z8; c2<a2; c2++)
                        for(var c3=z8; c3<a3; c3++)
                            g(c0, c1, c2, c3, f(c0,c1,c2,c3));
        }

        [Op]
        public static void loop9(Pair<uint> limits, Func<uint,uint> f, Action<uint> g)
        {
            for(var i=limits.Left; i<limits.Right; i++)
                g(f(i));
        }
    }
}