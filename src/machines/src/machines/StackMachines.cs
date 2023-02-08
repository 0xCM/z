//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StackMachines
    {
        [MethodImpl(Inline)]
        public static StackMachine create(uint capacity)
            => new StackMachine(capacity);
    }
}