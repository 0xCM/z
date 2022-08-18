//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct StackState
    {
        public uint Count;

        public uint Index;

        public uint Capacity;

        public ulong Current;

        [MethodImpl(Inline)]
        public StackState(uint capacity)
        {
            Count = 0;
            Index = 0;
            Capacity = capacity;
            Current = 0;
        }

        public string Format()
            => string.Format("{0:x8} {1:x8} {2:x8}:{3:x16}", Count, Index, Capacity, Current);

        public override string ToString()
            => Format();
    }
}