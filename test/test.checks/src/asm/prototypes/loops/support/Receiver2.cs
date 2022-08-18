//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    unsafe partial struct LoopModels
    {
        /// <summary>
        /// Receives 2-D loop variables
        /// </summary>
        public unsafe struct Receiver2
        {
            readonly int* Dst0;

            readonly int* Dst1;

            int I;

            [MethodImpl(Inline)]
            public Receiver2(int* pDst0, int* pDst1)
            {
                Dst0 = pDst0;
                Dst1 = pDst1;
                I = 0;
            }

            [MethodImpl(Inline)]
            public void Receive(int c0, int c1)
            {
                Dst0[I] = c0;
                Dst1[I] = c1;
                I++;
            }

            public int ReceiptCount
            {
                [MethodImpl(Inline)]
                get => I;
            }
        }
    }
}