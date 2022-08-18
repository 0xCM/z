//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmCodeMap
    {
        readonly Index<AsmCodeMapEntry> Data;

        public AsmCodeMap(AsmCodeMapEntry[] data)
        {
            Data = data;
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly AsmCodeMapEntry this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly AsmCodeMapEntry this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public ref readonly InstructionId Id(int index)
            => ref this[index].InstructionId;

        [MethodImpl(Inline)]
        public ref readonly Label Origin(int index)
            => ref this[index].OriginName;

        [MethodImpl(Inline)]
        public ref readonly MemoryAddress IP(int index)
            => ref this[index].IP;

        [MethodImpl(Inline)]
        public ref readonly byte Size(int index)
            => ref this[index].Size;

        [MethodImpl(Inline)]
        public ref readonly SourceText Asm(int index)
            => ref this[index].Asm;

        [MethodImpl(Inline)]
        public ref readonly HexRef Encoded(int index)
            => ref this[index].Encoded;

        [MethodImpl(Inline)]
        public ref readonly Label BlockName(int index)
            => ref this[index].BlockName;

        [MethodImpl(Inline)]
        public ref readonly MemoryAddress BlockAddress(int index)
            => ref this[index].BlockAddress;

        [MethodImpl(Inline)]
        public ref readonly ByteSize BlockSize(int index)
            => ref this[index].BlockSize;
    }
}