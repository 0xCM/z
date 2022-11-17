//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial struct Msg
    {
        const NumericKind Closure = Root.UnsignedInts;

        public static MsgPattern<_FileUri> CreatingPdbReader => "Creating pdb reader for {0}";

        public static MsgPattern<_FileUri> CreatedPdbReader => "Created pdb reader for {0}";

        public static MsgPattern<string> ReadingPdb => "Reading {0} pdb";

        public static MsgPattern<string> PdbNotFound => "Pdb for {0} not found";

        public static MsgPattern<Count> IndexingPdbFiles => "Indexing component pdb files from {0} components";

        public static MsgPattern<Count> IndexedPdbMethods => "Indexed {0} pdb methods";

    }
}