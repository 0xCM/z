//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = DataLayouts;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DataLayout : IDataLayout
    {
        public LayoutIdentity Id {get;}

        readonly Index<LayoutPart> Data;

        [MethodImpl(Inline)]
        public DataLayout(LayoutIdentity id, LayoutPart[] parts)
        {
            Id = id;
            Data = parts;
        }

        public uint Index
        {
            [MethodImpl(Inline)]
            get => Id.Pos;
        }

        public uint PartitionCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<LayoutPart> Partitions
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref LayoutPart FirstPartition
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref LayoutPart this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => api.width(Partitions);
        }

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}