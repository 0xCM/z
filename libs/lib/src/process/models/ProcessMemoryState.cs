//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public record struct ProcessMemoryState
    {
        public const string TableId = "image.state";

        /// <summary>
        /// The base address of the process
        /// </summary>
        [Render(16)]
        public MemoryAddress BaseAddress;

        /// <summary>
        /// The address of the entry point
        /// </summary>
        [Render(16)]
        public MemoryAddress EntryAddress;

        /// <summary>
        /// The number of bytes occupied by the module
        /// </summary>
        [Render(16)]
        public ByteSize MemorySize;

        /// <summary>
        /// The process name
        /// </summary>
        [Render(64)]
        public string ImageName;

        /// <summary>
        /// The minimum working set size
        /// </summary>
        [Render(16)]
        public ByteSize MinWorkingSet;

        /// <summary>
        /// The maximum working set size
        /// </summary>
        [Render(16)]
        public ByteSize MaxWorkingSet;

        /// <summary>
        /// The process identifier
        /// </summary>
        [Render(12)]
        public uint ProcessId;

        /// <summary>
        /// The process image version
        /// </summary>
        [Render(16)]
        public Version128 ImageVersion;

        /// <summary>
        /// The minimum working set size
        /// </summary>
        [Render(16)]
        public ByteSize VirtualSize;

        /// <summary>
        /// The maximum working set size
        /// </summary>
        [Render(16)]
        public ByteSize MaxVirtualSize;

        /// <summary>
        /// The cpu affinity provided by <see cref='Process.ProcessorAffinity'/>
        /// </summary>
        [Render(64)]
        public bits<ulong> Affinity;

        /// <summary>
        /// Captures the process start time
        /// </summary>
        [Render(16)]
        public Timestamp StartTime;

        /// <summary>
        /// Captures the value provided by <see cref='Process.TotalProcessorTime'/>
        /// </summary>
        [Render(16)]
        public Duration TotalRuntime;

        /// <summary>
        /// Captures the value provided by <see cref='Process.UserProcessorTime'/>
        /// </summary>
        [Render(16)]
        public Duration UserRuntime;

        /// <summary>
        /// The path of the process image
        /// </summary>
        [Render(1)]
        public FilePath ImagePath;
    }
}