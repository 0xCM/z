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
        /// isl/test_inputs/codegen/isolate5.c
        /// </summary>
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
    }
}