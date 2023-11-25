//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using Asm;

    public class ApiCodeRows
    {
        const byte ZeroLimit = 10;

        [Op]
        public static ApiMemberCode load(IWfChannel channel, IApiPack src, PartName part)
        {
            load(channel, src, part, out var seq, out var code);
            return members(Dispense.composite(), seq, code);
        }

        [Op]
        static void load(IWfChannel channel, IApiPack src, PartName part, out Seq<EncodedMember> index, out BinaryCode data)
        {
            index = member(channel, src, part);
            data = bincode(channel, src, part);
        }

        [Op]
        public static ApiMemberCode load(IWfChannel channel, IApiPack src, ICompositeDispenser symbols, ApiHostUri host)
        {
            load(channel, src, host, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static ApiMemberCode load(IWfChannel channel, IApiPack src, ICompositeDispenser symbols, PartName part)
        {
            load(channel, src, part, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static void load(IWfChannel channel,  IApiPack src, ApiHostUri host, out Seq<EncodedMember> index, out BinaryCode data)
        {
            AsmBytes.hexdat(src.HexExtractPath(host), out data).Require();
            parse(src.CsvExtractPath(host), out index).Require();
        }
        
        [Op]
        static Seq<EncodedMember> member(IWfChannel channel, IApiPack src, PartName part)
        {
            var dst = Seq<EncodedMember>.Empty;
            var result = parse(src.CsvExtractPath(part), out dst);
            if(result.Fail)
            {
                channel.Error(result.Message);
                sys.@throw($"{part.Format()} member load failure");
            }
            return dst;
        }

        [Op]
        static BinaryCode bincode(IWfChannel channel, IApiPack src, PartName part)
        {
            var dst = BinaryCode.Empty;
            var result = AsmBytes.hexdat(src.HexExtractPath(part), out dst);
            if(result.Fail)
            {
                channel.Error(result.Message);
                sys.@throw(result.Message);
            }
            return dst;
        }

        [Op]
        static ApiMemberCode members(ICompositeDispenser dispenser, Index<EncodedMember> src, BinaryCode code)
        {
            var dst = new ApiMemberCode.EncodingData();
            src.Sort(EncodedMember.comparer(EncodedMember.CmpKind.Target));
            var offset = 0u;
            var count = src.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref src[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > code.Length)
                    @throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

                seek(offsets,i) = offset;
                ApiIdentity.parse(info.Uri, out var uri).Require();
                var e = new MethodEntryPoint(info.EntryAddress, Require.notnull(uri), info.Sig);
                seek(tokens,i) = ApiCode.token(dispenser, e, info.TargetAddress);
                offset += size;
            }

            dst.Symbols = dispenser;
            dst.Members = src;
            dst.CodeBuffer = ManagedBuffer.pin(code.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return ApiMemberCode.own(dst);
        }
        [Op]
        public static ReadOnlySpan<ApiPartBlocks> parts(ReadOnlySpan<ApiHostBlocks> src)
            => src.ToArray().GroupBy(x => x.Part).Map(x => new ApiPartBlocks(x.Key, x.ToArray()));

        [Op]
        public static ReadOnlySpan<ApiHostBlocks> hosted(ReadOnlySpan<ApiCodeBlock> src)
            => hosted(src.ToArray());

        [Op]
        static ReadOnlySpan<ApiHostBlocks> hosted(Index<ApiCodeBlock> src)
        {
            if(src.IsEmpty)
                return array<ApiHostBlocks>();
            else
            {
                var keyed = src.Storage.Where(x => x.HostUri.IsNonEmpty).Select(x => (x.HostUri, x)).ToReadOnlySpan();
                var count = keyed.Length;
                var dst = dict<ApiHostUri,List<ApiCodeBlock>>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var code = ref skip(keyed,i);
                    if(dst.TryGetValue(code.HostUri, out var blocks))
                        blocks.Add(code.x);
                    else
                    {
                        var target = list<ApiCodeBlock>();
                        target.Add(code.x);
                        dst.Add(code.HostUri, target);
                    }
                }
                return dst.Map(x => new ApiHostBlocks(x.Key, x.Value.ToArray()));
            }
        }        

        public static void located(FilePath src, Receiver<HexCsvRow> dst)
        {
            var pos = 0u;
            using var reader = src.AsciReader();
            var size = src.Size;
            var record = HexCsvRow.Empty;
            var @continue = true;
            while(@continue)
                @continue = read(reader, ref pos, dst);
        }

        static bool read(StreamReader src, ref uint pos, Receiver<HexCsvRow> dst)
        {
            var line = src.ReadLine();
            if(line == null)
                return false;

            pos++;

            var parts = text.split(line, FieldDelimiter);
            if(parts.Length != 2)
                return false;

            AddressParser.parse(skip(parts,0), out MemoryAddress location);
            //Hex.code(skip(parts,1), out BinaryCode cde);

            return true;
        }
         
        /// <summary>
        /// Emits a line of hex data that specifies the encoding for each emember
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        [Op]
        public static ByteSize hexdat(ReadOnlySpan<ApiEncoded> src, FilePath dst)
        {
            var options = HexFormatOptions.define();
            using var writer = dst.AsciWriter();
            var size = 0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var code = ref sys.skip(src,i).Code;
                writer.WriteLine(code.Format(options));
                size += code.Size;
            }

            return size;
        }

        [MethodImpl(Inline), Op]
        public static ApiCodeBlock apiblock(ApiCodeRow src)
            => new (src.Address, src.Uri, src.Data);

        [Op]
        public static SortedIndex<ApiCodeBlock> apiblocks(IApiPack src, bool pll = true)
            => apicode(src.HexExtracts().Array(), pll);

        [MethodImpl(Inline), Op]
        public static ApiCodeRow apicode(in MemberCodeBlock src, uint seq)
        {
            var dst = ApiCodeRow.Empty;
            dst.Seq = seq;
            dst.SourceSeq = src.Sequence;
            dst.Address = src.Address;
            dst.CodeSize = src.Encoded.Size;
            dst.Uri = src.OpUri;
            dst.Data = src.Encoded;
            return dst;
        }

        [Op]
        public static SortedIndex<ApiCodeBlock> apicode(Files src, bool pll = true)
        {
            var dst = bag<ApiCodeBlock>();
            iter(src, file => iter(ApiCodeRows.apirows(file), row => dst.Add(apiblock(row))), pll);
            return SortedIndex<ApiCodeBlock>.sort(dst.Array());
        }

        public static Index<ApiCodeRow> apirows(FilePath src)
        {
            var result = Outcome.Success;
            var data = src.ReadLines().Storage.Skip(1);
            var count = data.Length;
            var dst = list<ApiCodeRow>();
            var j=0;
            for(var i=0; i<count; i++)
            {
                result = parse(skip(data,i), out ApiCodeRow row);
                if(result)
                {
                    dst.Add(row);
                    j++;
                }
                else
                    sys.@throw(result.Message);
            }
            return dst.Index();
        }

        static ConcurrentDictionary<ApiToken,ApiEncoded> parse(Dictionary<ApiHostUri,CollectedCodeExtracts> src, IWfChannel log)
        {
            var flow = log.Running(Msg.ParsingHosts.Format(src.Count));
            var buffer = sys.alloc<byte>(Pow2.T14);
            var parser = ApiCode.parser(buffer);
            var dst = new ConcurrentDictionary<ApiToken,ApiEncoded>();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                var running = log.Running(Msg.ParsingHostMembers.Format(host));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    if(!dst.TryAdd(extract.Token,new ApiEncoded(extract.Token, parser.Parsed)))
                        log.Warn($"Duplicate:{extract.Token}");
                    else
                        counter++;
                }
                log.Ran(running, Msg.ParsedHostMembers.Format(extracts.Count, host));
            }

            log.Ran(flow, Msg.ParsedHosts.Format(counter, src.Keys.Count));
            return dst;
        }

        static Outcome parse(FilePath src, out Seq<EncodedMember> dst)
        {
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            dst = alloc<EncodedMember>(count);
            for(var i=0u; i<count; i++)
            {
                result = parse(i + 1, lines[i + 1], out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        static Outcome parse(LineNumber line, string src, out EncodedMember dst)
        {
            const byte FieldCount = EncodedMember.FieldCount;
            dst = default;
            var cells = text.split(src, Chars.Pipe);
            var count = cells.Length;
            if(count != FieldCount)
                return (false,string.Format("\n{0,-12} \n{1}", line, text.trim(cells).Delimit('\n').Format()));

            var result = Outcome.Success;
            var i=0;
            result = HexParser.parse(skip(cells,i++), out dst.Id);
            result = DataParser.parse(skip(cells,i++), out dst.EntryAddress);
            result = DataParser.parse(skip(cells,i++), out dst.EntryRebase);
            result = DataParser.parse(skip(cells,i++), out dst.TargetAddress);
            result = DataParser.parse(skip(cells,i++), out dst.TargetRebase);
            result = DataParser.parse(skip(cells,i++), out dst.StubAsm);
            result = Disp.parse(skip(cells,i++), out dst.Disp);
            result = DataParser.parse(skip(cells,i++), out dst.CodeSize);
            dst.Host = text.trim(skip(cells,i++));
            dst.Sig = text.trim(skip(cells,i++));
            dst.Uri = text.trim(skip(cells,i++));
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out ApiCodeRow dst)
        {
            dst = new ApiCodeRow();
            var result = Outcome.Success;
            try
            {
                if(empty(src))
                    return (false, "No text!");

                var fields = src.SplitClean(FieldDelimiter);
                var count = fields.Length;
                if(count !=  (uint)ApiCodeRow.FieldCount)
                    return (false,Tables.FieldCountMismatch.Format(ApiCodeRow.FieldCount, count));

                var index = 0;
                result = DataParser.parse(fields[index++], out dst.Seq);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.SourceSeq);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Address);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.CodeSize);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));


                result = ApiIdentity.parse(fields[index++], out dst.Uri);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Data);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));
                return result;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public static MemoryBlocks memory(ReadOnlySpan<ApiCodeRow> src)
        {
            var count = src.Length;
            var dst = sys.alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = memory(skip(src,i));
            return dst;
        }

        [Op]
        public static MemoryBlocks memory(ReadOnlySpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            var dst = sys.alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                seek(dst,i) = new MemoryBlock(code.AddressRange, code.Encoded);
            }

            dst.Sort();
            return new MemoryBlocks(dst);
        }


        const char SegSep = Chars.Colon;

        static Fence<char> SegFence = ('[',']');

        static Fence<char> DataFence = ('<', '>');

        [MethodImpl(Inline), Op]
        static MemoryBlock memory(in ApiCodeRow src)
            => new (new MemoryRange(src.Address, src.Address + src.Data.Size), src.Data);        
    }

}