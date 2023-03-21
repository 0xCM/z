//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitImageContent(IApiPack dst)
        {
            var flow = Running();
            iter(ApiAssemblies.Components, c => EmitImageContent(c, dst), PllExec);
            Ran(flow);
        }

        [Op]
        public MemoryRange EmitImageContent(Assembly src, IApiPack dst, byte bpl = HexCsvRow.BPL)
        {
            var path =  dst.Metadata("image.content").PrefixedTable<HexCsvRow>(src.GetSimpleName());
            var flow = EmittingTable<HexCsvRow>(path);
            var @base = ImageMemory.@base(src);
            var formatter = HexDataFormatter.create(@base, bpl);
            using var stream = FS.path(src.Location).Utf8Reader();
            using var reader = stream.BinaryReader();
            using var writer = path.Writer();
            writer.WriteLine(string.Concat($"Address".PadRight(16), RP.SpacedPipe, "Data"));
            var buffer = sys.alloc<byte>(bpl);
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

            EmittedTable(flow, lines);
            return (@base, @base + offset);
        }

        [MethodImpl(Inline), Op]
        uint Read(BinaryReader src, Span<byte> dst)
            => (uint)src.Read(dst);
    }
}