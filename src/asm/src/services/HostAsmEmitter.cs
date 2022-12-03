//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.IO;

    using static sys;

    public sealed class HostAsmEmitter : AppService<HostAsmEmitter>
    {
        AsmDecoder Decoder => Service(Wf.AsmDecoder);

        public AsmHostRoutines EmitHostRoutines(ApiHostUri host, ReadOnlySpan<MemberCodeBlock> src, FilePath dst)
        {
            var flow = Running(Msg.EmittingHostRoutines.Format(host));
            var decoded = Decoder.Decode(host, src);
            var emitted = Emit(host, decoded.Storage, dst);
            Ran(flow, Msg.EmittedHostRoutines.Format(emitted, host, dst.ToUri()));
            return decoded;
        }

        Count Emit(ApiHostUri uri, ReadOnlySpan<AsmMemberRoutine> src, FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                using var writer = dst.Writer();
                var buffer = text.buffer();

                for(var i=0; i<count; i++)
                {
                    ref readonly var item = ref skip(src,i);
                    AsmFormatter.render(item.Routine, AsmFormatConfig.DefaultStreamFormat, buffer);
                    writer.Write(buffer.Emit());
                }
            }

            return count;
        }

        public ReadOnlySpan<HostAsmRecord> EmitHostAsm(ReadOnlySpan<ApiHostBlocks> src, FolderPath root)
        {
            root.Delete();

            var count = src.Length;
            var flow = Running(string.Format("Emitting statements for {0} host block sets", count));
            var records = list<HostAsmRecord>();
            var buffer = list<HostAsmRecord>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();

                ref readonly var blocks = ref skip(src,i);
                if(blocks.Length == 0)
                    continue;

                counter += BuildHostAsm(blocks, buffer);

                var host = blocks.Host;
                EmitHostAsmDoc(host, buffer.ViewDeposited());
                EmitHostAsmRecords(host, buffer.ViewDeposited());
                records.AddRange(buffer);
            }

            Ran(flow, string.Format("Emitted {0} total statements", counter));
            return records.ViewDeposited();
        }

        public Index<HostAsmRecord> EmitHostAsm(ReadOnlySpan<AsmRoutine> src, IApiPackArchive dst)
        {
            var total = ApiInstructions.count(src);
            var running = Running(Msg.CreatingStatements.Format(total));
            Index<HostAsmRecord> buffer = alloc<HostAsmRecord>(total);
            var count = src.Length;
            var offset = 0u;
            for(var i=0; i<count; i++)
                offset += ApiInstructions.hostasm(skip(src,i), slice(buffer.Edit, offset));
            Ran(running, Msg.CreatedStatements.Format(total));
            EmitHostAsm(buffer, dst.Tables().Root);
            return buffer;
        }

        public void EmitHostAsm(ReadOnlySpan<HostAsmRecord> src, FolderPath root)
        {
            var thumbprints = hashset<AsmThumbprint>();
            var formatter = Tables.formatter<HostAsmRecord>(HostAsmRecord.RenderWidths);
            var statements = src;
            var count = statements.Length;
            var host = ApiHostUri.Empty;
            var counter = 0u;
            var tableWriter = default(StreamWriter);
            var tablePath = FilePath.Empty;
            var tableFlow = default(TableFlow<HostAsmRecord>);
            var asmWriter = default(StreamWriter);
            var asmPath = FilePath.Empty;
            var asmFlow = FileEmission.Empty;
            var buffer = text.buffer();

            for(var i=0; i<count; i++)
            {
                ref readonly var statement = ref skip(statements,i);
                if(statement.IsValid())
                    thumbprints.Add(AsmThumbprint.define(statement));

                var uri = statement.OpUri;
                if(i == 0)
                {
                    host = uri.Host;
                    tablePath = AsmTablePath(host, root);
                    tableWriter = tablePath.Writer();
                    tableWriter.WriteLine(formatter.FormatHeader());

                    tableFlow = EmittingTable<HostAsmRecord>(tablePath);
                    asmPath = AsmSrcPath(host, root);
                    asmWriter = asmPath.Writer();
                    asmFlow = EmittingFile(asmPath);
                }

                if(uri.Host != host)
                {
                    tableWriter.Dispose();
                    EmittedTable<HostAsmRecord>(tableFlow, counter);

                    asmWriter.Dispose();
                    EmittedFile(asmFlow, counter);

                    host = statement.OpUri.Host;
                    tablePath = FilePath.Empty;

                    tableWriter = tablePath.Writer();
                    tableWriter.WriteLine(formatter.FormatHeader());
                    tableFlow = EmittingTable<HostAsmRecord>(tablePath);

                    asmPath =  FilePath.Empty;
                    asmWriter = asmPath.Writer();
                    asmFlow = EmittingFile(asmPath);

                    counter = 0;
                }

                if(statement.BlockOffset == 0)
                    EmitAsmBlockHeader(statement,asmWriter);

                tableWriter.WriteLine(formatter.Format(statement));
                asmWriter.WriteLine(statement.Format());

                counter++;
            }

            tableWriter.Dispose();
            EmittedTable(tableFlow, counter);

            asmWriter.Dispose();
            EmittedFile(asmFlow, counter);
        }

        void EmitHostAsmDoc(ApiHostUri host, ReadOnlySpan<HostAsmRecord> src)
        {
            var dst = FilePath.Empty;
            var flow = EmittingFile(dst);
            var count = src.Length;
            using var asmwriter = dst.Writer();

            for(var j=0; j<count;j++)
            {
                ref readonly var statement = ref skip(src,j);
                if(statement.BlockOffset == 0)
                    EmitAsmBlockHeader(statement,asmwriter);

                asmwriter.WriteLine(statement.Format());
            }

            EmittedFile(flow, count);
        }

        void EmitHostAsmRecords(ApiHostUri host, ReadOnlySpan<HostAsmRecord> src)
        {
            var dst = FilePath.Empty;
            var flow = EmittingTable<HostAsmRecord>(dst);
            EmittedTable(flow, CsvChannels.emit(src, HostAsmRecord.RenderWidths, dst));
        }

        AsmInstructionBlock Decode(in ApiCodeBlock src)
        {
            var outcome = Decoder.Decode(src, out var decoded);
            if(outcome)
                return decoded;
            else
            {
                Wf.Error(outcome.Message);
                return AsmInstructionBlock.Empty;
            }
        }

        FilePath AsmSrcPath(ApiHostUri host, FolderPath root)
            => FilePath.Empty;

        FilePath AsmTablePath(ApiHostUri host, FolderPath root)
            => FilePath.Empty;

        uint BuildHostAsm(in ApiHostBlocks src, List<HostAsmRecord> dst)
        {
            var blocks = src.Blocks.View;
            var count = blocks.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += ApiInstructions.hostasm(Decode(skip(blocks,i)), dst);
            return counter;
        }

        const string AsmBlockSeparator = "; ------------------------------------------------------------------------------------------------------------------------";

        static void EmitAsmBlockHeader(in HostAsmRecord first, StreamWriter dst)
        {
            dst.WriteLine(AsmBlockSeparator);
            dst.WriteLine(string.Format("; {0}, uri={1}", first.BlockAddress, first.OpUri));
            dst.WriteLine(AsmBlockSeparator);
        }
    }
}