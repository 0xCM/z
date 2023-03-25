//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.Metadata.ILOpCode;
    using static MsilCodeModels;
    using static sys;

    using K = System.Reflection.Metadata.ILOpCode;

    public class Cil
    {
        static ReadOnlySeq<MsilOpCode> _OpCodes;

        static uint OpCodeCount;

        static void LoadOpCodes()
        {
            var buffer = alloc<MsilOpCode>(300);
            var count = OpCodeLoader.load(ref first(buffer));
            _OpCodes = buffer;
            OpCodeCount = count;            
        }

        static Cil()
        {
            LoadOpCodes();
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<MsilOpCode> OpCodes()
            => _OpCodes.View;

        [Op]
        public static string keyword(ILOpCode src)
        {
            switch (src)
            {
                case Nop: return "nop";
                case Break: return "break";
                case Ldarg_0: return "ldarg.0";
                case Ldarg_1: return "ldarg.1";
                case Ldarg_2: return "ldarg.2";
                case Ldarg_3: return "ldarg.3";
                case Ldloc_0: return "ldloc.0";
                case Ldloc_1: return "ldloc.1";
                case Ldloc_2: return "ldloc.2";
                case Ldloc_3: return "ldloc.3";
                case Stloc_0: return "stloc.0";
                case Stloc_1: return "stloc.1";
                case Stloc_2: return "stloc.2";
                case Stloc_3: return "stloc.3";
                case Ldarg_s: return "ldarg.s";
                case Ldarga_s: return "ldarga.s";
                case Starg_s: return "starg.s";
                case Ldloc_s: return "ldloc.s";
                case Ldloca_s: return "ldloca.s";
                case Stloc_s: return "stloc.s";
                case Ldnull: return "ldnull";
                case Ldc_i4_m1: return "ldc.i4.m1";
                case Ldc_i4_0: return "ldc.i4.0";
                case Ldc_i4_1: return "ldc.i4.1";
                case Ldc_i4_2: return "ldc.i4.2";
                case Ldc_i4_3: return "ldc.i4.3";
                case Ldc_i4_4: return "ldc.i4.4";
                case Ldc_i4_5: return "ldc.i4.5";
                case Ldc_i4_6: return "ldc.i4.6";
                case Ldc_i4_7: return "ldc.i4.7";
                case Ldc_i4_8: return "ldc.i4.8";
                case Ldc_i4_s: return "ldc.i4.s";
                case Ldc_i4: return "ldc.i4";
                case Ldc_i8: return "ldc.i8";
                case Ldc_r4: return "ldc.r4";
                case Ldc_r8: return "ldc.r8";
                case Dup: return "dup";
                case Pop: return "pop";
                case Jmp: return "jmp";
                case Call: return "call";
                case Calli: return "calli";
                case Ret: return "ret";
                case Br_s: return "br.s";
                case Brfalse_s: return "brfalse.s";
                case Brtrue_s: return "brtrue.s";
                case Beq_s: return "beq.s";
                case Bge_s: return "bge.s";
                case Bgt_s: return "bgt.s";
                case Ble_s: return "ble.s";
                case Blt_s: return "blt.s";
                case Bne_un_s: return "bne.un.s";
                case Bge_un_s: return "bge.un.s";
                case Bgt_un_s: return "bgt.un.s";
                case Ble_un_s: return "ble.un.s";
                case Blt_un_s: return "blt.un.s";
                case Br: return "br";
                case Brfalse: return "brfalse";
                case Brtrue: return "brtrue";
                case Beq: return "beq";
                case Bge: return "bge";
                case Bgt: return "bgt";
                case Ble: return "ble";
                case Blt: return "blt";
                case Bne_un: return "bne.un";
                case Bge_un: return "bge.un";
                case Bgt_un: return "bgt.un";
                case Ble_un: return "ble.un";
                case Blt_un: return "blt.un";
                case Switch: return "switch";
                case Ldind_i1: return "ldind.i1";
                case Ldind_u1: return "ldind.u1";
                case Ldind_i2: return "ldind.i2";
                case Ldind_u2: return "ldind.u2";
                case Ldind_i4: return "ldind.i4";
                case Ldind_u4: return "ldind.u4";
                case Ldind_i8: return "ldind.i8";
                case Ldind_i: return "ldind.i";
                case Ldind_r4: return "ldind.r4";
                case Ldind_r8: return "ldind.r8";
                case Ldind_ref: return "ldind.ref";
                case Stind_ref: return "stind.ref";
                case Stind_i1: return "stind.i1";
                case Stind_i2: return "stind.i2";
                case Stind_i4: return "stind.i4";
                case Stind_i8: return "stind.i8";
                case Stind_r4: return "stind.r4";
                case Stind_r8: return "stind.r8";
                case Add: return "add";
                case Sub: return "sub";
                case Mul: return "mul";
                case Div: return "div";
                case Div_un: return "div.un";
                case Rem: return "rem";
                case Rem_un: return "rem.un";
                case And: return "and";
                case Or: return "or";
                case Xor: return "xor";
                case Shl: return "shl";
                case Shr: return "shr";
                case Shr_un: return "shr.un";
                case Neg: return "neg";
                case Not: return "not";
                case Conv_i1: return "conv.i1";
                case Conv_i2: return "conv.i2";
                case Conv_i4: return "conv.i4";
                case Conv_i8: return "conv.i8";
                case Conv_r4: return "conv.r4";
                case Conv_r8: return "conv.r8";
                case Conv_u4: return "conv.u4";
                case Conv_u8: return "conv.u8";
                case Callvirt: return "callvirt";
                case Cpobj: return "cpobj";
                case Ldobj: return "ldobj";
                case Ldstr: return "ldstr";
                case Newobj: return "newobj";
                case Castclass: return "castclass";
                case Isinst: return "isinst";
                case Conv_r_un: return "conv.r.un";
                case Unbox: return "unbox";
                case K.Throw: return "throw";
                case Ldfld: return "ldfld";
                case Ldflda: return "ldflda";
                case Stfld: return "stfld";
                case Ldsfld: return "ldsfld";
                case Ldsflda: return "ldsflda";
                case Stsfld: return "stsfld";
                case Stobj: return "stobj";
                case Conv_ovf_i1_un: return "conv.ovf.i1.un";
                case Conv_ovf_i2_un: return "conv.ovf.i2.un";
                case Conv_ovf_i4_un: return "conv.ovf.i4.un";
                case Conv_ovf_i8_un: return "conv.ovf.i8.un";
                case Conv_ovf_u1_un: return "conv.ovf.u1.un";
                case Conv_ovf_u2_un: return "conv.ovf.u2.un";
                case Conv_ovf_u4_un: return "conv.ovf.u4.un";
                case Conv_ovf_u8_un: return "conv.ovf.u8.un";
                case Conv_ovf_i_un: return "conv.ovf.i.un";
                case Conv_ovf_u_un: return "conv.ovf.u.un";
                case Box: return "box";
                case Newarr: return "newarr";
                case Ldlen: return "ldlen";
                case Ldelema: return "ldelema";
                case Ldelem_i1: return "ldelem.i1";
                case Ldelem_u1: return "ldelem.u1";
                case Ldelem_i2: return "ldelem.i2";
                case Ldelem_u2: return "ldelem.u2";
                case Ldelem_i4: return "ldelem.i4";
                case Ldelem_u4: return "ldelem.u4";
                case Ldelem_i8: return "ldelem.i8";
                case Ldelem_i: return "ldelem.i";
                case Ldelem_r4: return "ldelem.r4";
                case Ldelem_r8: return "ldelem.r8";
                case Ldelem_ref: return "ldelem.ref";
                case Stelem_i: return "stelem.i";
                case Stelem_i1: return "stelem.i1";
                case Stelem_i2: return "stelem.i2";
                case Stelem_i4: return "stelem.i4";
                case Stelem_i8: return "stelem.i8";
                case Stelem_r4: return "stelem.r4";
                case Stelem_r8: return "stelem.r8";
                case Stelem_ref: return "stelem.ref";
                case Ldelem: return "ldelem";
                case Stelem: return "stelem";
                case Unbox_any: return "unbox.any";
                case Conv_ovf_i1: return "conv.ovf.i1";
                case Conv_ovf_u1: return "conv.ovf.u1";
                case Conv_ovf_i2: return "conv.ovf.i2";
                case Conv_ovf_u2: return "conv.ovf.u2";
                case Conv_ovf_i4: return "conv.ovf.i4";
                case Conv_ovf_u4: return "conv.ovf.u4";
                case Conv_ovf_i8: return "conv.ovf.i8";
                case Conv_ovf_u8: return "conv.ovf.u8";
                case Refanyval: return "refanyval";
                case Ckfinite: return "ckfinite";
                case Mkrefany: return "mkrefany";
                case Ldtoken: return "ldtoken";
                case Conv_u2: return "conv.u2";
                case Conv_u1: return "conv.u1";
                case Conv_i: return "conv.i";
                case Conv_ovf_i: return "conv.ovf.i";
                case Conv_ovf_u: return "conv.ovf.u";
                case Add_ovf: return "add.ovf";
                case Add_ovf_un: return "add.ovf.un";
                case Mul_ovf: return "mul.ovf";
                case Mul_ovf_un: return "mul.ovf.un";
                case Sub_ovf: return "sub.ovf";
                case Sub_ovf_un: return "sub.ovf.un";
                case Endfinally: return "endfinally";
                case Leave: return "leave";
                case Leave_s: return "leave.s";
                case Stind_i: return "stind.i";
                case Conv_u: return "conv.u";
                case Arglist: return "arglist";
                case Ceq: return "ceq";
                case Cgt: return "cgt";
                case Cgt_un: return "cgt.un";
                case Clt: return "clt";
                case Clt_un: return "clt.un";
                case Ldftn: return "ldftn";
                case Ldvirtftn: return "ldvirtftn";
                case Ldarg: return "ldarg";
                case Ldarga: return "ldarga";
                case Starg: return "starg";
                case Ldloc: return "ldloc";
                case Ldloca: return "ldloca";
                case Stloc: return "stloc";
                case Localloc: return "localloc";
                case Endfilter: return "endfilter";
                case Unaligned: return "unaligned.";
                case Volatile: return "volatile.";
                case Tail: return "tail.";
                case Initobj: return "initobj";
                case Constrained: return "constrained.";
                case Cpblk: return "cpblk";
                case Initblk: return "initblk";
                case Rethrow: return "rethrow";
                case Sizeof: return "sizeof";
                case Refanytype: return "refanytype";
                case Readonly: return "readonly.";
            }

            return EmptyString;
        }
    }
}