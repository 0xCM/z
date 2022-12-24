//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules.SyntaxLiterals;

    using RF = XedRules.RuleFormKind;

    partial class XedRules
    {
        partial struct CellParser
        {
            public static Index<RuleSeq> ruleseq()
                => ruleseq(XedPaths.Service.DocSource(XedDocKind.RuleSeq));

            public static Index<RuleSeq> ruleseq(FilePath src)
                => ruleseq(src.ReadNumberedLines());

            static public Index<RuleSeq> ruleseq(ReadOnlySpan<TextLine> src)
            {
                var count = src.Length;
                var buffer = list<RuleSeq>();
                var terms = list<RuleSeqTerm>();
                var result = Outcome.Success;
                for(var j=0u; j<count; j++)
                {
                    ref readonly var line = ref skip(src,j);
                    if(line.IsEmpty)
                        continue;

                    var form = RuleForm(line.Content);
                    if(form == RuleFormKind.SeqDecl)
                    {
                        var content = text.despace(line.Content);
                        var i = text.index(content, Chars.Space);
                        var name = text.right(content, i);
                        terms.Clear();
                        j++;

                        if(parse(src, ref j, terms) != 0)
                        {
                            buffer.Add(new RuleSeq(name, terms.ToArray()));
                            terms.Clear();
                            content = text.despace(skip(src,j).Content);
                            if(IsSeqDecl(content))
                            {
                                i = text.index(content, Chars.Space);
                                name = text.right(content, i);
                                parse(name, src, ref j, buffer);
                            }
                        }
                    }
                }
                return buffer.ToArray();
            }

            static void parse(Identifier name, ReadOnlySpan<TextLine> src, ref uint j, List<RuleSeq> dst)
            {
                var content = text.despace(skip(src,j).Content);
                var terms = list<RuleSeqTerm>();
                if(parse(src, ref j, terms) != 0)
                {
                    dst.Add(new RuleSeq(name, terms.ToArray()));
                    content = text.despace(skip(src,j).Content);
                    if(IsSeqDecl(content))
                    {
                        var i = text.index(content, Chars.Space);
                        name = text.right(content, i);
                        parse(name, src, ref j, dst);
                    }
                }
            }

            static bool IsSeqDecl(string src)
                => src.StartsWith(SeqDeclSyntax);

            static uint parse(ReadOnlySpan<TextLine> src, ref uint j, List<RuleSeqTerm> terms)
            {
                var i0 = j;
                for(;j<src.Length; j++)
                {
                    ref readonly var line = ref skip(src,j);
                    if(line.IsEmpty)
                        break;

                    if(!text.begins(line.Content, "   "))
                        break;

                    var content = line.Content.Trim();
                    if(text.begins(content, Chars.Hash))
                        continue;

                    var q = text.index(content, Chars.Hash);
                    if(q > 0)
                        content = text.left(content, q);

                    if(IsNonterm(content))
                    {
                        var k = text.index(content, CallSyntax);
                        terms.Add(new RuleSeqTerm(text.left(content,k), IsNonterm(content)));
                    }
                    else
                        terms.Add(new RuleSeqTerm(content, false));
                }
                return (uint)terms.Count;
            }

            static bool IsNonterm(string src)
                => text.trim(text.remove(src,Chars.Colon)).EndsWith("()");

            public static bool IsTableDecl(string src)
                => src.EndsWith(TableDeclSyntax);

            public static bool IsEncStep(string src)
                => src.Contains(EncStep);

            public static bool IsDecStep(string src)
                => src.Contains(DecStep);

            public static RF RuleForm(string src)
            {
                var i = text.index(src, Chars.Hash);
                var content = (i> 0 ? text.left(src,i) : src).Trim();
                if(IsTableDecl(content))
                    return RF.RuleDecl;
                if(IsEncStep(content))
                    return RF.EncodeStep;
                if(IsDecStep(content))
                    return RF.DecodeStep;
                if(IsNonterm(content))
                    return RF.Invocation;
                if(IsSeqDecl(content))
                    return RF.SeqDecl;
                return 0;
            }
        }
    }
}