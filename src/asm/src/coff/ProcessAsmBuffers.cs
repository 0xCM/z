//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public class ProcessAsmBuffers
    {
        Index<ProcessAsmRecord> _ProcessAsm;

        Index<ProcessAsmRecord> _ProcessAsmSelection;

        public ProcessAsmBuffers()
        {
            _ProcessAsm = sys.empty<ProcessAsmRecord>();
            _ProcessAsmSelection = sys.empty<ProcessAsmRecord>();
        }

        [MethodImpl(Inline)]
        public Span<ProcessAsmRecord> Selected()
            => _ProcessAsmSelection.Edit;

        [MethodImpl(Inline)]
        public ReadOnlySpan<ProcessAsmRecord> Records()
            => _ProcessAsm;

        static Outcome row(uint line, string src, out ProcessAsmRecord dst)
            => parse(new TextLine(line, src), out dst);

        public static Outcome parse(TextLine src, out ProcessAsmRecord dst)
        {
            const string ErrorPattern = "Error parsing {0} on line {1}";
            var parts = src.Split(Chars.Pipe).Map(x => x.Trim());
            var count = parts.Length;
            var outcome = Outcome.Success;
            if(count != ProcessAsmRecord.FieldCount)
            {
                dst = default;
                return (false, AppMsg.CsvDataMismatch.Format(ProcessAsmRecord.FieldCount, count, src.Content));
            }
            dst = default;
            var i=0u;

            outcome += DataParser.parse(skip(parts,i++), out dst.Sequence);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Sequence), src.LineNumber));

            outcome += AddressParser.parse(skip(parts,i++), out dst.GlobalOffset);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.GlobalOffset), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.BlockAddress);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.BlockAddress), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.IP);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.IP), src.LineNumber));

            outcome += AddressParser.parse(skip(parts,i++), out dst.BlockOffset);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.BlockOffset), src.LineNumber));

            dst.Statement = text.trim(skip(parts,i++));

            outcome += AsmBytes.parse(skip(parts,i++), out dst.Encoded);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Encoded), src.LineNumber));

            outcome += AsmSigInfo.parse(skip(parts,i++), out dst.Sig);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Sig), src.LineNumber));

            dst.OpCode = skip(parts, i++);

            var bitstring = skip(parts,i++);
            dst.Bitstring = asm.bitstring(dst.Encoded);

            outcome += ApiIdentity.parse(skip(parts,i++), out dst.OpUri);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.OpUri), src.LineNumber));

            return true;
        }


        public static Outcome<uint> load(FilePath src, Span<ProcessAsmRecord> dst)
        {
            var counter = 1u;
            var i = 0u;
            var max = dst.Length;
            using var reader = src.AsciReader();
            var header = reader.ReadLine();
            var line = reader.ReadLine();
            var result = Outcome.Success;
            while(line != null && result.Ok)
            {
                result = row(counter++, line, out seek(dst,i));
                if(result.Fail)
                    return result;
                else
                    i++;

                line = reader.ReadLine();
            }
            return i;
        }

        public static Index<ProcessAsmRecord> records(FilePath src)
        {
            var count = Lines.count(src,TextEncodingKind.Asci) - 1;
            var dst = alloc<ProcessAsmRecord>(count);
            load(src,dst).Require();
            return dst;
        }

        public static Index<ProcessAsmRecord> records(IApiPack src)
            => records(src.Archive().ProcessAsmPath());

        public static ProcessAsmBuffers load(FilePath path)
        {
            var count = Lines.count(path,TextEncodingKind.Asci) - 1;
            var buffer = alloc<ProcessAsmRecord>(count);
            var result = load(path, buffer);
            var dst = new ProcessAsmBuffers();
            dst._ProcessAsm = buffer;
            dst._ProcessAsmSelection = alloc<ProcessAsmRecord>(dst._ProcessAsm.Count);
            return dst;
        }

        public static ProcessAsmBuffers load(IApiPack src)
            => load(src.Archive().ProcessAsmPath());
    }
}