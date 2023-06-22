//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;
    using static XedPatterns;

    using P = XedRules.InstPartKind;

    partial class XedRules
    {
        public struct InstDefParser
        {
            public static Index<InstDef> parse(FilePath src)
            {
                const string LogPattern = "{0,-8} | {1,-8} | {2,-10} | {3}";

                var buffer = list<InstDef>();
                var reader = src.ReadNumberedLines().Select(cleanse).Where(line => line.IsNonEmpty).Reader();
                var seq = 0u;
                var forms = dict<uint,XedInstForm>();
                var @class = XedInstClass.Empty;
                var category = InstCategory.Empty;
                var isa = InstIsa.Empty;
                var ext = Extension.Empty;
                var attribs = InstAttribs.Empty;
                var effects = Index<XedFlagEffect>.Empty;
                while(reader.Next(out var line))
                {
                    if(line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                        continue;

                    if(line.StartsWith(Chars.LBrace))
                    {
                        var dst = default(InstDef);
                        var rawbody = EmptyString;
                        var specs = list<InstPatternSpec>();
                        while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                        {
                            if(split(line, out var name, out var value))
                            {
                                if(empty(value))
                                    continue;

                                if(parse(name, out InstPartKind part))
                                {
                                    switch(part)
                                    {
                                        case P.Form:
                                            if(XedParsers.parse(value, out XedInstForm form))
                                                forms.TryAdd(seq, form);
                                        break;
                                        case P.Attributes:
                                            attribs = XedPatterns.attributes(text.despace(value));
                                        break;
                                        case P.Category:
                                            if(XedParsers.parse(text.despace(value), out InstCategory _category))
                                                category = _category;
                                        break;
                                        case P.Extension:
                                            if(XedParsers.parse(text.despace(value), out Extension _ext))
                                                ext = _ext;
                                        break;
                                        case P.Flags:
                                            XedParsers.parse(text.despace(value), out effects);
                                        break;
                                        case P.Class:
                                        {
                                            if(XedParsers.parse(text.despace(value), out XedInstClass _class))
                                            {
                                                if(_class != @class)
                                                {
                                                    Require.nonzero(_class.Kind);
                                                    category = InstCategory.Empty;
                                                    isa = InstIsa.Empty;
                                                    ext = Extension.Empty;
                                                    attribs = InstAttribs.Empty;
                                                    effects = Index<XedFlagEffect>.Empty;
                                                    form = XedInstForm.Empty;
                                                }
                                                @class = _class;
                                                dst.InstClass = _class;
                                            }
                                        }
                                        break;
                                        case P.Isa:
                                            XedParsers.parse(text.despace(value), out isa);
                                        break;
                                        case P.Operands:
                                        {
                                            var j = text.index(line.Content, Chars.BSlash);
                                            if(j > 0)
                                            {
                                                var result = text.left(line.Content, j);
                                                while(reader.Next(out var x))
                                                {
                                                    j = text.index(x.Content, Chars.BSlash);

                                                    if(j > 0)
                                                    {
                                                        var y = text.left(x.Content,j).Trim();
                                                        result = string.Format("{0} {1}", result, y);
                                                    }
                                                    else
                                                    {
                                                        var y = x.Content.Trim();
                                                        value = string.Format("{0} {1}", result, y);
                                                        break;
                                                    }
                                                }
                                            }

                                            var opexpr = text.trim(text.remove(value,"OPERANDS"));
                                            var spec = InstPatternSpec.Empty;
                                            spec.Seq = seq;
                                            spec.InstClass = @class;
                                            spec.Attributes = attribs;
                                            spec.Effects = effects;
                                            spec.Category = category;
                                            spec.Extension = ext;
                                            spec.Isa = isa;
                                            InstPatternSpec.FixIsa(ref spec);
                                            spec.RawBody = rawbody;
                                            InstParser.parse(rawbody, out spec.Body);
                                            spec.Mode = InstCells.mode(spec.Body.Cells);
                                            PatternOpParser.parse(spec.Seq, opexpr, out spec.Ops);
                                            spec.OpCode = InstCells.opcode(spec.Body.Cells);
                                            specs.Add(spec);
                                        }
                                        break;
                                        case P.Pattern:
                                            rawbody = value;
                                            seq++;
                                        break;
                                        case P.Comment:
                                            break;
                                    }
                                }
                            }
                        }

                        dst.PatternSpecs = specs.Array().Sort();
                        buffer.Add(dst);
                    }
                }

                var defs = buffer.ToArray().Sort();
                var pid = 0u;
                for(var i=0u; i<defs.Length; i++)
                {
                    ref var def = ref seek(defs,i);
                    ref var specs = ref def.PatternSpecs;
                    for(var j=0; j<specs.Count; j++, pid++)
                    {
                        ref var spec = ref specs[j];
                        forms.TryGetValue(spec.Seq, out spec.InstForm);
                        spec.Seq = pid;
                        spec.Ops = new (pid, spec.Ops);
                        for(var k=0; k<spec.Ops.Count; k++)
                            spec.Ops[k].PatternId = pid;
                    }
                }

                return defs;
            }

            static Index<InstPartKind,string> PartKindNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};

            static bool parse(string src, out InstPartKind kind)
            {
                var result = false;
                kind = default;
                for(var i=0; i<PartKindNames.Count; i++)
                {
                    var p = (InstPartKind)i;
                    if(PartKindNames[p] == src)
                    {
                        kind = p;
                        result = true;
                        break;
                    }
                }
                return result;
            }

            static TextLine cleanse(TextLine src)
            {
                var dst = text.trim(src.Content);
                var i = text.index(dst, Chars.Hash);
                if(i==0)
                    return TextLine.Empty;

                if(i > 0)
                    dst = text.left(dst,i);
                return new TextLine(src.LineNumber, text.trim(dst));
            }

            static bool split(TextLine line, out string name, out string value)
            {
                var input = line;
                var i = text.index(input.Content, Chars.Colon);
                if(i>0)
                {
                    name = text.trim(text.left(input.Content, i));
                    value = text.trim(text.right(input.Content, i));
                }
                else
                {
                    name = EmptyString;
                    value = EmptyString;
                }
                return i > 0;
            }

            const string ICLASS = nameof(ICLASS);

            const string IFORM = nameof(IFORM);

            const string ATTRIBUTES = nameof(ATTRIBUTES);

            const string CATEGORY = nameof(CATEGORY);

            const string EXTENSION = nameof(EXTENSION);

            const string FLAGS = nameof(FLAGS);

            const string PATTERN = nameof(PATTERN);

            const string OPERANDS = nameof(OPERANDS);

            const string ISA_SET = nameof(ISA_SET);

            const string COMMENT = nameof(COMMENT);
        }
    }
}