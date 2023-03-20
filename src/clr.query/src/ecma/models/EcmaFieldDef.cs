//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct EcmaFieldDef
    {
        public const string TableId = "ecma.fields.defs.info";

        [Render(12)]
        public EcmaToken Token;

        [Render(48)]
        public string Name;

        [Render(32)]
        public EcmaSig CliSig;

        [Render(64)]
        public string Component;

        [Render(1)]
        public FieldAttributes Attributes;
    }
}