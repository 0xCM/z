//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public sealed class InstBlockOperands : Seq<InstBlockOperands,InstBlockOperand>
    {
        public InstBlockOperands()
        {}

        public InstBlockOperands(params InstBlockOperand[] src)
            : base(src)
        {

        }

        public override string Format()
        {
            var dst = text.emitter();
            dst.Append(Chars.LParen);
            for(var i=0; i<Count; i++)
            {
                if(i!=0)
                    dst.Append(", ");
                dst.Append(this[i]);
            }

            dst.Append(Chars.RParen);
            return dst.Emit();
        }
    }
}