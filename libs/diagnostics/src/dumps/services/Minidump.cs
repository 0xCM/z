//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MinidumpRecords;

    public sealed partial class Minidump : IDisposable
    {
        public static Minidump open(FilePath src)
            => new Minidump(src);

        readonly MemoryFile Source;

        Minidump(FilePath src)
        {
            Source = MemoryFiles.map(src);
        }

        public ref readonly DumpFileHeader Header
        {
            [MethodImpl(Inline)]
            get => ref Source.First<DumpFileHeader>();
        }

        public void Dispose()
        {
            Source.Dispose();
        }
    }
}