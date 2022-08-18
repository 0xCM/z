//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    unsafe partial struct LoopModels
    {
        /// <summary>
        /// isl/test_inputs/codegen/gemm.c
        /// </summary>
        public static void gemm(in Limits3 n, ref Receiver2 S_2, ref Receiver3 S_4)
        {
            for(int c0 = 0; c0 < n.I; c0 += 1)
            for(int c1 = 0; c1 < n.J; c1 += 1)
            {
                S_2.Receive(c0, c1);
                for (int c2 = 0; c2<n.K; c2 += 1)
                    S_4.Receive(c0, c1, c2);
            }
        }

        public static void gemm(in Limits3 n, int* pDst00, int* pDst01,  int* pDst10, int* pDst11, int* pDst13)
        {
            var S_2 = LoopReceivers.create(pDst00, pDst01);
            var S_4 = LoopReceivers.create(pDst10, pDst11, pDst13);
            gemm(n, ref S_2, ref S_4);
        }

        public static void gemm(in Limits3 n, Span<int> dst00, Span<int> dst01, Span<int> dst10, Span<int> dst11, Span<int> dst12)
        {
            var S_2 = LoopReceivers.create(pfirst(dst00), pfirst(dst01));
            var S_4 = LoopReceivers.create(pfirst(dst10), pfirst(dst11), pfirst(dst12));
            gemm(n, ref S_2, ref S_4);
        }
    }
}