//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        string CalcOperands(ReadOnlySpan<char> sig)
        {
            var sigRules = SigNormalRules;

            ReadOnlySpan<string> _operands(string src)
                => text.trim(text.split(src, Chars.Comma)).Select(CalcOperand);

            var i = SQ.index(sig, Chars.Space);
            if(i > 0)
                return text.join(", ", _operands(text.format(SQ.right(sig,i))));
            else
                return EmptyString;

            string CalcOperand(string op)
            {
                var n = text.index(op, Chars.FSlash);
                var dst = op;
                if(Fenced.test(dst, Fenced.Angled))
                    dst = Fenced.unfence(dst, Fenced.Angled);

                if(n > 0)
                {
                    var m = text.index(dst, Chars.Space);
                    if(m > n)
                    {
                        var components = text.join(Chars.FSlash, text.trim(text.split(text.left(dst,m), Chars.FSlash)));
                        dst = string.Format("{0} {1}", components, text.right(dst,m));
                    }
                    else
                        dst = text.join(Chars.FSlash, text.trim(text.split(dst, Chars.FSlash)));
                }
                return sigRules.Apply(dst);
            }
        }
    }
}