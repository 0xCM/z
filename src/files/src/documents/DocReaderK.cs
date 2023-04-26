//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static DocModels;

    public struct DocReader<K>
        where K : unmanaged, IEquatable<K>
    {
        readonly Doc<K> Doc;

        uint CellPos;

        uint TermPos;

        internal DocReader(Doc<K> doc)
        {
            Doc = doc;
            CellPos = 0;
            TermPos = 0;
        }

        [MethodImpl(Inline)]
        public uint Count(K match)
        {
            var counter = 0u;
            var cells = Doc.Cells;
            var count = cells.Length;
            for(var i=0; i<count; i++)
                if(skip(cells,i).Equals(match))
                    counter++;
            return counter;
        }

        [MethodImpl(Inline)]
        public bool ReadUntil(K match, out ReadOnlySpan<K> dst)
        {
            var cells = Doc.Cells;
            var count = cells.Length;
            if(CellPos < count)
            {
                var i0=CellPos;
                for(var j=CellPos; j<count; CellPos++)
                {
                    if(skip(cells,j).Equals(match))
                    {
                        dst = slice(cells,i0, j - i0);
                        return true;
                    }
                }
            }
            dst = default;
            return false;
        }
    }
}