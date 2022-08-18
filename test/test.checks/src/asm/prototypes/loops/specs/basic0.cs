//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct LoopModels
    {
        /// <summary>
        /// isl/test_inputs/codegen/omega/basics-0.c
        /// </summary>
        /// <param name="s0"></param>
        public static void basics_0(ref Receiver1 s0)
        {
            for (int c0 = 5; c0 <= 8; c0 += 1)
                s0.Receive(c0);
            for (int c0 = 10; c0 <= 16; c0 += 2)
                s0.Receive(c0);
            for (int c0 = 20; c0 <= 25; c0 += 1)
                s0.Receive(c0);
        }

        public static int basics_0(int* pDst0)
        {
            var receiver = LoopReceivers.create(pDst0);
            basics_0(ref receiver);
            return receiver.ReceiptCount;
        }
    }
}