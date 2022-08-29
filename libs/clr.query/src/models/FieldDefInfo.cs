//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct FieldDefInfo
    {
        public const string TableId = "fields.defs";

        [Render(12)]
        public CliToken Token;

        [Render(48)]
        public string Name;

        [Render(32)]
        public CliSig CliSig;

        [Render(64)]
        public string Component;

        [Render(1)]
        public FieldAttributes Attributes;
    }
}