//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct StringResRow
    {
        public const string TableId = "stringres";

        public EcmaToken Id;

        public StringAddress Address;

        public uint Length;
    }
}