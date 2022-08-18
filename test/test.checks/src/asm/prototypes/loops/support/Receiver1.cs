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
        /// Receives 1-D loop variables
        /// </summary>
        public unsafe struct Receiver1
        {
            readonly int* Dst0;

            int I;

            [MethodImpl(Inline)]
            public Receiver1(int* pDst0)
            {
                Dst0 = pDst0;
                I = 0;
            }

            [MethodImpl(Inline)]
            public void Receive(int c0)
            {
                Dst0[I++] = c0;
            }

            public int ReceiptCount
            {
                [MethodImpl(Inline)]
                get => I;
            }
        }
    }
}