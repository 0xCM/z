//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct PdbReaderStats : IRecord<PdbReaderStats>
    {
        public FS.FilePath Assembly;

        public FS.FilePath Pdb;

        public uint SeqPointCount;

        public uint MethodCount;

        public uint DocCount;
    }
}