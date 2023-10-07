//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

using K = AsmSigTokenKind;

partial class AsmSigs
{
    public static Index<SdmForm> terminate(in SdmForm src)
    {
        var sigs = list<AsmSig>();
        terminate(src.Sig, sigs);
        iter(sigs, s => Require.invariant(terminal(s)));
        var count = sigs.Count;
        var dst = alloc<SdmForm>(count);
        for(var i=0; i<count; i++)
            seek(dst,i) = SdmForms.form(src.Name, sigs[i], src.OpCode);
        return dst;
    }

    public static bool terminal(in AsmSigOp src)
    {
        var result = false;
        switch(src.Kind)
        {
            case K.GpReg:
            case K.IntLiteral:
            case K.SysReg:
            case K.RegLiteral:
            case K.Mmx:
            case K.KReg:
            case K.VReg:
            case K.FpuReg:
            case K.FpuInt:
            case K.FpuMem:
            case K.Imm:
            case K.Mem:
            case K.Moffs:
            case K.MemPair:
            case K.MemPtr:
            case K.Rel:
            case K.Ptr:
            case K.OpMask:
            case K.BCastMem:
            case K.Rounding:
            case K.Modifier:
            case K.Vsib:
            case K.Dependent:
                result = true;
            break;
            default:
            break;
        }
        return result;
    }

    public static bool terminal(in AsmSig src)
    {
        var result = true;
        for(var i=0; i<src.OpCount; i++)
            result &= terminal(src[i]);
        return result;
    }

    public static Index<AsmSig> terminate(in AsmSig src)
    {
        var dst = list<AsmSig>();
        terminate(src,dst);
        return dst.ToArray();
    }

    public static void terminate(in AsmSig src, List<AsmSig> sigs)
    {
        var sig = new AsmSig(src.Mnemonic);

        if(terminal(src))
            sigs.Add(src);
        else
        {
            for(var i=z8; i<src.OpCount; i++)
            {
                var op = src.Operands[i];
                if(terminal(op))
                    sig = sig.With(i,op);
                else
                {
                    var terminals = terminate(op);
                    for(var j=0; j<terminals.Count; j++)
                    {
                        for(var k=i; k<src.OpCount; k++)
                        {
                            if(k==i)
                                sig = sig.With(i, terminals[j]);
                            else
                                sig = sig.With(k, src[k]);
                        }

                        terminate(sig, sigs);
                    }
                }
            }
        }
    }

    public static Index<AsmSigOp> terminate(in AsmSigOp src)
    {
        var dst = list<AsmSigOp>();
        if(terminal(src))
            dst.Add(src);
        else
        {
            // if(_Datasets.Nonterminals.Find(src.Id, out var y))
            // {
            //     if(y.Term1.IsNonEmpty)
            //         dst.Add(operand(y.Term1, src.Modifier));

            //     if(y.Term1.IsNonEmpty)
            //         dst.Add(operand(y.Term2, src.Modifier));

            //     if(y.Term3.IsNonEmpty)
            //         dst.Add(operand(y.Term3, src.Modifier));
            // }
        }

        return dst.ToArray();
    }
}
