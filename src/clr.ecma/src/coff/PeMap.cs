//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PeMap : IDisposable
    {
        public static PeMap create(FilePath src)
            => new PeMap(MemoryFiles.map(src));

        readonly MemoryFile File;

        public PeMap(MemoryFile file)
        {
            File = file;
        }

        public MemoryAddress BaseAddress 
            => File.BaseAddress;
        
        public ByteSize Size
            => File.FileSize;

        [MethodImpl(Inline)]
        public MemorySeg Segment()
            => new MemorySeg(BaseAddress, Size);

        public PeMemory PeMemory()
            => PeFiles.pe(new MemorySeg(BaseAddress, Size));

        public void Dispose()
        {
            File.Dispose();
        }
    }
}