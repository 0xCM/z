//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmSrcEmitter
    {
        public static byte emit<A,B>(AsmMnemonic inst, A op1, B op2, ref CharBlock64 dst)
            where A : IAsmOp
            where B : IAsmOp
        {
            const string ExprPattern = "{0} {1}, {2}";
            var src = span(string.Format(ExprPattern, inst, op1, op2));
            var size = (byte)src.Length;
            for(var i=0; i<size; i++)
                dst[i] = skip(src,i);
            return size;
        }

        public static byte emit<A,B,S>(AsmMnemonic inst, A op1, B op2, ref S dst)
            where A : IAsmOp
            where B : IAsmOp
            where S : unmanaged, ICharBlock<S>
        {
            const string ExprPattern = "{0} {1}, {2}";
            var src = span(string.Format(ExprPattern, inst, op1, op2));
            var size = (byte)src.Length;
            var cells = dst.Data;
            for(var i=0; i<size; i++)
                seek(cells,i) = skip(src,i);
            return size;
        }
    }
}