// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Z0
{
    using static sys;

    using C = System.Reflection.Metadata.ILOpCode;
    using CT = Cil.OpCodeType;
    using OT = Cil.OperandType;
    using SB = Cil.StackBehaviour;

    partial struct Cil
    {
        public readonly struct OpCodeLoader
        {
            [MethodImpl(Inline), Op]
            public static CilOpCode pack(C id, string name, OpCodeType type, OperandType optype, byte opcount, ushort value, StackBehaviour sb1, StackBehaviour sb2)
                => new CilOpCode(id, value, name, type, optype, opcount, sb1, sb2);

            /// <summary>
            /// Populates an opcode dataset
            /// </summary>
            /// <param name="dst"></param>
            /// <remarks>This implementation of this method was derived from test code in the System.Reflection.Metadata .net core repo</remarks>
            [Op]
            public static uint load(ref CilOpCode dst)
            {
                var i=0u;
                seek(dst,i++) = pack(C.Add, "add", CT.Primitive, OT.InlineNone, 1, 0x58, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Add_ovf, "add.ovf", CT.Primitive, OT.InlineNone, 1, 0xd6, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Add_ovf_un, "add.ovf.un", CT.Primitive, OT.InlineNone, 1, 0xd7, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.And, "and", CT.Primitive, OT.InlineNone, 1, 0x5f, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Arglist, "arglist", CT.Primitive, OT.InlineNone, 2, 0xfe00, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Beq, "beq", CT.Macro, OT.InlineBrTarget, 1, 0x3b, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Beq_s, "beq.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x2e, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bge, "bge", CT.Macro, OT.InlineBrTarget, 1, 0x3c, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bge_s, "bge.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x2f, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bge_un, "bge.un", CT.Macro, OT.InlineBrTarget, 1, 0x41, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bge_un_s, "bge.un.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x34, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bgt, "bgt", CT.Macro, OT.InlineBrTarget, 1, 0x3d, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bgt_s, "bgt.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x30, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bgt_un, "bgt.un", CT.Macro, OT.InlineBrTarget, 1, 0x42, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bgt_un_s, "bgt.un.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x35, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Ble, "ble", CT.Macro, OT.InlineBrTarget, 1, 0x3e, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Ble_s, "ble.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x31, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Ble_un, "ble.un", CT.Macro, OT.InlineBrTarget, 1, 0x43, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Ble_un_s, "ble.un.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x36, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Blt, "blt", CT.Macro, OT.InlineBrTarget, 1, 0x3f, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Blt_s, "blt.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x32, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Blt_un, "blt.un", CT.Macro, OT.InlineBrTarget, 1, 0x44, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Blt_un_s, "blt.un.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x37, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bne_un, "bne.un", CT.Macro, OT.InlineBrTarget, 1, 0x40, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Bne_un_s, "bne.un.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x33, SB.Pop1_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Box, "box", CT.Primitive, OT.InlineType, 1, 0x8c, SB.Pop1, SB.Pushref);
                seek(dst,i++) = pack(C.Br, "br", CT.Primitive, OT.InlineBrTarget, 1, 0x38, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Br_s, "br.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x2b, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Break, "break", CT.Primitive, OT.InlineNone, 1, 0x1, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Brfalse, "brfalse", CT.Primitive, OT.InlineBrTarget, 1, 0x39, SB.Popi, SB.Push0);
                seek(dst,i++) = pack(C.Brfalse_s, "brfalse.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x2c, SB.Popi, SB.Push0);
                seek(dst,i++) = pack(C.Brtrue, "brtrue", CT.Primitive, OT.InlineBrTarget, 1, 0x3a, SB.Popi, SB.Push0);
                seek(dst,i++) = pack(C.Brtrue_s, "brtrue.s", CT.Macro, OT.ShortInlineBrTarget, 1, 0x2d, SB.Popi, SB.Push0);
                seek(dst,i++) = pack(C.Call, "call", CT.Primitive, OT.InlineMethod, 1, 0x28, SB.Varpop, SB.Varpush);
                seek(dst,i++) = pack(C.Calli, "calli", CT.Primitive, OT.InlineSig, 1, 0x29, SB.Varpop, SB.Varpush);
                seek(dst,i++) = pack(C.Callvirt, "callvirt", CT.Objmodel, OT.InlineMethod, 1, 0x6f, SB.Varpop, SB.Varpush);
                seek(dst,i++) = pack(C.Castclass, "castclass", CT.Objmodel, OT.InlineType, 1, 0x74, SB.Popref, SB.Pushref);
                seek(dst,i++) = pack(C.Ceq, "ceq", CT.Primitive, OT.InlineNone, 2, 0xfe01, SB.Pop1_pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Cgt, "cgt", CT.Primitive, OT.InlineNone, 2, 0xfe02, SB.Pop1_pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Cgt_un, "cgt.un", CT.Primitive, OT.InlineNone, 2, 0xfe03, SB.Pop1_pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Ckfinite, "ckfinite", CT.Primitive, OT.InlineNone, 1, 0xc3, SB.Pop1, SB.Pushr8);
                seek(dst,i++) = pack(C.Clt, "clt", CT.Primitive, OT.InlineNone, 2, 0xfe04, SB.Pop1_pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Clt_un, "clt.un", CT.Primitive, OT.InlineNone, 2, 0xfe05, SB.Pop1_pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Constrained, "constrained.", CT.Prefix, OT.InlineType, 2, 0xfe16, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Conv_i, "conv.i", CT.Primitive, OT.InlineNone, 1, 0xd3, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_i1, "conv.i1", CT.Primitive, OT.InlineNone, 1, 0x67, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_i2, "conv.i2", CT.Primitive, OT.InlineNone, 1, 0x68, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_i4, "conv.i4", CT.Primitive, OT.InlineNone, 1, 0x69, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_i8, "conv.i8", CT.Primitive, OT.InlineNone, 1, 0x6a, SB.Pop1, SB.Pushi8);
                seek(dst,i++) = pack(C.Conv_ovf_i, "conv.ovf.i", CT.Primitive, OT.InlineNone, 1, 0xd4, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i_un, "conv.ovf.i.un", CT.Primitive, OT.InlineNone, 1, 0x8a, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i1, "conv.ovf.i1", CT.Primitive, OT.InlineNone, 1, 0xb3, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i1_un, "conv.ovf.i1.un", CT.Primitive, OT.InlineNone, 1, 0x82, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i2, "conv.ovf.i2", CT.Primitive, OT.InlineNone, 1, 0xb5, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i2_un, "conv.ovf.i2.un", CT.Primitive, OT.InlineNone, 1, 0x83, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i4, "conv.ovf.i4", CT.Primitive, OT.InlineNone, 1, 0xb7, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i4_un, "conv.ovf.i4.un", CT.Primitive, OT.InlineNone, 1, 0x84, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_i8, "conv.ovf.i8", CT.Primitive, OT.InlineNone, 1, 0xb9, SB.Pop1, SB.Pushi8);
                seek(dst,i++) = pack(C.Conv_ovf_i8_un, "conv.ovf.i8.un", CT.Primitive, OT.InlineNone, 1, 0x85, SB.Pop1, SB.Pushi8);
                seek(dst,i++) = pack(C.Conv_ovf_u, "conv.ovf.u", CT.Primitive, OT.InlineNone, 1, 0xd5, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u_un, "conv.ovf.u.un", CT.Primitive, OT.InlineNone, 1, 0x8b, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u1, "conv.ovf.u1", CT.Primitive, OT.InlineNone, 1, 0xb4, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u1_un, "conv.ovf.u1.un", CT.Primitive, OT.InlineNone, 1, 0x86, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u2, "conv.ovf.u2", CT.Primitive, OT.InlineNone, 1, 0xb6, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u2_un, "conv.ovf.u2.un", CT.Primitive, OT.InlineNone, 1, 0x87, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u4, "conv.ovf.u4", CT.Primitive, OT.InlineNone, 1, 0xb8, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u4_un, "conv.ovf.u4.un", CT.Primitive, OT.InlineNone, 1, 0x88, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_ovf_u8, "conv.ovf.u8", CT.Primitive, OT.InlineNone, 1, 0xba, SB.Pop1, SB.Pushi8);
                seek(dst,i++) = pack(C.Conv_ovf_u8_un, "conv.ovf.u8.un", CT.Primitive, OT.InlineNone, 1, 0x89, SB.Pop1, SB.Pushi8);
                seek(dst,i++) = pack(C.Conv_r_un, "conv.r.un", CT.Primitive, OT.InlineNone, 1, 0x76, SB.Pop1, SB.Pushr8);
                seek(dst,i++) = pack(C.Conv_r4, "conv.r4", CT.Primitive, OT.InlineNone, 1, 0x6b, SB.Pop1, SB.Pushr4);
                seek(dst,i++) = pack(C.Conv_r8, "conv.r8", CT.Primitive, OT.InlineNone, 1, 0x6c, SB.Pop1, SB.Pushr8);
                seek(dst,i++) = pack(C.Conv_u, "conv.u", CT.Primitive, OT.InlineNone, 1, 0xe0, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_u1, "conv.u1", CT.Primitive, OT.InlineNone, 1, 0xd2, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_u2, "conv.u2", CT.Primitive, OT.InlineNone, 1, 0xd1, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_u4, "conv.u4", CT.Primitive, OT.InlineNone, 1, 0x6d, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Conv_u8, "conv.u8", CT.Primitive, OT.InlineNone, 1, 0x6e, SB.Pop1, SB.Pushi8);
                seek(dst,i++) = pack(C.Cpblk, "cpblk", CT.Primitive, OT.InlineNone, 2, 0xfe17, SB.Popi_popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Cpobj, "cpobj", CT.Objmodel, OT.InlineType, 1, 0x70, SB.Popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Div, "div", CT.Primitive, OT.InlineNone, 1, 0x5b, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Div_un, "div.un", CT.Primitive, OT.InlineNone, 1, 0x5c, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Dup, "dup", CT.Primitive, OT.InlineNone, 1, 0x25, SB.Pop1, SB.Push1_push1);
                seek(dst,i++) = pack(C.Endfilter, "endfilter", CT.Primitive, OT.InlineNone, 2, 0xfe11, SB.Popi, SB.Push0);
                seek(dst,i++) = pack(C.Endfinally, "endfinally", CT.Primitive, OT.InlineNone, 1, 0xdc, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Initblk, "initblk", CT.Primitive, OT.InlineNone, 2, 0xfe18, SB.Popi_popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Initobj, "initobj", CT.Objmodel, OT.InlineType, 2, 0xfe15, SB.Popi, SB.Push0);
                seek(dst,i++) = pack(C.Isinst, "isinst", CT.Objmodel, OT.InlineType, 1, 0x75, SB.Popref, SB.Pushi);
                seek(dst,i++) = pack(C.Jmp, "jmp", CT.Primitive, OT.InlineMethod, 1, 0x27, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Ldarg, "ldarg", CT.Primitive, OT.InlineVar, 2, 0xfe09, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldarg_0, "ldarg.0", CT.Macro, OT.InlineNone, 1, 0x2, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldarg_1, "ldarg.1", CT.Macro, OT.InlineNone, 1, 0x3, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldarg_2, "ldarg.2", CT.Macro, OT.InlineNone, 1, 0x4, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldarg_3, "ldarg.3", CT.Macro, OT.InlineNone, 1, 0x5, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldarg_s, "ldarg.s", CT.Macro, OT.ShortInlineVar, 1, 0xe, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldarga, "ldarga", CT.Primitive, OT.InlineVar, 2, 0xfe0a, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldarga_s, "ldarga.s", CT.Macro, OT.ShortInlineVar, 1, 0xf, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4, "ldc.i4", CT.Primitive, OT.InlineI, 1, 0x20, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_0, "ldc.i4.0", CT.Macro, OT.InlineNone, 1, 0x16, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_1, "ldc.i4.1", CT.Macro, OT.InlineNone, 1, 0x17, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_2, "ldc.i4.2", CT.Macro, OT.InlineNone, 1, 0x18, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_3, "ldc.i4.3", CT.Macro, OT.InlineNone, 1, 0x19, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_4, "ldc.i4.4", CT.Macro, OT.InlineNone, 1, 0x1a, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_5, "ldc.i4.5", CT.Macro, OT.InlineNone, 1, 0x1b, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_6, "ldc.i4.6", CT.Macro, OT.InlineNone, 1, 0x1c, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_7, "ldc.i4.7", CT.Macro, OT.InlineNone, 1, 0x1d, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_8, "ldc.i4.8", CT.Macro, OT.InlineNone, 1, 0x1e, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_m1, "ldc.i4.m1", CT.Macro, OT.InlineNone, 1, 0x15, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i4_s, "ldc.i4.s", CT.Macro, OT.ShortInlineI, 1, 0x1f, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldc_i8, "ldc.i8", CT.Primitive, OT.InlineI8, 1, 0x21, SB.Pop0, SB.Pushi8);
                seek(dst,i++) = pack(C.Ldc_r4, "ldc.r4", CT.Primitive, OT.ShortInlineR, 1, 0x22, SB.Pop0, SB.Pushr4);
                seek(dst,i++) = pack(C.Ldc_r8, "ldc.r8", CT.Primitive, OT.InlineR, 1, 0x23, SB.Pop0, SB.Pushr8);
                seek(dst,i++) = pack(C.Ldelem, "ldelem", CT.Objmodel, OT.InlineType, 1, 0xa3, SB.Popref_popi, SB.Push1);
                seek(dst,i++) = pack(C.Ldelem_i, "ldelem.i", CT.Objmodel, OT.InlineNone, 1, 0x97, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldelem_i1, "ldelem.i1", CT.Objmodel, OT.InlineNone, 1, 0x90, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldelem_i2, "ldelem.i2", CT.Objmodel, OT.InlineNone, 1, 0x92, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldelem_i4, "ldelem.i4", CT.Objmodel, OT.InlineNone, 1, 0x94, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldelem_i8, "ldelem.i8", CT.Objmodel, OT.InlineNone, 1, 0x96, SB.Popref_popi, SB.Pushi8);
                seek(dst,i++) = pack(C.Ldelem_r4, "ldelem.r4", CT.Objmodel, OT.InlineNone, 1, 0x98, SB.Popref_popi, SB.Pushr4);
                seek(dst,i++) = pack(C.Ldelem_r8, "ldelem.r8", CT.Objmodel, OT.InlineNone, 1, 0x99, SB.Popref_popi, SB.Pushr8);
                seek(dst,i++) = pack(C.Ldelem_ref, "ldelem.ref", CT.Objmodel, OT.InlineNone, 1, 0x9a, SB.Popref_popi, SB.Pushref);
                seek(dst,i++) = pack(C.Ldelem_u1, "ldelem.u1", CT.Objmodel, OT.InlineNone, 1, 0x91, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldelem_u2, "ldelem.u2", CT.Objmodel, OT.InlineNone, 1, 0x93, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldelem_u4, "ldelem.u4", CT.Objmodel, OT.InlineNone, 1, 0x95, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldelema, "ldelema", CT.Objmodel, OT.InlineType, 1, 0x8f, SB.Popref_popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldfld, "ldfld", CT.Objmodel, OT.InlineField, 1, 0x7b, SB.Popref, SB.Push1);
                seek(dst,i++) = pack(C.Ldflda, "ldflda", CT.Objmodel, OT.InlineField, 1, 0x7c, SB.Popref, SB.Pushi);
                seek(dst,i++) = pack(C.Ldftn, "ldftn", CT.Primitive, OT.InlineMethod, 2, 0xfe06, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldind_i, "ldind.i", CT.Primitive, OT.InlineNone, 1, 0x4d, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldind_i1, "ldind.i1", CT.Primitive, OT.InlineNone, 1, 0x46, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldind_i2, "ldind.i2", CT.Primitive, OT.InlineNone, 1, 0x48, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldind_i4, "ldind.i4", CT.Primitive, OT.InlineNone, 1, 0x4a, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldind_i8, "ldind.i8", CT.Primitive, OT.InlineNone, 1, 0x4c, SB.Popi, SB.Pushi8);
                seek(dst,i++) = pack(C.Ldind_r4, "ldind.r4", CT.Primitive, OT.InlineNone, 1, 0x4e, SB.Popi, SB.Pushr4);
                seek(dst,i++) = pack(C.Ldind_r8, "ldind.r8", CT.Primitive, OT.InlineNone, 1, 0x4f, SB.Popi, SB.Pushr8);
                seek(dst,i++) = pack(C.Ldind_ref, "ldind.ref", CT.Primitive, OT.InlineNone, 1, 0x50, SB.Popi, SB.Pushref);
                seek(dst,i++) = pack(C.Ldind_u1, "ldind.u1", CT.Primitive, OT.InlineNone, 1, 0x47, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldind_u2, "ldind.u2", CT.Primitive, OT.InlineNone, 1, 0x49, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldind_u4, "ldind.u4", CT.Primitive, OT.InlineNone, 1, 0x4b, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Ldlen, "ldlen", CT.Objmodel, OT.InlineNone, 1, 0x8e, SB.Popref, SB.Pushi);
                seek(dst,i++) = pack(C.Ldloc, "ldloc", CT.Primitive, OT.InlineVar, 2, 0xfe0c, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldloc_0, "ldloc.0", CT.Macro, OT.InlineNone, 1, 0x6, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldloc_1, "ldloc.1", CT.Macro, OT.InlineNone, 1, 0x7, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldloc_2, "ldloc.2", CT.Macro, OT.InlineNone, 1, 0x8, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldloc_3, "ldloc.3", CT.Macro, OT.InlineNone, 1, 0x9, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldloc_s, "ldloc.s", CT.Macro, OT.ShortInlineVar, 1, 0x11, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldloca, "ldloca", CT.Primitive, OT.InlineVar, 2, 0xfe0d, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldloca_s, "ldloca.s", CT.Macro, OT.ShortInlineVar, 1, 0x12, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldnull, "ldnull", CT.Primitive, OT.InlineNone, 1, 0x14, SB.Pop0, SB.Pushref);
                seek(dst,i++) = pack(C.Ldobj, "ldobj", CT.Objmodel, OT.InlineType, 1, 0x71, SB.Popi, SB.Push1);
                seek(dst,i++) = pack(C.Ldsfld, "ldsfld", CT.Objmodel, OT.InlineField, 1, 0x7e, SB.Pop0, SB.Push1);
                seek(dst,i++) = pack(C.Ldsflda, "ldsflda", CT.Objmodel, OT.InlineField, 1, 0x7f, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldstr, "ldstr", CT.Objmodel, OT.InlineString, 1, 0x72, SB.Pop0, SB.Pushref);
                seek(dst,i++) = pack(C.Ldtoken, "ldtoken", CT.Primitive, OT.InlineTok, 1, 0xd0, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Ldvirtftn, "ldvirtftn", CT.Primitive, OT.InlineMethod, 2, 0xfe07, SB.Popref, SB.Pushi);
                seek(dst,i++) = pack(C.Leave, "leave", CT.Primitive, OT.InlineBrTarget, 1, 0xdd, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Leave_s, "leave.s", CT.Primitive, OT.ShortInlineBrTarget, 1, 0xde, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Localloc, "localloc", CT.Primitive, OT.InlineNone, 2, 0xfe0f, SB.Popi, SB.Pushi);
                seek(dst,i++) = pack(C.Mkrefany, "mkrefany", CT.Primitive, OT.InlineType, 1, 0xc6, SB.Popi, SB.Push1);
                seek(dst,i++) = pack(C.Mul, "mul", CT.Primitive, OT.InlineNone, 1, 0x5a, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Mul_ovf, "mul.ovf", CT.Primitive, OT.InlineNone, 1, 0xd8, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Mul_ovf_un, "mul.ovf.un", CT.Primitive, OT.InlineNone, 1, 0xd9, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Neg, "neg", CT.Primitive, OT.InlineNone, 1, 0x65, SB.Pop1, SB.Push1);
                seek(dst,i++) = pack(C.Newarr, "newarr", CT.Objmodel, OT.InlineType, 1, 0x8d, SB.Popi, SB.Pushref);
                seek(dst,i++) = pack(C.Newobj, "newobj", CT.Objmodel, OT.InlineMethod, 1, 0x73, SB.Varpop, SB.Pushref);
                seek(dst,i++) = pack(C.Nop, "nop", CT.Primitive, OT.InlineNone, 1, 0x0, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Not, "not", CT.Primitive, OT.InlineNone, 1, 0x66, SB.Pop1, SB.Push1);
                seek(dst,i++) = pack(C.Or, "or", CT.Primitive, OT.InlineNone, 1, 0x60, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Pop, "pop", CT.Primitive, OT.InlineNone, 1, 0x26, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Readonly, "readonly.", CT.Prefix, OT.InlineNone, 2, 0xfe1e, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Refanytype, "refanytype", CT.Primitive, OT.InlineNone, 2, 0xfe1d, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Refanyval, "refanyval", CT.Primitive, OT.InlineType, 1, 0xc2, SB.Pop1, SB.Pushi);
                seek(dst,i++) = pack(C.Rem, "rem", CT.Primitive, OT.InlineNone, 1, 0x5d, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Rem_un, "rem.un", CT.Primitive, OT.InlineNone, 1, 0x5e, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Ret, "ret", CT.Primitive, OT.InlineNone, 1, 0x2a, SB.Varpop, SB.Push0);
                seek(dst,i++) = pack(C.Rethrow, "rethrow", CT.Objmodel, OT.InlineNone, 2, 0xfe1a, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Shl, "shl", CT.Primitive, OT.InlineNone, 1, 0x62, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Shr, "shr", CT.Primitive, OT.InlineNone, 1, 0x63, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Shr_un, "shr.un", CT.Primitive, OT.InlineNone, 1, 0x64, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Sizeof, "sizeof", CT.Primitive, OT.InlineType, 2, 0xfe1c, SB.Pop0, SB.Pushi);
                seek(dst,i++) = pack(C.Starg, "starg", CT.Primitive, OT.InlineVar, 2, 0xfe0b, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Starg_s, "starg.s", CT.Macro, OT.ShortInlineVar, 1, 0x10, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stelem, "stelem", CT.Objmodel, OT.InlineType, 1, 0xa4, SB.Popref_popi_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_i, "stelem.i", CT.Objmodel, OT.InlineNone, 1, 0x9b, SB.Popref_popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_i1, "stelem.i1", CT.Objmodel, OT.InlineNone, 1, 0x9c, SB.Popref_popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_i2, "stelem.i2", CT.Objmodel, OT.InlineNone, 1, 0x9d, SB.Popref_popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_i4, "stelem.i4", CT.Objmodel, OT.InlineNone, 1, 0x9e, SB.Popref_popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_i8, "stelem.i8", CT.Objmodel, OT.InlineNone, 1, 0x9f, SB.Popref_popi_popi8, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_r4, "stelem.r4", CT.Objmodel, OT.InlineNone, 1, 0xa0, SB.Popref_popi_popr4, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_r8, "stelem.r8", CT.Objmodel, OT.InlineNone, 1, 0xa1, SB.Popref_popi_popr8, SB.Push0);
                seek(dst,i++) = pack(C.Stelem_ref, "stelem.ref", CT.Objmodel, OT.InlineNone, 1, 0xa2, SB.Popref_popi_popref, SB.Push0);
                seek(dst,i++) = pack(C.Stfld, "stfld", CT.Objmodel, OT.InlineField, 1, 0x7d, SB.Popref_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stind_i, "stind.i", CT.Primitive, OT.InlineNone, 1, 0xdf, SB.Popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stind_i1, "stind.i1", CT.Primitive, OT.InlineNone, 1, 0x52, SB.Popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stind_i2, "stind.i2", CT.Primitive, OT.InlineNone, 1, 0x53, SB.Popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stind_i4, "stind.i4", CT.Primitive, OT.InlineNone, 1, 0x54, SB.Popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stind_i8, "stind.i8", CT.Primitive, OT.InlineNone, 1, 0x55, SB.Popi_popi8, SB.Push0);
                seek(dst,i++) = pack(C.Stind_r4, "stind.r4", CT.Primitive, OT.InlineNone, 1, 0x56, SB.Popi_popr4, SB.Push0);
                seek(dst,i++) = pack(C.Stind_r8, "stind.r8", CT.Primitive, OT.InlineNone, 1, 0x57, SB.Popi_popr8, SB.Push0);
                seek(dst,i++) = pack(C.Stind_ref, "stind.ref", CT.Primitive, OT.InlineNone, 1, 0x51, SB.Popi_popi, SB.Push0);
                seek(dst,i++) = pack(C.Stloc, "stloc", CT.Primitive, OT.InlineVar, 2, 0xfe0e, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stloc_0, "stloc.0", CT.Macro, OT.InlineNone, 1, 0xa, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stloc_1, "stloc.1", CT.Macro, OT.InlineNone, 1, 0xb, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stloc_2, "stloc.2", CT.Macro, OT.InlineNone, 1, 0xc, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stloc_3, "stloc.3", CT.Macro, OT.InlineNone, 1, 0xd, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stloc_s, "stloc.s", CT.Macro, OT.ShortInlineVar, 1, 0x13, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stobj, "stobj", CT.Primitive, OT.InlineType, 1, 0x81, SB.Popi_pop1, SB.Push0);
                seek(dst,i++) = pack(C.Stsfld, "stsfld", CT.Objmodel, OT.InlineField, 1, 0x80, SB.Pop1, SB.Push0);
                seek(dst,i++) = pack(C.Sub, "sub", CT.Primitive, OT.InlineNone, 1, 0x59, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Sub_ovf, "sub.ovf", CT.Primitive, OT.InlineNone, 1, 0xda, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Sub_ovf_un, "sub.ovf.un", CT.Primitive, OT.InlineNone, 1, 0xdb, SB.Pop1_pop1, SB.Push1);
                seek(dst,i++) = pack(C.Switch, "switch", CT.Primitive, OT.InlineSwitch, 1, 0x45, SB.Popi, SB.Push0);
                seek(dst,i++) = pack(C.Tail, "tail.", CT.Prefix, OT.InlineNone, 2, 0xfe14, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Throw, "throw", CT.Objmodel, OT.InlineNone, 1, 0x7a, SB.Popref, SB.Push0);
                seek(dst,i++) = pack(C.Unaligned, "unaligned.", CT.Prefix, OT.ShortInlineI, 2, 0xfe12, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Unbox, "unbox", CT.Primitive, OT.InlineType, 1, 0x79, SB.Popref, SB.Pushi);
                seek(dst,i++) = pack(C.Unbox_any, "unbox.any", CT.Objmodel, OT.InlineType, 1, 0xa5, SB.Popref, SB.Push1);
                seek(dst,i++) = pack(C.Volatile, "volatile.", CT.Prefix, OT.InlineNone, 2, 0xfe13, SB.Pop0, SB.Push0);
                seek(dst,i++) = pack(C.Xor, "xor", CT.Primitive, OT.InlineNone, 1, 0x61, SB.Pop1_pop1, SB.Push1);
                return i;
            }
        }
    }
}