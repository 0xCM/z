//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ApiCorrelationEntry
    {
        public const string TableId = "api.correlations";

        public Seq16x2 Key;

        public MemoryAddress CaptureAddress;

        public MemoryAddress RuntimeAddress;

        public _OpUri Id;
    }
}