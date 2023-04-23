//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct EcmaHandleRow
    {
        const string TableId = "ecma.handles";

        public EcmaToken Token;

        public ClrArtifactKind Kind;

        public MemoryAddress Address;
    }
}