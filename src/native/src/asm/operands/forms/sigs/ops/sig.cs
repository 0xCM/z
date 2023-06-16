//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class AsmSigs
    {
        public static bool HasOpMask(in AsmSig src)
            => opmask(src, out _);

        [Op]
        public static AsmSig sig(AsmMnemonic mnemonic, params AsmSigOp[] ops)
            => ops.Length switch{
                0 => new AsmSig(mnemonic),
                1 => new AsmSig(mnemonic, skip(ops,0)),
                2 => new AsmSig(mnemonic, skip(ops,0), skip(ops,1)),
                3 => new AsmSig(mnemonic, skip(ops,0), skip(ops,1), skip(ops,2)),
                4 => new AsmSig(mnemonic, skip(ops,0), skip(ops,1), skip(ops,2), skip(ops,3)),
                5 => new AsmSig(mnemonic, skip(ops,0), skip(ops,1), skip(ops,2), skip(ops,3), skip(ops,4)),
                _ => AsmSig.Empty
            };
    }
}