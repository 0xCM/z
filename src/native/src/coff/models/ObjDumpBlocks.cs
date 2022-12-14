//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ObjDumpBlocks
    {
        public readonly Index<ObjBlock> Blocks;

        public readonly Index<ObjDumpRow> Rows;

        public ObjDumpBlocks(ObjBlock[] blocks, ObjDumpRow[] rows)
        {
            Blocks = blocks;
            Rows = rows;
        }
    }
}