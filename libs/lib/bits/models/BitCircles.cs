//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public struct BitCircles
    {
        [MethodImpl(Inline)]
        public static BitCircles create(ulong state)
            => new BitCircles(state);

        ulong State;

        [MethodImpl(Inline)]
        public BitCircles(ulong state)
            => State  = state;

        [MethodImpl(Inline)]
        public ulong Push(bit src)
        {
            State <<= 1;
            State |= (uint)src;
            return State;
        }

        [MethodImpl(Inline)]
        public bit Pop()
        {
            var val = (bit)(State & 1);
            State >>= 1;
            return val;
        }
    }
}