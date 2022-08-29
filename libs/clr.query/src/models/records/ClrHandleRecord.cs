//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ClrHandleRecord
    {
        public const string TableId = "clr.handles";

        public CliToken Token;

        public ClrArtifactKind Kind;

        public MemoryAddress Address;
    }
}