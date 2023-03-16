//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BinaryStreams
    {
        unsafe sealed class FileStream : IBinaryStream
        {
            readonly MemoryFile File;
            
            public MemoryAddress BaseAddress {get;}

            MemoryAddress Position;

            public MemoryAddress LastAddress {get;}

            public FileStream(FilePath src)
            {
                File = MemoryFiles.map(src);
                BaseAddress = File.BaseAddress;
                LastAddress = File.EndAddress;
                Position = File.BaseAddress;
            }

            public uint Length
            {
                [MethodImpl(Inline)]
                get => File.FileSize;
            }

            [MethodImpl(Inline)]
            public bool Next(out byte value)
            {
                if(Position++ <= LastAddress)
                {
                    value = *Position.Pointer<byte>();
                    return true;
                }
                else
                {
                    value = 0;
                    return false;
                }
            }

            public void Dispose()
            {
                File.Dispose();
            }
        }

    }
}