//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct PdbReaderStats : IRecord<PdbReaderStats>
    {
        public FilePath Assembly;

        public FilePath Pdb;

        public uint SeqPointCount;

        public uint MethodCount;

        public uint DocCount;
    }
}