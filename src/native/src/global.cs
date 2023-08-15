//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.literals;
global using static global.sys;
global using static global.native;
namespace global
{
    using static Z0.sys;
    using asm = Z0.Asm.asm;
    using static ApiAtomic;

    [ApiComplete(ApiName)]
    public partial class native
    {
        public const string ApiName = globals + dot + nameof(native);

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AsmHexCode dst)
            => asm.parse(src, out dst);

        [Op]
        public static byte render(AsmHexCode src, Span<char> dst)
            => (byte)HexRender.render(LowerCase, src.Bytes, dst);

        [Op]
        public static string format(in AsmHexCode src)
            => asm.format(src);

        [Op]
        public static AsmHexCode asmhex(string src)
        {
            var dst = AsmHexCode.Empty;
            parse(src.Trim(), out dst);
            return dst;
        }
    }
}