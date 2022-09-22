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

        public static Outcome parse(string src, string type, out list<string> dst)
        {
            dst = new list<string>(text.trim(text.split(Fenced.unfence(src, Fenced.Bracketed), Chars.Comma)));
            return true;
        }
    }
}