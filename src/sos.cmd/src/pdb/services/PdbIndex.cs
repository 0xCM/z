//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class PdbIndex
    {
        readonly PdbDocuments Data;

        public PdbIndex()
        {
            Data = new();
        }

        public uint Include(ReadOnlySpan<PdbDocument> src)
            => Data.Include(src);

        public ICollection<PdbDocument> Documents
            => Data.Documents;
    }
}