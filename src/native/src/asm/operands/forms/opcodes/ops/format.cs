//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class SdmOpCodes
    {
        public static string format(AsmOcToken src)
        {
            if(src.IsEmpty)
                return EmptyString;

            if(Datasets.Expressions.Find(src.Id, out var xpr))
                return xpr;

            return RP.Error;
        }

        public static string format(in SdmOpCode src)
        {
            if(src.IsEmpty)
                return EmptyString;
            var dst = text.buffer();
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
                dst.Append(expression(src[i]));
            return dst.Emit();
        }
    }
}