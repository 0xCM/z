//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    /// <summary>
    /// Defines an allocation of a contiguous register sequence
    /// </summary>
    public readonly struct RegAlloc
    {
        readonly Index<BufferToken> Tokens;

        public uint Id {get;}

        public NativeSize RegSize {get;}

        public uint RegCount {get;}

        public MemoryAddress BaseAddress {get;}

        public RegSeqSpec Definition
        {
            [MethodImpl(Inline)]
            get => new RegSeqSpec(Id, RegCount, RegSize);
        }

        [MethodImpl(Inline)]
        public RegAlloc(RegSeqSpec spec, BufferToken[] tokens)
        {
            Id = spec.Id;
            Tokens = tokens;
            RegSize = spec.RegSize;
            RegCount = spec.RegCount;
            BaseAddress = core.first(tokens).Address;
        }

        /// <summary>
        /// Computes the address of an index-identified register
        /// </summary>
        /// <param name="index">The 0-based register index</param>
        [MethodImpl(Inline)]
        public MemoryAddress RegAddress(uint index)
            => BaseAddress + RegSize.ByteCount*index;

        public MemoryRange Range
        {
            [MethodImpl(Inline)]
            get => new MemoryRange(BaseAddress, RegCount*RegSize.ByteCount);
        }

        public MemoryAddress this[RegIndex index]
        {
            [MethodImpl(Inline)]
            get => RegAddress((byte)index);
        }
    }
}