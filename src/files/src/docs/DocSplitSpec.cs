//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct DocSplitSpec
    {
        public const string TableId = "splits";

        public const byte FieldCount = 4;

        public string DocId;

        public string Unit;

        public uint FirstLine;

        public uint LastLine;
    }
}