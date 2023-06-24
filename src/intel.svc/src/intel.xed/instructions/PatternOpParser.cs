//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static sys;

    using K = XedModels.OpKind;

    partial class XedPatterns
    {
        public readonly struct PatternOpParser
        {
            [Parser]
            public static bool parse(string src, ref PatternOp dst)
            {
                dst.SourceExpr = src;
                var i = text.index(src,Chars.Colon, Chars.Eq);
                var right = text.right(src,i);
                if(opexpr(src, out dst.Name, out var expr))
                {
                    var kind = XedOps.opkind(dst.Name);
                    Parse(expr, text.split(right, Chars.Colon).Where(text.nonempty), kind, ref dst);
                    return true;
                }
                else
                    return false;
            }

            public static void parse(uint pattern, string ops, out PatternOps dst)
                => dst = parse(pattern, ops);

            static PatternOps parse(uint pattern, string ops)
            {
                var buffer = list<PatternOp>();
                var input = text.trim(text.despace(ops));
                var i = text.index(input,Chars.Hash);
                if(i > 0)
                    input = text.left(input,i);
                i = text.index(input,Chars.Colon);
                if(i==0)
                    input = text.trim(text.right(input,i));

                var index = z8;
                var parts = (input.Contains(Chars.Space) ? text.split(input, Chars.Space) : new string[]{input}).Where(text.nonempty);
                for(var j=z8; j<parts.Length; j++)
                {
                    var spec = PatternOp.Empty;
                    ref readonly var part = ref skip(parts,j);
                    if(!parse(part, ref spec))
                    {
                        if(DataParser.eparse(part, out EMX_BROADCAST_KIND bck))
                        {
                            spec.Kind = OpKind.Bcast;
                            spec.SourceExpr = Xed.broadcast((BCastKind)bck).Symbol.Format();
                        }
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(part, nameof(PatternOp)));
                    }
                    if(spec.IsNonEmpty)
                    {
                        spec.PatternId = pattern;
                        spec.Index = index++;
                        buffer.Add(spec);
                    }
                    else
                        break;
                }

                return new(pattern,buffer.ToArray());
            }

            static bool opexpr(string src, out OpName name, out string expr)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon);
                var j = text.index(input, Chars.Eq);
                var index = -1;
                if(i > 0 && j > 0)
                    index = i < j ? i : j;
                else if(i>0 && j<0)
                    index = i;
                else if(j>0 && i<0)
                    index = j;

                var left = text.left(input, index);
                expr = text.right(input,index);
                return XedParsers.parse(left, out name);
            }

            static void Parse(string expr, string[] props, OpKind opkind, ref PatternOp dst)
            {
                dst.Kind = opkind;
                switch(opkind)
                {
                    case K.Agen:
                        ParseMem(expr, props, ref dst);
                    break;

                    case K.Base:
                        ParseReg(expr, props, ref dst);
                    break;

                    case K.Disp:
                        dst.Attribs = sys.empty<OpAttrib>();
                    break;

                    case K.Index:
                        ParseReg(expr, props, ref dst);
                    break;

                    case K.Imm:
                        ParseImm(expr, props, ref dst);
                    break;

                    case K.Mem:
                        ParseMem(expr, props, ref dst);
                    break;

                    case K.Ptr:
                        dst.Kind = K.Ptr;
                        ParsePtr(expr, props, ref dst);
                    break;

                    case K.Reg:
                        ParseReg(expr, props, ref dst);
                    break;

                    case K.RelBr:
                        dst.Kind = K.RelBr;
                        ParseRelBr(expr, props, ref dst);
                    break;

                    case K.Seg:
                        ParseReg(expr, props, ref dst);
                    break;

                    case K.Scale:
                        ParseScale(expr, props, ref dst);
                    break;

                    default:
                        Errors.Throw(string.Format("Unhandled:{0}", dst.Name));
                    break;
                 }
            }

            static void ParsePtr(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                var action = OpAction.None;
                var width = XedWidthCode.INVALID;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out width))
                        seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            static void ParseRelBr(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                var action = OpAction.None;
                var width = XedWidthCode.INVALID;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out width))
                        seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            static void ParseScale(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                var action = OpAction.None;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(byte.TryParse(props[0], out var value))
                        seek(buffer,i++) = (MemoryScale)value;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out action))
                        seek(buffer,i++) = action;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            static void ParseImm(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                var type = ElementType.Empty;
                var action = OpAction.None;
                var width = XedWidthCode.INVALID;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out action))
                        seek(buffer,i++) = action;
                }

                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out type))
                        seek(buffer,i++) = type;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            static void ParseMem(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                Span<OpAttrib> buffer = stackalloc OpAttrib[6];
                var i=0;
                var k=0;
                var width = XedWidthCode.INVALID;
                var action = OpAction.None;
                var vis = OpVisibility.None;
                var type = ElementType.Empty;

                if(count >= 1)
                {
                    ref readonly var p = ref props[k++];
                    if(XedParsers.parse(p, out action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    ref readonly var p = ref props[k++];
                    if(XedParsers.parse(p, out vis))
                        seek(buffer,i++) = vis;
                    else if(XedParsers.parse(p, out width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    ref readonly var p = ref props[k++];
                    if(width != 0)
                    {
                        if(XedParsers.parse(p, out type))
                             seek(buffer,i++) = type;
                    }
                    else if(XedParsers.parse(p, out width))
                         seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            static void reg(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                var result = Outcome.Success;
                var width = XedWidthCode.INVALID;
                var type = ElementType.Empty;
                var vis = OpVisibility.None;
                var action = OpAction.None;

                Span<OpAttrib> buffer = stackalloc OpAttrib[8];
                var i=0;
                var k=0;
                ref var p = ref props[k];
                switch(count)
                {
                    case 5:
                    // [0:reg, 1:action, 2:vis, 3:widthcode, 4:etype]
                    p = props[k++];
                    result = XedParsers.reg(p, out seek(buffer,i++));

                    p = props[k++];
                    if(XedParsers.parse(p, out action))
                        seek(buffer,i++) = action;

                    p = props[k++];
                    if (XedParsers.parse(p, out vis))
                        seek(buffer,i++) = vis;

                    p = props[k++];
                    if(XedParsers.parse(p, out width))
                        seek(buffer,i++) = width;

                    p = props[k++];
                    if(XedParsers.parse(p, out type))
                        seek(buffer,i++) = type;

                    break;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            static void ParseReg(string expr, Index<string> props, ref PatternOp dst)
            {
                var result = Outcome.Success;
                var counter = 0;
                var count = props.Count;
                var width = XedWidthCode.INVALID;
                var type = ElementType.Empty;
                var vis = OpVisibility.None;
                var action = OpAction.None;
                if(count == 5)
                {
                    reg(expr, props, ref dst);
                    return;
                }

                Span<OpAttrib> buffer = stackalloc OpAttrib[8];
                var i=0;
                var k=0;
                if(count >= 1)
                {
                    // reg
                    ref readonly var p = ref props[k++];
                    result = XedParsers.reg(p, out seek(buffer,i++));
                    if(!result)
                        Errors.Throw(string.Format("Unable to parser rgister specification {0}", p));
                }

                if(count >= 2)
                {
                    // action | width
                    ref readonly var p = ref props[k++];
                    if(XedParsers.parse(p, out action))
                        seek(buffer,i++) = action;
                    else if(XedParsers.parse(p, out width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    // width | vis
                    ref readonly var p = ref props[k++];
                    if(width==0 && XedParsers.parse(p, out width))
                        seek(buffer,i++) = width;
                    else if (XedParsers.parse(p, out vis))
                        seek(buffer,i++) = vis;
                }

                if(count >= 4)
                {
                    // width | etype | vis
                    ref readonly var p = ref props[k++];
                    if(width == 0 && XedParsers.parse(p, out width))
                        seek(buffer,i++) = type;
                    else if(XedParsers.parse(p, out type))
                        seek(buffer,i++) = type;
                    else if(XedParsers.parse(p, out vis))
                        seek(buffer,i++) = vis;
                    else
                    {
                        var j = text.index(p, Chars.Eq);
                        if(j > 0)
                        {
                            if(XedParsers.parse(text.right(p, j), out OpModKind mod))
                                seek(buffer,i++) = mod;
                        }
                    }
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }
        }
    }
}