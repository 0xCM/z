//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public record struct PeFieldOffset
    {
        public const string TableId = "image.offsets";

        public string Name;

        public ulong Value;
    }
}