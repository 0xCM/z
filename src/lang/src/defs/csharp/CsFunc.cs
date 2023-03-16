//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct CsModels
    {
        public class CsFunc
        {
            public readonly Identifier ReturnType;

            public readonly Identifier Name;

            public readonly Index<CsOperand> Ops;

            public readonly Index<string> Body;

            public readonly bool IsStatic;

            public CsFunc(Identifier ret, Identifier name, bool @static, CsOperand[] ops, Index<string> body)
            {
                Name = name;
                ReturnType = ret;
                Body = body;
                Ops = ops;
                IsStatic = @static;
            }

            string SigPattern()
            {
                if(IsStatic)
                    return "public static {0} {1}({2})";
                else
                    return "public {0} {1}({2})";
            }

            public void Render(uint margin, ITextBuffer dst)
            {
                dst.IndentLineFormat(margin, SigPattern(), ReturnType, Name, Ops);
                dst.IndentLine(margin, Chars.LBrace);
                margin += 4;
                iter(Body, b => dst.IndentLine(margin,b));
                margin -= 4;
                dst.IndentLine(margin, Chars.RBrace);
            }
        }
    }
}