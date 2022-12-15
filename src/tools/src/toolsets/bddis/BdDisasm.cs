//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using N = ToolNames;

    [ApiHost]
    public sealed class BdDisasm : Tool<BdDisasm>
    {
        [Op]
        public static uint render(Bitness src, ref uint i, Span<char> dst)
        {
            const string B16 = "b16";
            const string B32 = "b32";
            const string B64 = "b64";
            var i0 = i;
            var b = EmptyString;
            switch(src)
            {
                case Bitness.b16:
                    b = B16;
                break;
                case Bitness.b32:
                    b = B32;
                break;
                case Bitness.b64:
                    b = B64;
                break;
            }

            if(nonempty(b))
                text.copy(b, ref i, dst);

            return i - i0;
        }

        [Op]
        public static uint render(BdDisasmCmd src, ref uint i, Span<char> dst)
        {
            var i0 = i;

            const char Specifier = Chars.Dash;
            const string Bits = "bits";
            const string Exi = "exi";

            var tool = src.ToolPath.Format(PathSeparator.BS);
            text.copy(tool, ref i, dst);

            seek(dst,i++) = Chars.Space;
            seek(dst,i++) = Specifier;
            render(src.AsmBitMode, ref i, dst);

            seek(dst,i++) = Chars.Space;
            seek(dst,i++) = Specifier;
            seek(dst,i++) = Chars.f;
            seek(dst,i++) = Chars.Space;
            text.copy(src.BinPath.Format(PathSeparator.BS), ref i, dst);

            if(src.EmitBitfields)
            {
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = Specifier;
                text.copy(Bits, ref i, dst);
            }

            if(src.EmitDetails)
            {
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = Specifier;
                text.copy(Exi, ref i, dst);
            }

            return i - i0;
        }

        public BdDisasm()
            : base(N.bddisasm)
        {

        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }

}