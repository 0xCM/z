//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Partitions T-cell sequences predicated on a supplied delimiter
    /// </summary>
    public struct SeqSplitter<T>
        where T : unmanaged
    {
        public readonly T Delimiter;

        public bool Collecting;

        public uint CellPos;

        public uint SegPos;

        public uint I0;

        public uint I1;

        public uint LastPos;

        public uint InputCount;

        [MethodImpl(Inline)]
        public SeqSplitter(T delimiter)
        {
            Delimiter = delimiter;
            Collecting = true;
            CellPos = 0;
            SegPos = 0;
            I0 = 0;
            I1 = 0;
            LastPos = 0;
            InputCount = 0;
        }

        [MethodImpl(Inline)]
        public uint NextSeg()
            => ++SegPos;

        [MethodImpl(Inline)]
        public uint NextPoint()
            => ++I1;

        [MethodImpl(Inline)]
        public uint NextCell()
            => ++CellPos;

        [MethodImpl(Inline)]
        public readonly Pair<uint> MarkSegment()
            => new Pair<uint>(I0, I1);

        [MethodImpl(Inline)]
        public readonly bool OnLastPos()
            => CellPos == LastPos;

        [MethodImpl(Inline)]
        public readonly bool IsDelimiter(T candidate)
            => candidate.Equals(Delimiter);

        [MethodImpl(Inline)]
        public readonly bool Unfinished()
            => CellPos < InputCount;
    }
}