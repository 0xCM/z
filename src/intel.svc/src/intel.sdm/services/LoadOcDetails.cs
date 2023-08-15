//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public static Outcome parse(TextLine src, out SdmOpCodeDetail dst)
        {
            var result = Outcome.Success;
            var cells = src.Split(Chars.Pipe);
            var count = cells.Length;
            dst = default;
            if(count != SdmOpCodeDetail.FieldCount)
                return (false, AppMsgs.FieldCountMismatch.Format(SdmOpCodeDetail.FieldCount, count));

            var i=0;

            result = DataParser.parse(skip(cells,i++), out dst.OpCodeKey);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.OpCodeKey), skip(cells,i-1)));

            dst.Mnemonic = skip(cells, i++).ToUpperInvariant();
            dst.OpCodeExpr = skip(cells, i++).Trim();
            AsmOpCodes.parse(skip(cells, i++), out dst.OpCodeValue);
            dst.AsmSig = skip(cells, i++);            
            dst.EncXRef = skip(cells, i++);
            dst.Mode64 = skip(cells, i++);
            dst.Mode32 = skip(cells, i++);
            dst.Mode64x32 = skip(cells, i++);
            dst.CpuIdExpr = skip(cells, i++);
            dst.Description = skip(cells, i++);
            return result;
        }

        [Op]
        public static uint rows(ReadOnlySpan<TextLine> src, Span<SdmOpCodeDetail> dst)
        {
            var counter = 0u;
            var result = Outcome.Success;
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                result = parse(skip(src,i), out seek(dst, i));
                if(result.Fail)
                      Errors.Throw(result.Message);
            }
            return count;
        }

        public Index<SdmOpCodeDetail> LoadOcDetails()
        {
            return Data(nameof(LoadOcDetails), Load);

            Index<SdmOpCodeDetail> Load()
            {
                var dst = sys.empty<SdmOpCodeDetail>();
                var src = SdmPaths.TargetTable<SdmOpCodeDetail>();
                var lines = SdmPaths.TargetTable<SdmOpCodeDetail>().ReadNumberedLines();
                var count = lines.Count -1;
                dst = alloc<SdmOpCodeDetail>(count);
                rows(slice(lines.View,1), dst);
                return dst;
            }
        }
    }
}