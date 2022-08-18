//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MachineModes;
    using static XedLiterals;

    using M = XedModels;
    using B = System.ReadOnlySpan<bit>;
    using U2 = System.ReadOnlySpan<uint2>;
    using U3 = System.ReadOnlySpan<uint3>;
    using REGS = System.ReadOnlySpan<XedRegId>;

    partial class XedOps
    {
        public readonly struct States
        {
            public const XedVexClass MaxVexClass = XedVexClass.VV1;

            public const XedVexKind MaxVexKind = XedVexKind.VF3;

            public const M.EASZ MaxEASZ = M.EASZ.EASZNot16;

            public const M.SMODE MaxSMODE = M.SMODE.SMode64;

            public const MachineModeClass MaxMode = MachineModeClass.Default;

            public const M.SegPrefixKind MaxSegPrefixKind = M.SegPrefixKind.SS;

            public const M.RoundingKind MaxRoundingKind = M.RoundingKind.RzSae;

            public const M.RepPrefix MaxRepPrefix = M.RepPrefix.REPF3;

            public const M.LLRC MaxLLRC = M.LLRC.LLRC3;

            public const M.BCastKind MaxBCastKind = M.BCastKind.BCast_1TO4_16;

            public const AsmVL MaxVexLength = AsmVL.VL512;

            public static B DF32
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B DF64
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B NO_SCALE_DISP8
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B BCRC
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B CET
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B CLDEMOE
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B ASZ
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static ReadOnlySpan<M.EASZ> EASZ
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.EASZ>(0, (byte)MaxEASZ);
            }

            public static B IMM0
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B IMM0SIGNED
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B IMM1
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MODEP5
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MODEP55C
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B OSZ
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B LOCK
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B PREFIX66
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B NEEDREX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B NOREX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B REX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B VEX_C4
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MUST_USE_EVEX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MODE_FIRST_PREFIX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MODE_SHORT_UD0
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MPXMODE
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B REALMODE
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B P4
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B PTR
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B AGEN
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MEM0
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MEM1
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B HAS_MODRM
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B HAS_SIB
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B NEED_SIB
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B ZEROING
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B SAE
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B UBIT
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B WBNOINVD
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B NO_RETURN
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B RELBR
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B UIMM0
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B UIMM1
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B DUMMY
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B DISP
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B AMD3DNOW
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B USING_DEFAULT_SEGMENT0
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B USING_DEFAULT_SEGMENT1
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B LZCNT
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B TZCNT
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B ILDF2
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B ILDF3
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B MASK
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static ReadOnlySpan<num2> DEFAULT_SEG
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<num2>(0, num2.MaxValue);
            }

            public static ReadOnlySpan<num2> FIRST_F2F3
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<num2>(0, num2.MaxValue);
            }

            public static ReadOnlySpan<num2> LAST_F2F3
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<num2>(0, num2.MaxValue);
            }

            public static ReadOnlySpan<M.SMODE> SMODE
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.SMODE>(0, (byte)MaxSMODE);
            }

            public static ReadOnlySpan<M.RepPrefix> REP
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.RepPrefix>(0, (byte)MaxRepPrefix);
            }

            public static ReadOnlySpan<M.DispWidth> DISP_WIDTH
            {
                [MethodImpl(Inline)]
                get => new M.DispWidth[]{M.DispWidth.None, M.DispWidth.DW8, M.DispWidth.DW16, M.DispWidth.DW32, M.DispWidth.DW64};
            }

            public static ReadOnlySpan<M.DispWidth> BRDISP_WIDTH
            {
                [MethodImpl(Inline)]
                get => DISP_WIDTH;
            }

            public static ReadOnlySpan<M.DispWidth> NEED_MEMDISP
            {
                [MethodImpl(Inline)]
                get => DISP_WIDTH;
            }

            public static ReadOnlySpan<MachineModeClass> MODE
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<MachineModeClass>(0, (byte)MaxMode);
            }

            public static ReadOnlySpan<XedVexClass> VEXVALID
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<XedVexClass>(0, (byte)MaxVexClass);
            }

            public static ReadOnlySpan<XedVexKind> VEX_PREFIX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<XedVexKind>(0, (byte)MaxVexKind);
            }

            public static ReadOnlySpan<M.RoundingKind> ROUNDC
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<M.RoundingKind>(0, (byte)MaxRoundingKind);
            }

            public static ReadOnlySpan<M.LLRC> LLRC
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<M.LLRC>(0, (byte)MaxLLRC);
            }

            public static ReadOnlySpan<AsmVL> VL
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<AsmVL>(0, (byte)MaxVexLength);
            }

            public static ReadOnlySpan<M.BCastKind> BCAST
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<M.BCastKind>(0, (byte)MaxBCastKind);
            }

            public static REGS Reg0
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg1
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg2
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg3
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg4
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg5
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg6
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg7
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg8
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS Reg9
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS BASE0
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS BASE1
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS INDEX
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS SEG0
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS SEG1
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static REGS OUTREG
            {
                [MethodImpl(Inline)]
                get => Regs;
            }

            public static U2 MOD
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint2>(0, uint2.MaxValue);
            }

            public static U3 REG
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint3>(0, uint3.MaxValue);
            }

            public static U3 RM
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint3>(0, uint3.MaxValue);
            }

            public static U3 SRM
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint3>(0, uint3.MaxValue);
            }

            public static U2 SIBSCALE
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint2>(0, uint2.MaxValue);
            }

            public static U3 SIBINDEX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint3>(0, uint3.MaxValue);
            }

            public static U3 SIBBASE
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint3>(0, uint3.MaxValue);
            }

            public static B REXW
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B REXR
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B REXX
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B REXB
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B REXRR
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B VEXDEST4
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static B VEXDEST3
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<bit>(0, 1);
            }

            public static U3 VEXDEST210
            {
                [MethodImpl(Inline)]
                get => Bytes.sequential<uint3>(0, uint3.MaxValue);
            }
        }
    }
}