//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    using Iced = Iced.Intel;

    public class AsmDecoder : WfSvc<AsmDecoder>
    {
        readonly AsmFormatConfig AsmFormat;

        IceInstructionFormatter IceFormatter;

        public AsmDecoder()
        {
            AsmFormat = AsmFormatConfig.@default(out var _);
        }

        protected override void OnInit()
        {
            IceFormatter = formatter(AsmFormat);
        }

        public Option<AsmRoutine> Decode(ApiCaptureBlock src)
        {
            var outcome = Decode(src, out var routine);
            if(outcome)
                return Option.some(routine);
            else
                return Option.none<AsmRoutine>();
        }

        public ApiHostRoutines Decode(ApiHostBlocks src)
        {
            var host = src.Host;
            var flow = Channel.Running(Msg.DecodingHostRoutines.Format(host));
            var view = src.Blocks.View;
            var count = view.Length;
            var instructions = sys.list<ApiHostRoutine>();
            var ip = MemoryAddress.Zero;
            var target = sys.list<IceInstruction>();
            for(var i=0; i<count; i++)
            {
                target.Clear();
                ref readonly var block = ref skip(view,i);
                var outcome = Decode(block, x => target.Add(x), out var decoded);
                if(outcome)
                {
                    if(i == 0)
                        ip = target[0].IP;

                     instructions.Add(AsmRoutines.hosted(ip, block, target.ToArray()));
                }
                else
                    Channel.Warn(outcome.Message);
            }

            var routines = new ApiHostRoutines(host, instructions.ToArray());
            Channel.Ran(flow, Msg.DecodedHostRoutines.Format(routines.Length, host));
            return routines;
        }

        public void Decode(ReadOnlySpan<ApiPartBlocks> src, Span<ApiPartRoutines> dst)
        {
            var hostFx = list<ApiHostRoutines>();
            var stats = ApiDecoderStats.init();
            var partCount = src.Length;
            var parts = src;
            var flow = Channel.Running(Msg.DecodingParts.Format(partCount));
            for(var i=0; i<partCount; i++)
            {
                hostFx.Clear();

                ref readonly var part = ref skip(parts,i);
                var hostBlocks = part.Blocks.View;
                var kHosts = hostBlocks.Length;
                if(kHosts == 0)
                {
                    seek(dst,i) = ApiPartRoutines.Empty;
                    continue;
                }

                var decoding = Channel.Running(Msg.DecodingPartRoutines.Format(kHosts, part.Part));
                for(var j = 0; j<kHosts; j++)
                {
                    ref readonly var host = ref skip(hostBlocks,j);

                    if(host.IsEmpty)
                        continue;

                    var routines = Decode(host);
                    hostFx.Add(routines);
                    stats.HostCount++;
                    stats.MemberCount += routines.RoutineCount;
                    stats.InstCount += routines.InstructionCount;
                }

                seek(dst,i) = new ApiPartRoutines(part.Part, hostFx.ToArray());

                Channel.Ran(decoding,  Msg.DecodedPartRoutines.Format(hostFx.Count, part.Part, stats));
            }

            Channel.Ran(flow, Msg.DecodedMachine.Format(src.Length, parts.Length));
        }

        public ReadOnlySpan<ApiPartRoutines> Decode(ReadOnlySpan<ApiCodeBlock> src)
        {
            var hosts = ApiCodeRows.hosted(src);
            var parts = ApiCodeRows.parts(hosts);
            var count = parts.Length;
            var dst = alloc<ApiPartRoutines>(count);
            Decode(parts, dst);
            return dst;
        }


        public AsmRoutine Decode(ApiEncoded src)
        {
            ApiIdentity.parse(src.Token.Uri.Format(), out var uri).Require();
            var code = new ApiCodeBlock(src.Token.TargetAddress, uri, src.Code);
            Decode(code, out var instructions);
            var asm = new ApiBlockAsm(code, instructions);
            return routine(uri, src.Sig.Format(), asm, r => AsmFormatter.format(r, AsmFormatter.header(src), AsmFormat));
        }

        public AsmHostRoutines Decode(ApiHostUri uri, ReadOnlySpan<MemberCodeBlock> src)
        {
            try
            {
                var flow = Channel.Running(uri);
                var count = src.Length;
                var buffer = alloc<AsmMemberRoutine>(count);
                ref var dst = ref first(buffer);
                for(var i=0; i<count; i++)
                {
                    ref readonly var code = ref skip(src, i);
                    var outcome = DecodeRoutine(code, out var decoded);
                    if(!outcome)
                    {
                        Channel.Error($"Could not decode {code}");
                        seek(dst,i) = AsmMemberRoutine.Empty;
                    }
                    else
                        seek(dst, i) = new AsmMemberRoutine(code.Member, decoded);
                }

                Channel.Ran(flow, Msg.DecodedHostMembers.Format(buffer.Length, uri));
                return buffer;
            }
            catch(Exception e)
            {
                Channel.Error($"{uri}: {e}");
                return sys.empty<AsmMemberRoutine>();
            }
        }

        public Outcome Decode(in ApiCaptureBlock src, out AsmRoutine dst)
        {
            dst = AsmRoutine.Empty;
            var outcome = Decode(src.OpUri, src.Parsed, src.BaseAddress, out var instructions);
            if(outcome)
            {
                var asm = new ApiBlockAsm(src.CodeBlock, instructions.InstructionStorage, src.TermCode);
                dst = routine(src.OpUri, src.Method.Artifact().DisplaySig.Format(), asm);
                return true;
            }
            return outcome;
        }

        public Outcome Decode(in ApiCodeBlock src, out AsmInstructionBlock dst)
            => Decode(src.OpUri, src.Encoded, src.BaseAddress, out dst);

        public Index<IceInstruction> Decode(BinaryCode code, MemoryAddress @base)
        {
            var decoded = new Iced.InstructionList();
            var decoder = idecoder(code, @base, out var reader);
            while (reader.CanReadByte)
            {
                ref var instruction = ref decoded.AllocUninitializedElement();
                decoder.Decode(out instruction);
            }

            var count = decoded.Count;
            var buffer = alloc<Asm.IceInstruction>(count);
            ref var dst = ref first(buffer);
            var formatted = IceFormatter.FormatInstructions(decoded, @base);
            var position = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var instruction = ref decoded[i];
                var size = (uint)instruction.ByteLength;
                var encoded = slice(code.View, position, size).ToArray();
                seek(dst, i) = extract(instruction, skip(formatted,i), encoded);
                position += size;
            }
            return buffer;
        }

        public Outcome DecodeRoutine(in MemberCodeBlock src, out AsmRoutine dst)
        {
            dst = AsmRoutine.Empty;
            var outcome = Decode(src.Encoded, out var block);
            if(outcome)
                dst = AsmRoutines.routine(src, block);
            return outcome;
        }

        Outcome Decode(ApiCodeBlock src, Action<IceInstruction> f, out IceInstructionList dst)
            => Decode(src.OpUri, new CodeBlock(src.BaseAddress, src.Data), f, out dst);

        Outcome Decode(OpUri uri, BinaryCode code, MemoryAddress @base, out AsmInstructionBlock dst)
        {
            dst = AsmInstructionBlock.Empty;
            if(code.IsEmpty)
                return (false,"Supplied source was empty");
            else
            {
                dst = new AsmInstructionBlock(uri, Decode(code,@base), code);
                return true;
            }
        }

        Outcome Decode(OpUri uri, CodeBlock src, Action<Asm.IceInstruction> f, out IceInstructionList dst)
        {
            dst = IceInstructionList.Empty;
            try
            {
                var decoded = new Iced.InstructionList();
                var reader = new Iced.ByteArrayCodeReader(src.Code);
                var decoder = Iced.Decoder.Create(IntPtr.Size*8, reader);
                var @base = src.Address;
                decoder.IP = @base;
                var buffer = new List<Asm.IceInstruction>(decoded.Count);
                var position = 0u;
                while (reader.CanReadByte)
                {
                    ref var iced = ref decoded.AllocUninitializedElement();
                    decoder.Decode(out iced);
                    var size = (uint)iced.ByteLength;
                    var encoded = slice(src.View, position, size).ToArray();
                    var instruction = extract(iced, IceFormatter.FormatInstruction(iced, @base), encoded);
                    buffer.Add(instruction);
                    f(instruction);
                    position += size;

                }
                dst = icelist(buffer.ToArray(), src);
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        static IceInstruction extract(Iced.Instruction src, string formatted, BinaryCode decoded)
            => IceConverters.extract(src,formatted, decoded);

        [MethodImpl(Inline), Op]
        static IceInstructionList icelist(IceInstruction[] src, CodeBlock data)
            => new (src, data);

        [MethodImpl(Inline), Op]
        static IceInstructionFormatter formatter(in AsmFormatConfig config)
            => new (config);

        static Iced.Decoder idecoder(BinaryCode code, MemoryAddress @base, out Iced.ByteArrayCodeReader reader)
        {
            reader = new Iced.ByteArrayCodeReader(code);
            var decoder =  Iced.Decoder.Create(64, reader);
            decoder.IP = @base;
            return decoder;
        }

        static AsmRoutine routine(OpUri uri, string sig, ApiBlockAsm src, Func<AsmRoutine,string> render = null, bool check = false)
        {
            var count = src.InstructionCount;
            var buffer = new AsmInstructionInfo[count];
            var offset = 0u;
            var @base = src.BaseAddress;
            var instructions = src.Instructions;
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                var instruction = skip(instructions,i);
                if(check)
                    CheckInstructionSize(instruction, offset, src);
                seek(dst, i) = ApiInstructions.summarize(@base, instruction, src.Encoded.Code, instruction.FormattedInstruction, offset);
                offset += (uint)instruction.ByteLength;
            }

            if(check)
                CheckBlockLength(src);

            return new AsmRoutine(uri, sig, src.Encoded, src.TermCode, ApiInstructions.from(src.Encoded, src.Decoded), render);
        }

        static void CheckInstructionSize(in IceInstruction instruction, uint offset, in ApiBlockAsm src)
        {
            if(src.Encoded.Length < offset + instruction.ByteLength)
                sys.@throw(SizeMismatch(instruction, offset, src));
        }

        static uint size(in ApiBlockAsm src)
        {
            var result = 0u;
            var instructions = src.Instructions;
            var count = instructions.Length;
            for(var i=0; i<count; i++)
                result += (uint)skip(instructions,i).ByteLength;
            return result;
        }

        static void CheckBlockLength(in ApiBlockAsm src)
        {
            var length = size(src);
            if(length != src.Encoded.Length)
                sys.@throw(BadBlockLength(src,length));
        }

        static AppException BadBlockLength(in ApiBlockAsm src, uint computedLength)
            => new AppException(InstructionBlockSizeMismatch(src.BaseAddress, src.Encoded.Length, computedLength));

        static AppException SizeMismatch(in IceInstruction instruction, uint offset, in ApiBlockAsm src)
            => new AppException(InstructionSizeMismatch(instruction.IP, offset, (uint)src.Encoded.Length, (uint)instruction.ByteLength));

        static AppMsg InstructionSizeMismatch(MemoryAddress ip, uint offset, uint actual, uint reported,
            [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
                => AppMsg.error(text.concat(
                    $"The encoded instruction length does not match the reported instruction length:",
                    $"address = {ip}, datalen = {reported}, offset = {offset}, bytelen = {reported}"),
                        caller, file, line);

        static AppMsg InstructionBlockSizeMismatch(MemoryAddress @base, int actual, uint reported,
            [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
                => AppMsg.error(text.concat(
                    $"The encoded instruction block length does not match the reported total instruction length:",
                    $"@base = {@base}, block length = {reported}, reported length = {reported}"),
                        caller, file, line);
    }
}