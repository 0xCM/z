//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        internal partial class DisasmParse
        {
            internal const string XDIS = "XDIS ";

            internal const string YDIS = "YDIS:";

            public static Outcome parse(string src, out MemoryAddress dst)
            {
                var result = Outcome.Failure;
                var i = text.index(src, XDIS);
                var j = XDIS.Length;
                var k = text.index(src, Chars.Colon);
                var length = k-j;
                dst = 0;
                if(j >= 0 && length > 0)
                    result = DataParser.parse(text.slice(src,j,length).Trim(), out dst);
                return result;
            }

            public static Outcome parse(string src, out AsmHexCode dst)
            {
                var result = Outcome.Failure;
                dst = AsmHexCode.Empty;
                var buffer = span<byte>(16);

                if(src.StartsWith(XDIS))
                {
                    var k = text.index(src, Chars.Colon);
                    if(k > 0)
                    {
                        var parts = text.words(text.right(src,k));
                        if(parts.Length >=3)
                        {
                            var count = Hex.parse(parts[2], buffer);
                            if(count)
                            {
                                dst = slice(buffer,0,count).ToArray();
                                result = Outcome.Success;
                            }
                        }
                    }
                }

                return result;
            }

            internal static Outcome parse(in DisasmBlock src, out AmsInstClass dst)
            {
                var result = Outcome.Success;
                dst = AmsInstClass.Empty;
                ref readonly var content = ref src.Props.Content;
                if(text.nonempty(content))
                {
                    var j = text.index(content, Chars.Space);
                    if(j > 0)
                    {
                        var expr = text.left(content,j);
                        if(!XedParsers.parse(expr, out dst))
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(AmsInstClass), content));
                            return result;
                        }
                    }
                }
                return result;
            }

            internal static Outcome parse(in DisasmBlock src, out InstForm dst)
            {
                var result = Outcome.Success;
                dst = InstForm.Empty;
                ref readonly var content = ref src.Props.Content;
                if(text.nonempty(content))
                {
                    var j = text.index(content, Chars.Space);
                    if(j > 0)
                    {
                        var expr = text.left(content,j);
                        var k = text.index(content, j+1, Chars.Space);
                        if(k > 0)
                        {
                            expr = text.inside(content, j, k);
                            if(!XedParsers.parse(expr, out dst))
                            {
                                result = (false, AppMsg.ParseFailure.Format(nameof(InstForm), expr));
                                return result;
                            }
                        }
                    }
                }
                return result;
            }

            internal static void parse(in DisasmBlock src, out AmsInstClass @class, out InstForm form)
            {
                var content = text.trim(text.split(text.despace(src.Props.Content), Chars.Space));
                XedParsers.parse(skip(content,0), out @class);
                if(!XedParsers.parse(skip(content,1), out form))
                {
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(InstForm), skip(content,1)));
                }
            }

            internal static Outcome parse(string src, out AsmInfo dst)
            {
                var result = Outcome.Success;
                dst = default;
                if(!text.contains(src,XDIS))
                    return (false, $"'{XDIS}' marker not found");

                var i = text.index(src,Chars.Colon);
                var left = text.left(src,i);
                var right = text.trim(text.despace(text.right(src,i)));
                var parts = right.Split(Chars.Space);
                Demand.gt(parts.Length,3);
                result = XedParsers.parse(skip(parts,0), out dst.Category);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.Category), skip(parts,0)));

                if(result)
                    result = XedParsers.parse(skip(parts,1), out dst.Extension);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.Extension), skip(parts,1)));

                ref readonly var enc = ref skip(parts,2);
                var j = text.index(right, enc);
                if(j>0)
                    dst.Asm = text.trim(text.right(right, j + enc.Length));

                if(result)
                    result = parse(src, out dst.IP);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.IP), src));

                if(result)
                    result = parse(src, out dst.Encoded);
                if(!result)
                    result = (false,AppMsg.ParseFailure.Format(nameof(dst.Encoded), src));

                return result;
            }
        }
    }
}