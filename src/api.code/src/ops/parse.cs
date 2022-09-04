//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ApiCode
    {
        const byte ZeroLimit = 10;

        static ConcurrentDictionary<ApiToken,ApiEncoded> parse(ReadOnlySpan<RawMemberCode> src, WfEmit log)
        {
            var count = src.Length;
            var buffer = span<byte>(Pow2.T16);
            var host = _ApiHostUri.Empty;
            var dst = dict<_ApiHostUri,CollectedCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                var extracted = CollectedCodeExtract.Empty;
                var extracts = CollectedCodeExtracts.Empty;
                ref readonly var raw = ref skip(src,i);
                var result = ApiCode.gather(raw, buffer, out extracted);
                if(result.Fail)
                {
                    Errors.Throw($"StubCodeMismatch:{result.Message}");
                }
                else
                {
                    ref readonly var uri = ref raw.Uri;
                    if(uri.Host != host)
                        host = uri.Host;

                    if(dst.TryGetValue(host, out extracts))
                        extracts.Include(extracted);
                    else
                        dst[host] = new CollectedCodeExtracts(extracted);
                }
            }

            return parse(dst, log);
        }

        static ConcurrentDictionary<ApiToken,ApiEncoded> parse(Dictionary<_ApiHostUri,CollectedCodeExtracts> src, WfEmit log)
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
            result = DataParser.parse(skip(cells,i++), out dst.Id);
            result = DataParser.parse(skip(cells,i++), out dst.EntryAddress);
            result = DataParser.parse(skip(cells,i++), out dst.EntryRebase);
            result = DataParser.parse(skip(cells,i++), out dst.TargetAddress);
            result = DataParser.parse(skip(cells,i++), out dst.TargetRebase);
            result = DataParser.parse(skip(cells,i++), out dst.StubAsm);
            result = Disp32.parse(skip(cells,i++), out dst.Disp);
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


                result = DataParser.parse(fields[index++], out dst.Uri);
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

        // x7ffb651869e0[00012:00017]=<c5f8776690c5f857c0c5f91101488bc1c3>
        public static Outcome<ByteSize> parse(ushort index, string src, out MemoryBlock dst)
        {
            var count = src.Length;
            var line = index + 1;
            var result = Outcome.Success;
            dst = default;
            if(count == 0)
            {
                dst = MemoryBlock.Empty;
                return (false, "The input, it is empty");
            }

            if(first(src) != 'x')
                return(false, $"Line {src} does not begin with the required character 'x'");

            var i = src.IndexOf('h');
            if(i == NotFound)
                return(false, $"Line {src} does not contain address terminator 'h'");

            result = AddressParser.parse(text.slice(src, 1, i-1), out MemoryAddress @base);
            if(result.Fail)
                return (false, $"{result.Message} | Could not parse address from '{src}'");

            if(!Fenced.unfence(src, SegFence, out var seg))
                return (false, $"Line {src} does not contain segment fence");

            if(!Fenced.unfence(src, DataFence, out var data))
                return (false, $"Line {src} does not contain data fence");

            var segparts = text.split(seg, SegSep);
            if(segparts.Length != 2)
                return (false, $"Line {src} segement specifier does not have the required 2 components");

            var segLeft = skip(segparts,0);
            DataParser.parse(segLeft, out ushort segidx);
            if(segidx != index)
                return (false, $"Line {line} number does not correspond to the segement index {segidx}");

            var segRight = skip(segparts,1);
            result = DataParser.parse(segRight, out ByteSize segsize);
            if(result.Fail)
                return (false, $"{result.Message} | Could not parse segment size from {segRight}");

            result = Hex.parse(data, out BinaryCode code);

            if(result.Fail)
                return (false, $"{result.Message} | Could not parse code from {data}");

            if(code.IsEmpty)
                return (false, $"Line {src} contains no data");

            if(segsize != code.Length)
                return (false, $"Expected {segsize} bytes but parsed {code.Length}");

            dst = new MemoryBlock(@base, segsize, code);

            return segsize;
        }

        const char SegSep = Chars.Colon;

        static Fence<char> SegFence = ('[',']');

        static Fence<char> DataFence = ('<', '>');

    }
}