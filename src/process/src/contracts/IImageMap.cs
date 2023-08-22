//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IImageMap : IDisposable
{
    uint Index {get;}

    Hash128 ContentHash {get;}

    MemoryFile File {get;}

    ByteSize FileSize
        => File.FileSize;

    MemoryAddress BaseAddress 
        => File.BaseAddress;

    ReadOnlySpan<byte> Data
        => sys.cover<byte>(BaseAddress, FileSize);

    void IDisposable.Dispose()
        => File.Dispose();
}

public interface IImageMap<M,F> : IImageMap
    where F : IImageFile
    where M : IImageMap<M,F>
{
}
