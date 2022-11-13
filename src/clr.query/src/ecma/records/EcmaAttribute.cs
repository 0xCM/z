//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct EcmaAttribute
    {
        const string TableId = "ecma.attributes";

        [Render(12)]
        public EcmaRowKey Parent;

        [Render(12)]
        public EcmaRowKey Constructor;

        [Render(12)]
        public EcmaBlobIndex Value;

        [Render(12)]
        public Address32 ValueOffset;
    }
}