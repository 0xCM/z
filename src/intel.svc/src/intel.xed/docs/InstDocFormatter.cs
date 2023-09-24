//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static Markdown;

    partial class XedDocs
    {
        static SectionHeader TableHeader(RuleSig sig)
            => new(3, sig.Format());

        public class InstDocFormatter
        {
            readonly InstDoc Doc;

            XedInstClass Classifier;

            AsmOpCode OpCode;

            XedPaths XedPaths;

            public InstDocFormatter(InstDoc doc)
            {
                Classifier = XedInstClass.Empty;
                OpCode = AsmOpCode.Empty;
                Doc = doc;
                XedPaths = XedPaths.Service;
            }

            static SectionHeader FormHeader(in InstDocPart part)
                => new(4, string.Format("{0} {1}", part.OpCode, part.InstForm));

            static SectionHeader ClassHeader(in InstDocPart part)
                => new(3, part.Classifier.Format());

            AbsoluteLink Link(RuleSig key)
                => Markdown.link(key.TableName.ToString() + "()", XedPaths.CheckedRulePage(key));

            static void RenderSigHeader(in InstDocPart part, ITextBuffer dst)
            {
                var title = new SectionHeader(5, part.Classifier.Format().ToLower());
                dst.Append(title.Format());

                for(var k=0; k<part.OpNames.Count; k++)
                {
                    if(k!=0)
                        dst.Append(Chars.Comma);
                    dst.Append(Chars.Space);
                    dst.Append(part.OpNames[k].Indicator.Format());
                }
                dst.AppendLine();
            }

            void Render(in InstDocPart part, ITextBuffer dst)
            {
                if(part.Classifier != Classifier)
                {
                    Classifier = part.Classifier;
                    dst.AppendLine(ClassHeader(part));
                    dst.AppendLine();
                }

                if(part.OpCode != OpCode)
                {
                    OpCode = part.OpCode;
                    dst.AppendLine(FormHeader(part));
                    dst.AppendLine();
                }

                RenderSigHeader(part,dst);
                dst.AppendLine();

                dst.AppendFormat("{0} |", Classifier);

                if(part.Layout.IsNonEmpty)
                    dst.AppendFormat(" {0}", part.Layout);
                if(part.Expr.IsNonEmpty)
                    dst.AppendFormat(" <{0}>", part.Expr);
                dst.AppendLine();

                ref readonly var ops = ref part.Ops;
                for(var k=0; k<ops.Count; k++)
                {
                    ref readonly var op = ref ops[k];
                    var attribs = op.Attribs;
                    dst.AppendFormat("{0,-2}", op.Index);
                    dst.AppendFormat("{0,-8}", op.Name);
                    if(op.Action(out var action))
                        dst.AppendFormat("{0,-3}", XedRender.format(action));
                    if(op.Visibility(out var opvis))
                        dst.AppendFormat("{0} ", opvis.Code());
                    else
                        dst.AppendFormat("{0} ", Visibility.Explicit.Code());

                    dst.Append(InstRender.descriptor(part.Mode, op));

                    if(op.Nonterminal(out var nt))
                    {
                        var uri = XedPaths.CheckedTableDef(nt.Name, true, out var sig);
                        if(uri.Exists)
                            dst.Append(Link(sig).Format());
                    }

                    dst.AppendLine();
                }
                dst.AppendLine();
            }

            public string Format()
            {
                var doc = Doc;
                var dst = text.buffer();
                dst.AppendLine(header(1, "Xed Instructions"));
                dst.AppendLine();
                dst.AppendLine(header(2,"Patterns"));
                dst.AppendLine();
                for(var i=0; i<doc.Parts.Count; i++)
                    Render(doc[i],dst);

                return dst.Emit();
            }
        }
    }
}