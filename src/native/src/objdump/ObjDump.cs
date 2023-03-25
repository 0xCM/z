//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ObjDump : Channeled<ObjDump>
    {
        public Index<ObjDumpRow> CalcObjRows(ProjectContext context)
        {
            var project = context.Project;
            var src = context.Docs(FileKind.ObjAsm).Array().Sort().Index();
            var result = Outcome.Success;
            var formatter = CsvTables.formatter<ObjDumpRow>();
            var buffer = sys.bag<ObjDumpRow>();

            iter(src, member => {
                result = ObjDump.parse(context, member.Path, out var records);
                if(result.Fail)
                {
                    Channel.Error(result.Message);
                    return;
                }

                var docseq = 0u;
                for(var j=0; j<records.Count; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    buffer.Add(record);
                }
            }, true);

            return buffer.ToArray().Sort().Resequence();
        }

        public static Outcome parse(ProjectContext context, FilePath src, out Index<ObjDumpRow> dst)
            => new ObjDumpParser().Parse(context, src, out dst);

        public static Index<ObjDumpRow> rows(FilePath src)
        {
            var result = TextGrids.load(src, TextEncodingKind.Asci, out var grid);
            if(result.Fail)
                Errors.Throw(result.Message);

            var count = grid.RowCount;
            var buffer = alloc<ObjDumpRow>(count);
            ref var target = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var data = ref grid[(int)i];
                ref var dst = ref seek(target,i);
                var j=0;
                result = DataParser.parse(data[j++], out dst.Seq);
                result = DataParser.parse(data[j++], out dst.DocSeq);
                result = HexParser.parse(data[j++], out dst.OriginId);
                result = EncodingId.parse(data[j++].Text, out dst.EncodingId);
                result = AsmParsers.parse(data[j++].Text, out dst.InstructionId);
                result = DataParser.parse(data[j++], out dst.Section);
                result = DataParser.parse(data[j++], out dst.BlockAddress);
                result = DataParser.parse(data[j++], out dst.BlockName);
                result = AddressParser.parse(data[j++], out dst.IP);
                result = DataParser.parse(data[j++], out dst.Size);
                result = AsmHexApi.parse(data[j++].View, out dst.Encoded);
                dst.Asm = text.trim(data[j++].Text);
                result = AsmInlineComment.parse(data[j++].View, out dst.Comment);
                result = DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }
    }
}