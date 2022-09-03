//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DynamicAction
    {
        /// <summary>
        /// The operation identity
        /// </summary>
        public Identifier Id {get;}

        public MemoryAddress SourceAddress {get;}

        public DynamicMethod Enclosure {get;}

        public Action Operation {get;}

        [MethodImpl(Inline)]
        public DynamicAction(Identifier id, MemoryAddress src, DynamicMethod enclosure, Action op)
        {
            Id = id;
            SourceAddress = src;
            Enclosure = enclosure;
            Operation = op;
        }

        [MethodImpl(Inline)]
        public void Invoke()
            => Operation.Invoke();

        [MethodImpl(Inline)]
        public static implicit operator Delegate(DynamicAction src)
            => src.Operation;
    }
}