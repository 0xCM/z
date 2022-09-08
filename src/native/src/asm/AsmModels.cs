//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmModels : AppService<AsmModels>
    {
        static EnumRender<AsmSigTokenKind> SigTokenRender = new();

        static EnumParser<AsmSigTokenKind> SigTokenParser = new();

        static EnumRender<AsmModifierKind> ModKindRender = new();

        static EnumParser<AsmModifierKind> ModKindParse = new();

        public static string format(AsmModifierKind src)
            => ModKindRender.Format(src);

        public static bool parse(string src, out AsmModifierKind dst)
            => ModKindParse.Parse(src, out dst);

        public static string format(AsmSigTokenKind src)
            => SigTokenRender.Format(src);

        public static bool parse(string src, out AsmSigTokenKind dst)
            => SigTokenParser.Parse(src, out dst);
    }
}