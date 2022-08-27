//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Encloses a pointer to the native definition of a dynamic delegate
    /// </summary>
    public unsafe readonly struct DynamicPointer
    {
        readonly DynamicDelegate Op;

        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public DynamicPointer(DynamicDelegate op, MemoryAddress address)
        {
            Op = op;
            Address = address;
        }

        public Delegate Operation
            => Op.Operation;

        public MethodInfo Source
            => Op.Source;

        public MethodInfo Target
            => Op.Target;
    }
}