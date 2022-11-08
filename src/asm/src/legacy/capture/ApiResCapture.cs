//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public sealed class ApiResCapture : AppService<ApiResCapture>
    {
        AsmDecoder Decoder;

        AsmFormatConfig FormatConfig;

        protected override void Initialized()
        {
            Decoder = Wf.AsmDecoder();
            FormatConfig = AsmFormatConfig.@default(out var _);
        }

        public void Emit(ReadOnlySpan<CapturedApiRes> src, FilePath dst)
        {
            const ulong Cut = 0x55005500550;
            const string Sep = RpOps.SpacePipe;
            const string StartMsg = "Emitting captured resource disassembly";
            const string Col0 = "Addresses";
            const string Col1 = "Accessor";
            const ushort Col0Width = 16;

            var capcount = src.Length;
            using var writer = dst.Writer();
            writer.WriteLine(text.concat(Col0.PadRight(Col0Width), Sep, Col1));

            for(var i=0u; i<capcount; i++)
            {
                ref readonly var captured = ref skip(src, i);
                var code = captured.Code;
                var host = captured.ApiHost;
                var accessor = captured.Accessor;
                var uri = ApiIdentity.hex(host, accessor.OpName, code.Code.MemberId);
                var movements = moves(code.Routine);
                var movecount = movements.Length;
                for(var j=0u; j<movecount; j++)
                {
                    ref readonly var move = ref skip(movements,j);
                    if(move.Source < Cut)
                        writer.WriteLine(text.concat(move.Source.ToAddress().Format().PadRight(Col0Width), Sep, uri));
                }
            }
        }

        Option<AsmRoutineCode> DecodeRoutine(ApiCaptureBlock capture)
        {
            var decoded = Decoder.Decode(capture);
            if(decoded)
            {
                return new AsmRoutineCode(decoded.Value, capture, AsmFormatter.format(decoded.Value, FormatConfig));
            }
            else
                return Option.none<AsmRoutineCode>();
        }

        static ReadOnlySpan<Arrow<Imm64,IceRegister>> moves(in AsmRoutine src, int capacity = 10)
        {
            var hander = new AsmMovHandler(capacity);
            var fx = src.Instructions.View;
            var count = fx.Length;
            for(var i=0u; i<count; i++)
                hander.Handle(skip(fx, i).Instruction);
            return hander.Collected;
        }
    }
}