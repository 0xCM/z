//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential)]
public record struct ProcessContext
{
    public int ProcessId;

    public string ProcessName;

    public string Subject;

    public Timestamp Timestamp;

    public ReadOnlySeq<ProcessPartition> Partitions;

    public @string PartitionPath;

    public ReadOnlySeq<ProcessMemoryRegion> Regions;

    public @string RegionPath;

    public @string DumpPath;
}
