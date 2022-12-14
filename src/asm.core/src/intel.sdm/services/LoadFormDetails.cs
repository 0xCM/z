//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public Index<SdmFormDetail> LoadFormDetails()
        {
            const byte FieldCount = SdmFormDetail.FieldCount;
            var result = Outcome.Success;
            var buffer = list<SdmFormDetail>();
            var path = SdmPaths.FormDetailDst();
            using var reader = path.Utf8LineReader();
            reader.Next(out _);
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var src = line.Cells(Chars.Pipe, SdmFormDetail.FieldCount).Reader();
                var dst = new SdmFormDetail();
                Throw.OnError(DataParser.parse(src.Next(), out dst.Seq));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Id));
                Throw.OnError(DataParser.asci(src.Next(), n64, out dst.Name));
                Throw.OnError(AsmSigs.parse(src.Next(), out dst.Sig));
                Throw.OnError(SdmOpCodes.parse(src.Next(), out dst.OpCode));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Mode64));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Mode32));
                Throw.OnError(DataParser.parse(src.Next(), out dst.IsRex));
                Throw.OnError(DataParser.parse(src.Next(), out dst.IsEvex));
                Throw.OnError(DataParser.parse(src.Next(), out dst.Description));
                buffer.Add(dst);
            }

            return buffer.ToArray();
        }
    }
}