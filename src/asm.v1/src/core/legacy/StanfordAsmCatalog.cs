//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public sealed partial class StanfordAsmCatalog : WfSvc<StanfordAsmCatalog>
    {
        readonly TextDocFormat SourceFormat;

        readonly Index<StanfordInstruction> RowBuffer;

        const uint MaxRowCount = 2500;

        const char AsmCatDelimiter = Chars.Tab;

        public StanfordAsmCatalog()
        {
            SourceFormat = TextDocFormat.Structured(AsmCatDelimiter, false);
            RowBuffer = alloc<StanfordInstruction>(MaxRowCount);
        }

        public uint AssetImportCount {get; private set;}

        public ReadOnlySpan<StokeAsmExportRow> ImportExported()
        {
            var src = AppDb.DbSources().Table<StanfordInstruction>("asmcat");
            var doc = TextGrids.parse(src).Require();
            var data = doc.Rows;
            var count = data.Length;
            var buffer = span<StokeAsmExportRow>(count);
            for(var i=0; i<count; i++)
            {
                var export = default(StokeAsmExportRow);
                var import = default(StanfordInstruction);
                map(skip(data, i), ref import);
                map(import, ref seek(buffer, i));
            }

            var dst = AppDb.DbTargets().Table<StokeAsmExportRow>("asmcat");
            var flow = EmittingTable<StokeAsmExportRow>(dst);
            var _count = CsvTables.emit(@readonly(buffer), dst);
            EmittedTable(flow, _count);
            return buffer;
        }

        /// <summary>
        /// Retrieves the forms present in the catalog
        /// </summary>
        public ReadOnlySpan<AsmFormInfo> DeriveExpressions()
        {
            var imported = LoadSource();
            var count = imported.Length;
            var buffer = span<AsmFormInfo>(count);
            var j=0u;
            var k=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(imported, i);
                if(AsmSigInfo.parse(row.Instruction, out var sig))
                    seek(buffer, k++) = (new (row.OpCode), sig);
                else
                {
                    seek(buffer, k++) = AsmFormInfo.Empty;
                    Channel.Warn($"The opcode row {row.OpCode} could not be parsed");
                }
            }

            return buffer;
        }

        public ReadOnlySeq<string> DeriveEncodingKinds()
        {
            var rows = LoadSource();
            var count = rows.Length;
            var dst = hashset<string>();
            for(var i=0u; i<count; i++)
                dst.Add(skip(rows,i).EncodingKind);
            return dst.ToSeq().Sort();
        }

        public ReadOnlySpan<StanfordInstruction> LoadSource(FilePath src)
        {
            var lines = src.ReadNumberedLines();
            var foundheader = false;
            var count = lines.Length;
            var buffer = RowBuffer.Edit;
            ref var dst = ref first(buffer);
            var j = z16;
            var failed = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                if(foundheader)
                {
                    var row = default(StanfordInstruction);
                    if(line.IsNonEmpty)
                    {
                        if(parse(j, line, ref row))
                            seek(dst, j++) = row;
                        else
                        {
                            failed = true;
                            break;
                        }
                    }
                }
                else
                {
                    if(line.Content.Equals(SourceHeader))
                        foundheader = true;
                }
            }

            AssetImportCount = j;
            return slice(buffer, 0, AssetImportCount);
        }

        public ReadOnlySpan<StanfordInstruction> LoadSource()
            => LoadSource(AppDb.DbSources().Sources("asm.stanford").Path("stanford-asm-catalog",FileKind.Csv));

        public ReadOnlySpan<StanfordInstruction> RunEtl()
        {
            var imports = LoadSource();
            Channel.TableEmit(imports, AppDb.AsmDb().Targets("asm.refs").Table<StanfordInstruction>());
            return imports;
        }

        public void Emit(ReadOnlySpan<AsmFormInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<StanfordFormInfo>(count);
            for(var i=0u; i<count; i++)
            {
                ref var target = ref seek(buffer,i);
                ref readonly var source = ref skip(src,i);
                target.Seq =i;
                target.OpCode = source.OpCode;
                target.Sig = source.Sig;
                target.FormExpr = new AsmFormInfo(source.OpCode,source.Sig);
            }
            Channel.TableEmit(buffer, AppDb.DbTargets().Targets("asm.refs").Table<StanfordFormInfo>());
        }

        Outcome parse(ushort seq, in TextLine src, ref StanfordInstruction dst)
        {
            if(TextGrids.row(src, SourceFormat, out var row))
            {
                if(row.CellCount == 15)
                {
                    map(row, ref dst, (ushort)(seq + 1));
                    return true;
                }
                else
                {
                    Channel.Error($"Row content parse failure: {nameof(row.CellCount)} = {row.CellCount} != 15; Line: {src}");
                    return false;
                }
            }
            else
            {
                Channel.Error($"Row parse failure: {src.Content}");
                return false;
            }
        }

        FolderName TargetFolder
            => FS.folder("asmcat");

        static bool mode64(string src)
            => src switch
            {
                "V" => true,
                _ => false
            };

        static void map(in StanfordInstruction src, ref StokeAsmExportRow dst)
        {
            dst.Sequence = src.Seq;
            dst.OpCode = src.OpCode;
            dst.Instruction = src.Instruction;
            dst.Mode64 = mode64(src.Mode64);
            dst.LegacyMode = src.LegacyMode;
            dst.EncodingKind = src.EncodingKind;
            dst.Properties = src.Properties;
            dst.ImplicitRead = src.ImplicitRead;
            dst.ImplicitWrite = src.ImplicitWrite;
            dst.ImplicitUndef = src.ImplicitUndef;
            dst.Protected = src.Protected;
            dst.Cpuid = src.Cpuid;
            dst.AttMnemonic = src.AttMnemonic;
            dst.Description = src.Description;
        }

        static void map(in TextRow src, ref StanfordInstruction dst, ushort? seq = null)
        {
            var i = 0;
            var cells = src.Cells;
            if(seq == null)
                NumericParser.parse(base10, skip(cells,i++).Text, out dst.Seq);
            else
                dst.Seq = seq.Value;
            dst.OpCode = skip(cells, i++);
            dst.Instruction = skip(cells, i++);
            dst.EncodingKind = skip(cells, i++);
            dst.Properties = skip(cells, i++);
            dst.ImplicitRead = skip(cells, i++);
            dst.ImplicitWrite = skip(cells, i++);
            dst.ImplicitUndef = skip(cells, i++);
            dst.Useful = skip(cells, i++);
            dst.Protected = skip(cells, i++);
            dst.Mode64 = skip(cells, i++);
            dst.LegacyMode = skip(cells, i++);
            dst.Cpuid = skip(cells, i++);
            dst.AttMnemonic = skip(cells, i++);
            dst.Preferred = skip(cells, i++);
            dst.Description = skip(cells, i++);
        }

        const string SourceHeader = "Opcode	Instruction	Op/En	Properties	Implicit Read	Implicit Write	Implicit Undef	Useful	Protected	64-bit Mode	Compat/32-bit-Legacy Mode	CPUID Feature Flags	AT&T Mnemonic	Preferred 	Description";

        static ReadOnlySpan<string> SourceHeaderFields
            => SourceHeader.Split(AsmCatDelimiter);
    }
}