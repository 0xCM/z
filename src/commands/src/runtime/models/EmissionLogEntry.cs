//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct EmissionLogEntry
    {
        const string TableId = "emissions";

        [Render(64)]
        public ExecToken ExecToken;

        [Render(12)]
        public EmissionEventKind EventType;

        [Render(16)]
        public Count Quantity;

        [Render(24)]
        public FileExt FileType;

        [Render(1)]
        public FileUri Target;
    }

    public enum EmissionEventKind : byte
    {
        Emitting,

        Emitted,
    }
}