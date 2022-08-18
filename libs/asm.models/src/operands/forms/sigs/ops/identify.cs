//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        public static string identify(in AsmSigOp src)
        {
            if(_Datasets.Names.Find(src.Id, out var id))
            {
                if(src.Modifier != 0)
                {
                    if(_Datasets.Modifers.MapKind(src.Modifier, out var mod))
                        return string.Format("{0}_{1}", id, mod.Kind);
                }

                return id;
            }
            Errors.Throw(string.Format("{0} is unidentifiable", src));
            return EmptyString;
        }

        public static string identify(in AsmSig src)
        {
            var dst = text.buffer();
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            for(byte j=0; j<src.OpCount; j++)
            {
                dst.Append(Chars.Underscore);
                dst.Append(identify(src.Operands[j]));
            }

            return dst.Emit();
        }
    }
}