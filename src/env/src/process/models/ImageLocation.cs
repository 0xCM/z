//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Describes a PE image from the perspective of process entry point
/// </summary>
[Record(TableId), StructLayout(LayoutKind.Sequential)]
public record struct ImageLocation : IComparable<ImageLocation>
{
    const string TableId = "image.located";

    /// <summary>
    /// The image part identifier, if any
    /// </summary>
    [Render(64)]
    public string ImageName;

    /// <summary>
    /// The image's memory base
    /// </summary>
    [Render(16)]
    public MemoryAddress BaseAddress;

    /// <summary>
    /// The process entry point
    /// </summary>
    [Render(16)]
    public MemoryAddress EntryAddress;

    /// <summary>
    /// The terminal address as determined by <see cref='BaseAddress'/> + <see cref='Size'/>
    /// </summary>
    [Render(16)]
    public MemoryAddress MaxAddress;

    /// <summary>
    /// The image size
    /// </summary>
    [Render(16)]
    public ByteSize Size;

    /// <summary>
    /// The image source path
    /// </summary>
    [Render(1)]
    public FileUri ImagePath;

    [MethodImpl(Inline)]
    public ImageLocation(string name, MemoryAddress entry, MemoryAddress @base, ByteSize size, FileUri path)
    {
        ImagePath = path;
        ImageName = name;
        EntryAddress = entry;
        BaseAddress = @base;
        Size = size;
        MaxAddress = BaseAddress + Size;
    }

    [MethodImpl(Inline)]
    public readonly int CompareTo(ImageLocation src)
        => BaseAddress.CompareTo(src.BaseAddress);
}
