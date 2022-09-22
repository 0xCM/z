//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExecutorContext
    {
        public readonly dynamic State;

        [MethodImpl(Inline)]
        public ExecutorContext(dynamic state)
            => State = state;
    }
}