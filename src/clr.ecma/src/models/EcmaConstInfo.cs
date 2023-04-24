//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct EcmaConstInfo
    {
        const string TableId = "ecma.const";

        [Render(8)]
        public uint Seq;

        [Render(32)]
        public EcmaToken Token;

        [Render(16)]
        public EcmaToken Parent;

        [Render(16)]
        public ConstantTypeCode DataType;

        [Render(1)]
        public BinaryCode Content;
    }
}