//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        public static void hexify(IWfChannel channel, FilePath src, FilePath dst, byte bpl = HexCsvRow.BPL)
        {
            var emitting = channel.EmittingFile(dst);
            using var stream = src.Stream();
            using var reader = stream.BinaryReader();
            using var writer = dst.AsciWriter();
            var buffer = sys.alloc<byte>(bpl);
            var @base = MemoryAddress.Zero;
            var formatter = HexDataFormatter.create(@base, bpl);
            writer.WriteLine(string.Concat($"Address".PadRight(HexCsvRow.AddressWidth), RP.SpacedPipe, "Data"));
            var k = Read(reader, buffer);
            var offset = MemoryAddress.Zero;
            var lines = 0;
            while(k != 0)
            {
                writer.WriteLine(formatter.FormatLine(buffer, offset, Chars.Pipe));

                offset += k;
                lines++;

                buffer.Clear();
                k = Read(reader, buffer);
            }   
            channel.EmittedFile(emitting, $"Emitted {(ByteSize)offset} bytes to {dst}");
        }

        [MethodImpl(Inline), Op]
        static uint Read(BinaryReader src, Span<byte> dst)
            => (uint)src.Read(dst);

        public static void hexify(IWfChannel channel, IEnumerable<FilePath> src, FolderPath dst, byte bpl = HexCsvRow.BPL, bool pll = true)
            => iter(src, file => hexify(channel, file, dst + file.FileName.ChangeExtension(FileKind.Hex), bpl));
    }
}