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
        /// Receives 3-D loop variables
        /// </summary>
        public unsafe struct Receiver3
        {
            readonly int* Dst0;

            readonly int* Dst1;

            readonly int* Dst2;

            int I;

            [MethodImpl(Inline)]
            public Receiver3(int* pDst0, int* pDst1, int* pDst2)
            {
                Dst0 = pDst0;
                Dst1 = pDst1;
                Dst2 = pDst2;
                I = 0;
            }

            [MethodImpl(Inline)]
            public void Receive(int c0, int c1, int c2)
            {
                Dst0[I] = c0;
                Dst1[I] = c1;
                Dst2[I] = c2;
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