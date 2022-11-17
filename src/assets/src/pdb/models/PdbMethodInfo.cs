//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct PdbMethodInfo
    {
        public EcmaToken Token;

        public Index<PdbSeqPoint> SequencePoints;

        public Index<PdbDocument> Documents;
    }
}