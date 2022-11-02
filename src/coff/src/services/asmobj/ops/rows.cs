//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    partial class AsmObjects
    {
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
                result = InstructionId.parse(data[j++].Text, out dst.InstructionId);
                result = DataParser.parse(data[j++], out dst.Section);
                result = DataParser.parse(data[j++], out dst.BlockAddress);
                result = DataParser.parse(data[j++], out dst.BlockName);
                result = DataParser.parse(data[j++], out dst.IP);
                result = DataParser.parse(data[j++], out dst.Size);
                result = ApiNative.parse(data[j++].View, out dst.Encoded);
                dst.Asm = text.trim(data[j++].Text);
                result = AsmInlineComment.parse(data[j++].View, out dst.Comment);
                result = DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }
    }
}