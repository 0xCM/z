//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static sys;

    [ApiHost]
    public sealed class MemoryEmitter : AppService<MemoryEmitter>
    {
        const byte Bpl = 40;

        public static void emit(MemoryRange src, StreamWriter dst, byte bpl)
            => HexDataFormatter.create(src.Min, bpl).FormatLines(cover<byte>(src.Min, src.ByteCount), line => dst.WriteLine(line));

        public static void emit(MemoryRange src, FilePath dst, byte bpl)
        {
            using var writer = dst.Writer();
            emit(src, writer, bpl);
        }

        public static void emit(MemoryAddress @base, ByteSize size, FilePath dst, byte bpl = Bpl)
            => emit((@base,  @base + size), dst, bpl);

        [Op]
        public unsafe static uint emit2(MemorySeg src, FilePath dst)
        {
            var line = text.emitter();
            using var writer = dst.Writer();
            var pSrc = src.BaseAddress.Pointer<ulong>();
            var last =  src.LastAddress.Pointer<ulong>();
            var current = MemoryAddress.Zero;
            var offset = 1;
            var restart = true;
            var bpl = 64;
            var i = 0u;
            Span<char> buffer = alloc<char>(Pow2.T11);
            while(pSrc++ <= last)
            {
                current = (MemoryAddress)pSrc;

                if(restart)
                {
                    seek(buffer,i++) = Chars.D0;
                    seek(buffer,i++) = Chars.x;
                    HexRender.render(LowerCase, (Hex64)current, ref i, buffer);
                    seek(buffer,i++) = Chars.Space;
                    restart = false;
                }

                i += HexRender.hexchars(*pSrc, LowerCase, ref i, buffer);
                seek(buffer, i++) = Chars.Space;

                if(offset % bpl == 0)
                {
                    writer.WriteLine(text.format(slice(buffer,0, i)));
                    buffer.Clear();
                    restart = true;
                    i = 0;
                }

                offset++;
            }
            writer.WriteLine(line.Emit());
            return (uint)offset;
        }

        [Op]
        public unsafe static uint emit(MemorySeg src, uint bpl, FilePath dst)
        {
            var line = text.emitter();
            using var writer = dst.Writer();
            var pSrc = src.BaseAddress.Pointer<byte>();
            var last =  src.LastAddress.Pointer<byte>();
            var current = MemoryAddress.Zero;
            var offset = 1;
            var restart = true;

            while(pSrc++ <= last)
            {
                current = (MemoryAddress)pSrc;

                if(restart)
                {
                    line.Append(string.Format("0x{0} ", current.Format()));
                    restart = false;
                }

                line.Append(string.Format("{0} ", HexFormatter.format<W8,byte>(*pSrc)));

                if(offset % bpl == 0)
                {
                    writer.WriteLine(line.Emit());
                    restart = true;
                }

                offset++;
            }
            writer.WriteLine(line.Emit());
            return (uint)offset;
        }

        public void DumpImages(FolderPath src, FolderPath dst, bool pll = true)
            => iter(src.Files(FS.Dll), file => DumpImage(file,dst), pll);

        public void DumpImage(FilePath src, FolderPath dst)
        {
            using var file = MemoryFiles.map(src);
            var target = dst + FS.file(file.Path.FileName.Name, FS.Hex);
            var flow = Wf.EmittingFile(target);
            emit(file.BaseAddress, file.FileSize, target);
            EmittedFile(flow, (uint)file.FileSize);
        }

        public static unsafe void EmitPaged(MemoryRange src, StreamWriter dst, byte bpl = Bpl)
        {
            memory.liberate(src);
            var buffer = span<byte>(PageSize);
            var pages = (uint)(src.ByteCount/PageSize);
            var reader = MemoryReader.create<byte>(src);
            var offset = 0ul;
            var @base = src.Min;
            var formatter = HexDataFormatter.create(src.Min, bpl);
            dst.WriteLine(text.concat($"Address".PadRight(12), RpOps.SpacedPipe, "Data"));
            for(var i=0; i<pages; i++)
            {
                var size = reader.Read((int)offset, PageSize, buffer);
                var content = slice(buffer, size);
                var lines = formatter.FormatLines(content);
                var kLines = lines.Length;
                for(var j =0; j<kLines; j++)
                    dst.WriteLine(skip(lines,j));

                offset += PageSize;

                if(size < PageSize || offset >= src.ByteCount)
                    break;
            }
        }

        public static void EmitPaged(MemoryRange src, FilePath dst, byte bpl = Bpl)
        {
            using var writer = dst.Writer();
            EmitPaged(src, writer, bpl);
        }

        public static void EmitPaged(MemoryAddress @base, ByteSize size, FilePath dst, byte bpl = Bpl)
            => EmitPaged((@base,  @base + size), dst, bpl);
    }
}