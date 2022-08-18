//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct LoopModels
    {
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
    }
}