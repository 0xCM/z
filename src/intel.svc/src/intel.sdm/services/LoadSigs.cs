//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public static AsmSigExpr sig(in SdmOpCodeDetail src)
        {
            var dst = AsmSigExpr.Empty;
            var sig = src.AsmSig.Format().Trim();
            var mnemonic = src.Mnemonic;
            var j = text.index(sig, Chars.Space);
            if(j > 0)
            {
                var operands = text.right(sig, j);
                if(text.contains(sig,Chars.Comma))
                    dst = AsmSigs.expression(mnemonic, text.trim(text.split(operands, Chars.Comma)));
                else
                    dst = AsmSigs.expression(mnemonic, operands);
            }
            else
            {
                dst = AsmSigs.expression(mnemonic);
            }
            return dst;
        }

        public Index<AsmSigExpr> LoadSigs()
        {
            return Data(nameof(LoadSigs), Load);

            Index<AsmSigExpr> Load()
                => ExtractSigs(LoadOcDetails());
        }

        Index<AsmSigExpr> ExtractSigs(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmSigExpr>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = sig(skip(src,i));
            return buffer;
        }
    }
}