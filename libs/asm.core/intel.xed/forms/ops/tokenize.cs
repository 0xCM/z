//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using TK = XedForms.FormTokenKind;

    partial class XedForms
    {
        public static FormSyntax tokenize(InstForm src)
        {
            var dst = FormSyntax.Empty;
            var parts = src.Format().Split(Chars.Underscore);
            var count = parts.Length;
            if(count == 0)
                return dst;

            var k=0u;
            var j=0u;
            var tokens = alloc<FormToken>(count);
            var @class = FormToken.Empty;

            if(first(parts).StartsWith("REP"))
            {
                var rep = FormToken.Empty;
                if(match(skip(parts,j++), TokenData.Tokens(TK.Rep), out rep))
                    seek(tokens,k++) = rep;
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FormToken), skip(parts,j-1)));

                if(count > 1)
                {
                    if(match(TK.InstClass, skip(parts,j++), out @class))
                        seek(tokens, k++) = @class;
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FormToken), skip(parts,j-1)));
                }
            }
            else
            {
                if(match(TK.InstClass, skip(parts,j++), out @class))
                    seek(tokens, k++) = @class;
            }

            for(var i=k; i<count; i++, j++)
            {
                ref readonly var part = ref skip(parts,j);
            }

            return dst;
        }
    }
}