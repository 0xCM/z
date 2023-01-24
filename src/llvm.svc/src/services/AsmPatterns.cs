//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static sys;

    public readonly struct AsmPatterns
    {
        public static AsmVariationCode varcode(string inst, AsmMnemonic monic)
        {
            var fmt = monic.Format(MnemonicCase.Uppercase);
            if(text.empty(inst) || text.empty(fmt) || !text.contains(inst,fmt))
                return AsmVariationCode.Empty;
            var candidate = text.remove(inst,fmt);
            return text.nonempty(candidate) ? new AsmVariationCode(candidate) : AsmVariationCode.Empty;
        }

        public static LlvmAsmPattern extract(InstAliasEntity src)
        {
            var dst = LlvmAsmPattern.Empty;
            var name = src.InstName;
            var data = src.AsmStringSource;
            var input = normalize(data);
            dst = new LlvmAsmPattern(name, mnemonic(input), pattern(input), data);
            return dst;
        }

        public static LlvmAsmPattern extract(X86InstDef src)
        {
            var dst = LlvmAsmPattern.Empty;
            var name = src.InstName;
            if(src.isCodeGenOnly || src.isPseudo)
                return new LlvmAsmPattern(name, AsmMnemonic.Empty, EmptyString, EmptyString);

            var data = src.AsmStringSource;
            var input = normalize(data);
            dst = new LlvmAsmPattern(name, mnemonic(input), pattern(input), data);
            return dst;
        }

        static string normalize(string src)
            => text.trim(text.remove(text.replace(src, Chars.Tab, Chars.Space), Chars.Quote));

        static Replacements<string> PatternReplacements = SyntaxRules.replacements<string>(new Pair<string>[]{
            ("${mask}","$mask"),
            ("${src2}","$src2"),
            });

        static string replace(string src)
        {
            var dst = src;
            var rules = PatternReplacements.View;
            var count = rules.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var rule = ref skip(rules,i);
                dst = text.replace(dst, rule.Match, rule.Replace);
            }
            return dst;
        }

        static string pattern(string src)
        {
            var input = replace(src);
            var monic = mnemonic(input).Format();
            var i = text.index(input, Chars.Space);
            if(i == NotFound)
                return monic;
            else
            {
                var right = text.right(input,i);
                if(Fenced.test(right, Fenced.Embraced))
                    right = Fenced.unfence(right, 0, Fenced.Embraced);

                var j = text.index(right, Chars.Caret);
                if(j >= 0)
                    right = text.right(right,j);
                return string.Format("{0} {1}", monic, right);
            }
        }

        static AsmMnemonic mnemonic(string src)
        {
            var input = normalize(src);
            var i = text.index(input, Chars.Space);
            if(i == NotFound)
                return input;

            var dst = text.left(input,i);
            var j = text.index(dst, Chars.LBrace);
            if(j>0)
                dst = text.left(dst,j);

            return dst;
        }
    }
}