//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules.SyntaxLiterals;
using static XedModels;

using RF = XedRules.RuleFormKind;

partial class XedRules
{
    [ApiHost("xed.cellparser"),Free]
    public class CellParser
    {
        public static Index<RuleSeq> ruleseq()
            => ruleseq(XedPaths.DocSource(XedDocKind.RuleSeq));

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
            
        public static bool expr(string src, out CellExpr dst)
        {
            dst = CellExpr.Empty;
            Require.invariant(XedParsers.IsExpr(src));

            var i = text.index(src, "!=");
            var j = text.index(src, "=");
            var right = EmptyString;
            var left = EmptyString;
            var fv = FieldValue.Empty;
            var fk = FieldKind.INVALID;
            RuleOperator op = OperatorKind.None;
            if(i > 0)
            {
                right = text.right(src, i + 1);
                op = OperatorKind.Ne;
                left = text.left(src,i);
            }
            else if (j>0)
            {
                right = text.right(src, j);
                op = OperatorKind.Eq;
                left = text.left(src,j);
            }

            Require.nonempty(left);
            Require.nonempty(right);
            if(XedParsers.IsSeg(left))
            {
                var k = text.index(left, Chars.LBracket);
                var q = text.index(left, Chars.RBracket);
                var ft = text.inside(left, k, q);
                left = text.left(left, k);
                XedParsers.parse(left, out fk);
                if(fk == 0)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), left));

                var type = InstSegTypes.type(ft);
                if(type.IsEmpty)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(InstSegType), ft));

                dst = new CellExpr(op, new FieldValue(fk, type));
            }
            else if(XedParsers.IsNonterm(right))
            {
                XedParsers.parse(left, out fk);
                if(fk == 0)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), left));

                var k = text.index(right, Chars.LParen);
                var name = text.left(right, k);
                var result = Enum.TryParse(name, out RuleName rule);
                if(!result)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleName), name));

                dst = new CellExpr(op, new FieldValue(fk, rule));
            }
            else
            {
                XedParsers.parse(left, out fk);
                if(fk == 0)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), left));

                var result = XedParsers.parse(fk, right, out fv);
                if(!result)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellExpr), src));

                dst = new CellExpr(op, fv);
            }

            return true;
        }
            
        public static Outcome parse(string src, out InstFieldSeg dst)
        {
            var result = Outcome.Success;
            dst = InstFieldSeg.Empty;
            var i = text.index(src, Chars.LBracket);
            var j = text.index(src, Chars.RBracket);
            result = i>0 && j>i;
            if(result)
            {
                result = XedParsers.parse(text.left(src,i), out FieldKind field);
                if(!result)
                    return false;

                result = XedParsers.segdata(src, out var data);
                if(!result)
                    return result;

                var literal = XedParsers.IsBinaryLiteral(data);
                if(!literal)
                {
                    var type = InstSegTypes.type(data);
                    if(type.IsNonEmpty)
                    {
                        dst = new (field, type);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    result = XedParsers.bitnumber(data, out byte n, out byte value);
                    if(result)
                        dst = new (field, BitNumber.generic(n, value));
                }
            }

            return result;
        }
    }
}
