//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public class SdeCpuid : AppService<SdeCpuid>
    {
        static IDbArchive Sources => IntelPaths.service().SdeKit().Scoped("kit/misc/cpuid");

        static IDbArchive Targets => IntelPaths.service().SdeDb();

        public static ParallelQuery<FilePath> defs(IDbArchive src)
            => src.Files(FS.ext("def")).AsParallel();

        public void EmitRecords(ReadOnlySpan<CpuIdRow> src, FilePath dst)
            => Channel.TableEmit(src,dst);
        
        public void EmitBits(ReadOnlySpan<CpuIdRow> src, FilePath dst)
        {
            var buffer = text.emitter();
            regvals(src, buffer);
            Channel.FileEmit(buffer.Emit(), src.Length, dst);
        }

        public static ReadOnlySeq<CpuIdRow> ParseSources(IDbArchive src)
        {
            //2 space-separated 32-bit hex numbers
            const byte InLength = 2*8 + 1;

            //4 32-bit hex numbers interspersed with spaces
            const byte OutLength = 4*8 + 3;

            const string Imply = " => ";

            var paths = src.Files(FS.Def).ToReadOnlySpan();
            var count = paths.Length;
            var outcome = Outcome.Success;
            var records = list<CpuIdRow>();

            for(var i=0; i<count; i++)
            {
                if(outcome.Fail)
                    break;

                ref readonly var file = ref skip(paths,i);
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

        static Outcome row(TextRow src, out CpuIdRow dst)
        {
            var input = src.Cells;
            var i = 0;
            var outcome = Outcome.Success;
            outcome += Asci.parse(skip(input,i++), n16, out dst.Chip);
            outcome += HexParser.parse(skip(input,i++), out dst.Leaf);
            outcome += HexParser.parse(skip(input,i++), out dst.Subleaf);
            outcome += HexParser.parse(skip(input,i++), out dst.Eax);
            outcome += HexParser.parse(skip(input,i++), out dst.Ebx);
            outcome += HexParser.parse(skip(input,i++), out dst.Ecx);
            outcome += HexParser.parse(skip(input,i++), out dst.Edx);
            return outcome;
        }

        public ReadOnlySeq<CpuIdRow> Imported()
            => LoadImports(Targets.Path("sde.cpuid.records", FileKind.Csv));

        static Index<CpuIdRow> LoadImports(FilePath src)
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
                var data = TextDoc.row(current,Chars.Pipe);
                if(data.CellCount != FieldCount)
                    Errors.Throw(Tables.FieldCountMismatch.Format(FieldCount, data.CellCount));

                result = row(data, out CpuIdRow cpuid);
                if(result.Fail)
                    Errors.Throw(result.Message);

                dst.Add(cpuid);
                current = reader.ReadLine();
            }

            return dst.Index();
        }

        public ReadOnlySeq<CpuIdRow> Import()
        {
            var rows = Import(
            Sources,
            Targets.Path("sde.cpuid.records", FileKind.Csv),
            Targets.Path("sde.cpuid.bits", FileKind.Csv)
            );
            return rows;
        }
        public ReadOnlySeq<CpuIdRow> Import(IDbArchive src, FilePath records, FilePath bits)
        {
            var data = ParseSources(src);
            EmitRecords(data, records);
            EmitBits(data, bits);
            return data;
        }
    }
}