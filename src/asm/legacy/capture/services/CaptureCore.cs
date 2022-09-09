//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static ExtractTermCode;

    unsafe sealed class CaptureCore : AppService<CaptureCore>, ICaptureCore
    {
        const string CaptureAddressMismatch = "The parsed address does not match the extration address";

        [MethodImpl(Inline)]
        static ApiCaptureResult capture(in CaptureExchange exchange, OpIdentity id, IntPtr src)
            => divine(exchange.Buffer, id, src.ToPointer<byte>());

        [Op]
        static ApiCaptureBlock capture(OpIdentity id, MethodInfo method, CodeBlock raw, CodeBlock parsed, ExtractTermCode term)
        {
            var dst = new ApiCaptureBlock();
            dst.Raw = raw;
            dst.Parsed = parsed;
            dst.Method = method;
            Require.invariant(raw.Address == parsed.Address, () => CaptureAddressMismatch);
            dst.OpUri = ApiIdentity.hex(method.DeclaringType.ApiHostUri(), method.Name, id);
            dst.TermCode = term;
            dst.Msil = ClrDynamic.msil(parsed.Address, dst.OpUri, method);
            dst.CliSig = Clr.sig(method);
            return dst;
        }

        public Option<ApiCaptureBlock> Capture(in CaptureExchange exchange, OpIdentity id, in DynamicDelegate src)
        {
            try
            {
                var pSrc = ClrJit.jit(src).Address;
                var summary = capture(exchange, id, pSrc);
                return capture(id, src.Source, summary.Pair.Raw, summary.Pair.Parsed, summary.TermCode);
            }
            catch(Exception e)
            {
                Error("Capture service failure");
                Error(e);
                return Option.none<ApiCaptureBlock>();
            }
        }

        [Op]
        public static unsafe ApiCaptureResult divine(Span<byte> dst, OpIdentity id, byte* pSrc)
        {
            var limit = dst.Length - 1;
            var start = (long)pSrc;
            var offset = 0;
            int? ret_offset = null;
            var end = (long)pSrc;
            var state = default(byte);

            while(offset < limit)
            {
                state = step(dst, id, ref offset, ref end, ref pSrc);
                if(ret_offset == null && state == RET)
                    ret_offset = offset;
                var tc = term(dst, offset, ret_offset, out var delta);
                if(tc != null)
                    return summarize(dst, id, tc.Value, start, end, delta);
            }
            return summarize(dst, id, CTC_BUFFER_OUT, start, end, 0);
        }

        [Op, MethodImpl(Inline)]
        static unsafe byte step(Span<byte> dst, OpIdentity id, ref int offset, ref long location, ref byte* pSrc)
        {
            var code = Unsafe.Read<byte>(pSrc++);
            dst[offset++] = code;
            location = (long)pSrc;
            return code;
        }

        [Op]
        static ExtractTermCode? term(Span<byte> src, int offset, int? ret_offset, out int delta)
        {
            delta = 0;

            if(offset >= 4)
            {
                var tc = scan4(src, offset, out delta);
                if(tc != null)
                    return tc;
            }

            if(offset >= 5)
            {
                var tc = scan5(src, offset, out delta);
                if(tc != null)
                    return tc;
            }

            if(offset >= 7 && z7(src, offset))
            {
                if(ret_offset == null)
                {
                    delta = -6;
                    return CTC_Zx7;
                }
                delta = -(offset - ret_offset.Value);
                return CTC_RET_Zx7;
            }

            return null;
        }

        [Op, MethodImpl(Inline)]
        static ExtractTermCode? scan4(Span<byte> src, int offset, out int delta)
        {
            var x0 = src[offset - 3];
            var x1 = src[offset - 2];
            var x2 = src[offset - 1];
            var x3 = src[offset - 0];
            delta = -2;

            if(match((x0,RET), (x1, SBB)))
                return CTC_RET_SBB;
            else if(match((x0, RET), (x1, INTR)))
                return CTC_RET_INTR;
            else if(match((x0, RET), (x1, ZED), (x2, SBB)))
                return CTC_RET_ZED_SBB;
            else if(match((x0, RET), (x1, ZED), (x2, ZED)))
                return CTC_RET_Zx3;
            else if(match((x0,INTR), (x1, INTR)))
                return CTC_INTRx2;
            else
                return null;
        }

        [Op, MethodImpl(Inline)]
        static ExtractTermCode? scan5(Span<byte> src, int offset, out int delta)
        {
            var x0 = src[offset - 5];
            var x1 = src[offset - 4];
            var x2 = src[offset - 3];
            var x3 = src[offset - 2];
            var x4 = src[offset - 1];
            delta = 0;

            if(match((x0,ZED), (x1,ZED), (x2,J48), (x3,FF), (x4,E0)))
                return CTC_JMP_RAX;
            else
                return null;
        }

        [Op, MethodImpl(Inline)]
        static bool z7(Span<byte> src, int offset)
            =>      src[offset - 6] == ZED
                && (src[offset - 5] == ZED)
                && (src[offset - 4] == ZED)
                && (src[offset - 3] == ZED)
                && (src[offset - 2] == ZED)
                && (src[offset - 1] == ZED)
                && (src[offset - 0] == ZED);


        [Op, MethodImpl(Inline)]
        static bit match((byte x, byte y) a, (byte x, byte y) b)
            => a.x == a.y
            && b.x == b.y;

        [Op, MethodImpl(Inline)]
        static bit match((byte x, byte y) a, (byte x, byte y) b, (byte x, byte y) c)
            => a.x == a.y
            && b.x == b.y
            && c.x == c.y;

        [Op, MethodImpl(Inline)]
        static bit match((byte x, byte y) a, (byte x, byte y) b, (byte x, byte y) c, (byte x, byte y) d, (byte x, byte y) e)
            => a.x == a.y
            && b.x == b.y
            && c.x == c.y
            && d.x == d.y
            && e.x == e.y;

        [Op, MethodImpl(Inline)]
        static ApiCaptureResult summarize(Span<byte> src, OpIdentity id, ExtractTermCode tc, long start, long end, int delta)
        {
            var outcome = CaptureOutcome.create(tc, start, end, delta);
            var raw = src.Slice(0, (int)(end - start)).ToArray();
            var trimmed = src.Slice(0, outcome.ByteCount).ToArray();
            return ApiCaptureResult.create(id, outcome.TermCode, outcome.Range, CodeBlockPair.create((MemoryAddress)start, raw, trimmed));
        }

        const byte ZED = 0;

        const byte RET = 0xc3;

        const byte INTR = 0xcc;

        const byte SBB = 0x19;

        const byte FF = 0xff;

        const byte E0 = 0xe0;

        const byte J48 = 0x48;
    }
}