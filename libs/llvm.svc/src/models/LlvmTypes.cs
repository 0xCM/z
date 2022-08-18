//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    [ApiHost]
    public readonly struct LlvmTypes
    {
        public static Fence<char> Parenthetical => (Chars.LParen, Chars.RParen);

        [Op]
        public static LlvmDataType type(string src)
        {
            if(src.Equals("bit"))
                return parse(LlvmTypeKind.Bit, src);
            else if(src.Equals("string"))
                return parse(LlvmTypeKind.String, src);
            else if(src.Equals("int"))
                return parse(LlvmTypeKind.Int, src);
            else if(src.Equals("dag"))
                return parse(LlvmTypeKind.Dag, src);
            else if(src.StartsWith("bits"))
                return parse(LlvmTypeKind.Bits, src);
            else if(src.StartsWith("list"))
                return parse(LlvmTypeKind.List, src);
            else if(src.StartsWith("names"))
                return parse(LlvmTypeKind.NameList, src);
            else
                return parse(0,src);
        }

        public static string format(in LlvmDataType src)
        {
            var arity = src.Arity;
            if(arity == 0)
                return src.Name;

            var dst = text.buffer();
            dst.AppendFormat("{0}<", src.Name);

            for(var i=0; i<arity; i++)
            {
                dst.Append(src.Parameters[i]);
                if(i!= arity - 1)
                    dst.Append(Chars.Comma);
            }

            dst.Append(">");

            return dst.Emit();
        }

        static LlvmDataType parse(LlvmTypeKind kind, string src)
        {
            var i = text.index(src,Chars.Lt);
            var j = text.index(src,Chars.Gt);
            var args = sys.empty<string>();
            var name = src;
            if(i >= 0 && j>i)
            {
                args = ParseArgs(text.inside(src,i,j));
                name = text.left(src,i).Trim();
            }
            return new (name,kind,args);
        }

        static string[] ParseArgs(string src)
        {
            var i = text.index(src,Chars.Comma);
            if(i >= 0)
                return text.split(src, Chars.Comma).Select(x => x.Trim());
            else
                return array(src.Trim());
        }

        public static string format(IDag src, DagFormatStyle style)
        {
            var pattern = style == DagFormatStyle.Graph ? "{0} -> {1}" : "{0}, {1}";
            if(src.Left.IsNonEmpty && src.Right.IsNonEmpty)
                return string.Format(pattern, src.Left.Format(), src.Right.Format());
            else if(src.Left.IsEmpty && src.Right.IsEmpty)
                return EmptyString;
            else if(src.Left.IsNonEmpty)
                return src.Left.Format();
            else
                return src.Right.Format();
        }

        public static dag<L,R> dag<L,R>(L left, R right)
            where L : IExpr
            where R : IExpr
                => new dag<L,R>(left,right);

        public static Outcome parse(string src, string type, out list<string> dst)
        {
            dst = new list<string>(text.trim(text.split(Fenced.unfence(src, Fenced.Bracketed), Chars.Comma)));
            return true;
        }

        public static Outcome parse(string src, out dag<IExpr> dag)
        {
            dag = new dag<IExpr>(@string.Empty, @string.Empty);
            if(src.Contains("->"))
            {
                var parts = src.SplitClean("->").Select(x => x.Trim());
                var count = parts.Length;
                for(var i=1; i<count; i++)
                {
                    if(i==1)
                        dag = new dag<IExpr>((@string)skip(parts,i-1), (@string)skip(parts,i));
                    else
                        dag = new dag<IExpr>(dag, (@string)skip(parts,i));
                }
            }
            else if(src.Contains(","))
            {
                var parts = src.SplitClean(",").Select(x => x.Trim());
                var count = parts.Length;
                for(var i=1; i<count; i++)
                {
                    if(i==1)
                        dag = new dag<IExpr>((@string)skip(parts,i-1), (@string)skip(parts,i));
                    else
                        dag = new dag<IExpr>(dag, (@string)skip(parts,i));
                }
            }
            else
            {
                dag = new dag<IExpr>((@string)src, @string.Empty);
            }
            return true;
        }
    }
}