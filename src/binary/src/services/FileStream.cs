//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    unsafe sealed class FileStream : IBinaryStream
    {
        readonly MemoryFile File;
        
        readonly MemoryAddress Min;

        readonly MemoryAddress Max;

        MemoryAddress Position;

        public FileStream(FilePath src)
        {
            File = MemoryFiles.map(src);
            Min = File.BaseAddress;
            Max = File.EndAddress;
            Position = File.BaseAddress;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Min;
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => File.FileSize;
        }

        [MethodImpl(Inline)]
        public bool Next(out byte value)
        {
            if(Position++ <= Max)
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