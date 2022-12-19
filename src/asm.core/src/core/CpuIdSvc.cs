//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public class CpuIdSvc : WfSvc<CpuIdSvc>
    {
        public void EmitRecords(ReadOnlySpan<CpuIdRow> src, FilePath dst)
            => TableEmit(src,dst);

        public void EmitBits(ReadOnlySpan<CpuIdRow> src, FilePath dst)
        {
            var buffer = text.emitter();
            regvals(src, buffer);
            Channel.FileEmit(buffer.Emit(), src.Length, dst);
        }

        public static Index<CpuIdRow> import(FolderPath srcdir)
        {
            //2 space-separated 32-bit hex numbers
            const byte InLength = 2*8 + 1;

            //4 32-bit hex numbers interspersed with spaces
            const byte OutLength = 4*8 + 3;

            const string Imply = " => ";

            var srcfiles = srcdir.Files(FS.Def, true).ToReadOnlySpan();
            var count = srcfiles.Length;
            var outcome = Outcome.Success;
            var records = list<CpuIdRow>();

            for(var i=0; i<count; i++)
            {
                if(outcome.Fail)
                    break;

                ref readonly var file = ref skip(srcfiles,i);
                var chip = file.FolderName.Format();
                using var reader = file.LineReader(TextEncodingKind.Asci);
                while(reader.Next(out var line))
                {
                    if(line.StartsWith(Chars.Hash))
                        continue;

                    var content = line.Content;
                    var index = text.index(content, Imply);
                    if(index != NotFound)
                    {
                        var row = new CpuIdRow();
                        var input = text.left(content, index);
                        var iargs = input.Split(Chars.Space).ToReadOnlySpan();
                        if(iargs.Length != 2)
                        {
                            outcome = (false, "Line did not split on marker");
                            break;
                        }

                        outcome = HexParser.parse(skip(iargs,0), out row.Leaf);
                        if(outcome.Fail)
                        {
                            outcome = (false, "Failed to parse eax");
                            break;
                        }

                        if(skip(iargs,1).Contains(Chars.Star))
                            row.Subleaf = uint.MaxValue;
                        else
                            outcome = HexParser.parse(skip(iargs,1), out row.Subleaf);

                        if(outcome.Fail)
                        {
                            outcome = (false, "Failed to parse ecx");
                            break;
                        }

                        var output = text.right(content,index);
                        if(output.Length < OutLength)
                        {
                            outcome = (false, "Output length too short");
                            break;
                        }

                        var outvals = text.slice(output, 0, OutLength).Trim().Split(Chars.Space).ToReadOnlySpan();
                        if(outvals.Length < 5)
                        {
                            outcome = (false, string.Format("Output count = {0}, expected at least {1}", outvals.Length, OutLength));
                            break;
                        }
                        row.Chip = chip;
                        outcome = HexParser.parse(skip(outvals,1), out row.Eax);
                        if(outcome.Fail)
                            break;

                        outcome = HexParser.parse(skip(outvals,2), out row.Ebx);
                        if(outcome.Fail)
                            break;

                        outcome = HexParser.parse(skip(outvals,3), out row.Ecx);
                        if(outcome.Fail)
                            break;

                        outcome = HexParser.parse(skip(outvals,4), out row.Edx);
                        if(outcome.Fail)
                            break;

                        if(outcome)
                            records.Add(row);
                    }
                }
           }

            return records.ToArray();
        }

        static void regvals(ReadOnlySpan<CpuIdRow> src, ITextEmitter dst)
        {
            const sbyte ColWidth = 46;
            const byte ColCount = 6;
            var slots = array(RP.pad(0,-ColWidth), RP.pad(1,-ColWidth), RP.pad(2,-ColWidth), RP.pad(3,-ColWidth), RP.pad(4,-ColWidth), RP.pad(5,-ColWidth));
            var pattern = string.Format("{0} | {1} | {2} | {3} | {4} | {5}", slots);
            var header = string.Format(pattern, "eax(in)", "ecx(in)", "eax(out)", "ebx(out)", "ecx(out)", "edx(out)");
            dst.AppendLine(header);
            var count = src.Length;
            for(var i=0; i<count; i++)
                regvals(skip(src,i), dst);
        }

        static void regvals(in CpuIdRow row, ITextEmitter dst)
        {
            var w = n8;
            // eax(in)
            dst.AppendFormat("{0} [{1}] | ", row.Leaf, row.Leaf.FormatBits(w));
            // ecx(in)
            dst.AppendFormat("{0} [{1}] | ", row.Subleaf, row.Subleaf.FormatBits(w));
            // eax(out)
            dst.AppendFormat("{0} [{1}] | ", row.Eax, row.Eax.FormatBits(w));
            // ebx(out)
            dst.AppendFormat("{0} [{1}] | ", row.Ebx, row.Ebx.FormatBits(w));
            // ecx(out)
            dst.AppendFormat("{0} [{1}] | ", row.Ecx, row.Ecx.FormatBits(w));
            // edx(out)
            dst.AppendFormat("{0} [{1}] ", row.Edx, row.Edx.FormatBits(w));
            dst.AppendLine();
        }

        public static Outcome row(TextRow src, out CpuIdRow dst)
        {
            var input = src.Cells;
            var i = 0;
            var outcome = Outcome.Success;
            outcome += AsciG.parse(skip(input,i++), n16, out dst.Chip);
            outcome += HexParser.parse(skip(input,i++), out dst.Leaf);
            outcome += HexParser.parse(skip(input,i++), out dst.Subleaf);
            outcome += HexParser.parse(skip(input,i++), out dst.Eax);
            outcome += HexParser.parse(skip(input,i++), out dst.Ebx);
            outcome += HexParser.parse(skip(input,i++), out dst.Ecx);
            outcome += HexParser.parse(skip(input,i++), out dst.Edx);
            return outcome;
        }

        public static Index<CpuIdRow> LoadImports(FilePath src)
        {
            const byte FieldCount = CpuIdRow.FieldCount;
            const char Delimiter = Chars.Pipe;
            var result = Outcome.Success;
            using var reader = src.Utf8Reader();
            var header = TextGrids.header(reader.ReadLine(), Delimiter);
            var count = header.Length;
            if(count != FieldCount)
                Errors.Throw(Tables.FieldCountMismatch.Format(FieldCount,count));

            var current = reader.ReadLine();
            var dst = list<CpuIdRow>();
            while(current != null)
            {
                var data = text.row(current,Chars.Pipe);
                if(data.CellCount != FieldCount)
                    Errors.Throw(Tables.FieldCountMismatch.Format(FieldCount, data.CellCount));

                result = CpuIdSvc.row(data, out CpuIdRow cpuid);
                if(result.Fail)
                    Errors.Throw(result.Message);

                dst.Add(cpuid);
                current = reader.ReadLine();
            }

            return dst.Index();
        }

        public Index<CpuIdRow> Import(FolderPath src, FilePath records, FilePath bits)
        {
            var data = CpuIdSvc.import(src);
            EmitRecords(data, records);
            EmitBits(data, bits);
            return data;
        }

        public void ImportSources()
            => Emit(CpuIdSvc.import(AppDb.DbSources("intel").Root));

        void EmitBits(ReadOnlySpan<CpuIdRow> src)
        {
            var result = Outcome.Success;
            var dst = AppDb.DbTargets("sde").Path("sde.cpuid.bits", FileKind.Csv);
            var emitting = EmittingFile(dst);
            EmitBits(src,dst);
            EmittedFile(emitting,src.Length);
        }

        void EmitRows(ReadOnlySpan<CpuIdRow> src)
        {
            var result = Outcome.Success;
            var dst = AppDb.DbTargets("sde").Table<CpuIdRow>("records");
            EmitRecords(src,dst);
        }

        void Emit(ReadOnlySpan<CpuIdRow> src)
        {
            EmitRows(src);
            EmitBits(src);
        }
    }
}