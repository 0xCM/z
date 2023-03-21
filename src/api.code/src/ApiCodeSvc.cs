//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class ApiCodeSvc : AppService<ApiCodeSvc>
    {
        public ReadOnlySeq<ApiHexIndexRow> EmitHexIndex(SortedIndex<ApiCodeBlock> src, IDbArchive dst)
            => EmitIndex(SortedSpans.define(src.Storage), dst.Targets().Path("api.index", FileKind.Csv));

        public Index<ApiCodeRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<MemberCodeBlock> src, IApiPack dst)
            => EmitApiCode(uri, src, dst.HexExtractPath(uri));

        public ConstLookup<FilePath,MemoryBlocks> LoadMemoryBlocks(Files src)
        {
            var flow = Channel.Running(string.Format("Loading {0} packs", src.Length));
            var lookup = new Lookup<FilePath,MemoryBlocks>();
            var errors = new Lookup<FilePath,Outcome>();
            iter(src, path => lookup.Include(path, ApiCode.memory(path)), true);
            var result = lookup.Seal();
            var count = result.EntryCount;
            var entries = result.Entries;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var path = entry.Key;
                var blocks = entry.Value.View;
                var blockCount = (uint)blocks.Length;
                var host = path.FileName.Format().Remove(".extracts.parsed.xpack").Replace(".","/");
                Channel.Write(string.Format("Loaded {0} blocks from {1}", blockCount, path.ToUri()));
                counter += blockCount;
            }

            Channel.Ran(flow, string.Format("Loaded {0} total blocks", counter));

            return result;
        }

        [Op]
        public Index<ApiCodeRow> EmitApiCode(ApiHostUri uri, ReadOnlySpan<MemberCodeBlock> src, FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiCodeRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = ApiCode.apicode(skip(src, i), i);

                Channel.TableEmit(buffer, dst);
                return buffer;
            }
            else
                return array<ApiCodeRow>();
        }

        public ReadOnlySeq<ApiEncoded> Collect(IPart part, ICompositeDispenser symbols, IApiPack dst)
        {
            var collected = ApiCode.collect(symbols, part, Channel);
            Emit(part.Name, collected, dst);
            return collected;
        }

        public ReadOnlySeq<EncodedMember> Emit(PartName part, ReadOnlySeq<ApiEncoded> src, IApiPack dst)
            => Emit(src, dst.HexExtractPath(part), dst.CsvExtractPath(part));

        public void Emit(ReadOnlySpan<CollectedHost> src, IDbArchive dst, bool pll)
            => iter(src, code => EmitHex(code, dst), pll);

        void EmitHex(CollectedHost src, IDbArchive dst)
        {
            var extracts = dst.Scoped("extracts");
            var path = extracts.Path(ApiFiles.file(src.Host, FileKind.HexDat));
            EmitHex(src.Blocks, path);
        }

        ByteSize EmitHex(ReadOnlySeq<ApiEncoded> src, FilePath dst)
        {
            var count = src.Count;
            var emitting = Channel.EmittingFile(dst);
            var size = ApiCode.hexdat(src, dst);
            Channel.EmittedFile(emitting,count);
            return size;
        }

        ReadOnlySeq<EncodedMember> Emit(ReadOnlySeq<ApiEncoded> src, FilePath hex, FilePath csv)
        {
            var collected = src;
            var count = collected.Count;
            var emitting = Channel.EmittingFile(hex);
            var size = ApiCode.hexdat(collected, hex);
            Channel.EmittedFile(emitting,count);
            var encoded = alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
                seek(encoded,i) = ApiCode.member(collected[i]);
            var rebase = min(encoded.Select(x => (ulong)x.EntryAddress).Min(), encoded.Select(x => (ulong)x.TargetAddress).Min());
            for(var i=0; i<count; i++)
            {
                seek(encoded,i).EntryRebase = skip(encoded,i).EntryAddress - rebase;
                seek(encoded,i).TargetRebase = skip(encoded,i).TargetAddress - rebase;
            }

            Channel.TableEmit(encoded, csv);
            return encoded;
        }

        [Op]
        ReadOnlySeq<ApiHexIndexRow> EmitIndex(SortedReadOnlySpan<ApiCodeBlock> src, FilePath dst)
        {
            var flow = Channel.EmittingTable<ApiHexIndexRow>(dst);
            var blocks = src.View;
            var count = blocks.Length;
            var buffer = alloc<ApiHexIndexRow>(count);
            var target = span(buffer);
            var parts = PartNames.names();
            using var writer = dst.Utf8Writer();
            var formatter = CsvTables.formatter<ApiHexIndexRow>();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                ref var record = ref seek(target, i);
                record.Seqence = i;
                record.Address = block.BaseAddress;
                parts.TryGetValue(block.OpUri.Part, out var name);
                record.Component = name.IsEmpty ? block.OpUri.Part.Format() : name.Format();
                record.HostName = block.OpUri.Host.HostName;
                record.MethodName = block.OpId.Name;
                record.Uri = block.OpUri;
                writer.WriteLine(formatter.Format(record));
            }

            Channel.EmittedTable(flow, count);
            return buffer;
        }
    }
}