//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiHexIndexRow
    {
        const string TableId = "api-hex-index";

        [Render(10)]
        public uint Seqence;

        [Render(16)]
        public MemoryAddress Address;

        [Render(20)]
        public string Component;

        [Render(20)]
        public string HostName;

        [Render(20)]
        public string MethodName;

        [Render(120)]
        public OpUri Uri;
    }
}