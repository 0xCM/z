//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static sys;

    public sealed class AsmRowBuilder : AppService<AsmRowBuilder>
    {
        readonly Dictionary<AsmMnemonic, ArrayBuilder<AsmDetailRow>> Index;

        int Sequence;

        uint Offset;

        AsmDecoder Decoder;

        public AsmRowBuilder()
        {
            Sequence = 0;
            Offset = 0;
            Index = new Dictionary<AsmMnemonic, ArrayBuilder<AsmDetailRow>>();
        }

        protected override void OnInit()
        {
            Decoder = Wf.AsmDecoder();
        }

        public Index<AsmDetailRow> Emit(ReadOnlySpan<ApiCodeBlock> src)
            => Emit(src, FolderPath.Empty);

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static AsmRowSet<T> rowset<T>(T key, AsmDetailRow[] src)
            => new AsmRowSet<T>(key,src);

        public Index<AsmDetailRow> Emit(ReadOnlySpan<ApiCodeBlock> src, FolderPath dst)
        {
            var rows = BuildRows(src);
            var rowsets = rows.GroupBy(x => x.Mnemonic).Select(x => rowset(x.Key, x.Array())).Array().ToReadOnlySpan();
            var count = rowsets.Length;
            for(var i=0; i<count; i++)
                Emit(skip(rowsets,i), dst);
            return rows;
        }

        Index<AsmDetailRow> BuildRows(ReadOnlySpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            var flow = Channel.Running(Msg.CreatingAsmRowsFromBlocks.Format(count));
            var dst = list<AsmDetailRow>();
            for(var i=0u; i<count; i++)
                dst.AddRange(BuildRows(skip(src,i)));
            Channel.Ran(flow,Msg.CreatedAsmRowsFromBlocks.Format(dst.Count));
            return dst.ToArray();
        }

        uint Emit(in AsmRowSet<AsmMnemonic> src, FolderPath dst)
            => Emit(src, DetailPath(dst, src));

        uint Emit(in AsmRowSet<AsmMnemonic> src, FilePath dst)
        {
            var count = src.Count;
            if(count != 0)
            {
                var flow = Channel.EmittingTable<AsmDetailRow>(dst);
                var records = span(src.Sequenced);
                var formatter = CsvTables.formatter<AsmDetailRow>(AsmDetailRow.RenderWidths);
                using var writer = dst.Writer();
                writer.WriteLine(formatter.FormatHeader());
                for(var i=0; i<count; i++)
                {
                    ref readonly var record = ref skip(records,i);
                    writer.WriteLine(formatter.Format(record));
                }
                Channel.EmittedTable(flow, count);
            }
            return count;
        }

        FilePath DetailPath(FolderPath dir, in AsmRowSet<AsmMnemonic> src)
            => AppDb.Service.ApiTargets().Table<AsmDetailRow>();

        Index<AsmDetailRow> BuildRows(in ApiCodeBlock src)
        {
            var outcome = Decoder.Decode(src, out var block);
            if(outcome)
                return BuildRows(src.Code, block);
            else
            {
                Channel.Error(outcome.Message);
                return array<AsmDetailRow>();
            }
        }

        Index<AsmDetailRow> BuildRows(in CodeBlock code, IceInstruction[] src)
        {
            var bytes = span(code.Storage);
            var offset = z16;
            var count = src.Length;
            var buffer = alloc<AsmDetailRow>(count);
            var dst = span(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var instruction = ref src[i];
                var size = (ushort)instruction.ByteLength;
                Fill(code, new Address16(offset), bytes.Slice(offset, size), instruction, ref seek(dst,i));
                offset += size;
            }
            return buffer;
        }

        void Fill(in CodeBlock code, Address16 offset, Span<byte> encoded, in IceInstruction src, ref AsmDetailRow dst)
        {
            dst.Sequence = (uint)NextSequence;
            dst.BlockAddress = code.Address;
            dst.IP = src.IP;
            dst.LocalOffset = offset;
            dst.GlobalOffset = NextOffset;
            dst.Mnemonic = src.AsmMnemonic;
            dst.OpCode = src.Specifier.OpCode;
            dst.Encoded = new BinaryCode(encoded.TrimEnd().ToArray());
            dst.Statement = src.FormattedInstruction;
            dst.Instruction = src.Specifier.Sig.Format();
            dst.CpuId = RP.embrace(src.CpuidFeatures.Select(x => x.ToString()).Join(","));
            dst.OpCodeId = src.Code.ToString();
            if(Index.TryGetValue(src.AsmMnemonic, out var builder))
                builder.Include(dst);
            else
                Index.Add(src.AsmMnemonic, ArrayBuilder.build(dst));
        }

        int NextSequence
        {
            [MethodImpl(Inline)]
            get => Sequence++;
        }

        Address32 NextOffset
        {
            [MethodImpl(Inline)]
            get => Offset++;
        }
    }
}