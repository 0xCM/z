//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BfModel<T>
        where T : unmanaged
    {
        /// <summary>
        /// Specifies the source of the model definition
        /// </summary>
        public readonly BfOrigin Origin;

        /// <summary>
        /// The model name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The number of defined segments
        /// </summary>
        public readonly uint SegCount;

        /// <summary>
        /// The bitfield size
        /// </summary>
        public readonly DataSize Size;

        readonly Index<BfSegModel<T>> Data;

        [MethodImpl(Inline)]
        public BfModel(BfOrigin origin, string name, Index<BfSegModel<T>> segments, DataSize size)
        {
            Origin = origin;
            Name = name;
            SegCount = segments.Count;
            Data = segments;
            Size = size;
        }

        public ref BfSegModel<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public Span<BfSegModel<T>> Segments
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public uint Width(int index)
            => Seg(index).Width;

        [MethodImpl(Inline)]
        public uint Position(int index)
            => bw32(Seg(index).MinPos);

        [MethodImpl(Inline)]
        public ref BfSegModel<T> Seg(int index)
            => ref Data[index];
    }
}