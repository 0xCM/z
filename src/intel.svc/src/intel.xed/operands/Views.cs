//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using M = XedModels;
    using R = XedRules;


    partial class XedOps
    {
        public static ref readonly ConstLookup<WidthCode,OpWidthRecord> WidthLookup
        {
            [MethodImpl(Inline)]
            get => ref _WidthLookup;
        }

        public static ReadOnlySpan<M.ASZ> ASZ
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<M.ASZ>(0, (byte)MaxASZ);
        }

        public static ReadOnlySpan<AsmBaseMapKind> BaseMapKind
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<AsmBaseMapKind>(0, (byte)AsmBaseMapKind.Amd3dNow);
        }

        public static ReadOnlySpan<M.InstCategory> InstCategory
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<M.InstCategory>(0, (byte)M.CategoryKind.XSAVEOPT);
        }

        public static ReadOnlySpan<InstAttrib> InstAttrib
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<InstAttrib>(0, (byte)MaxInstAttribKind);
        }

        public static ReadOnlySpan<M.InstIsa> InstIsa
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<M.InstIsa>(0, (byte)M.InstIsaKind.XSAVES);
        }

        public static ReadOnlySpan<M.MaskReg> MaskReg
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<M.MaskReg>(0, (byte)M.MaskReg.K7);
        }

        public static ReadOnlySpan<M.ElementType> ElementType
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<M.ElementType>(0, (byte)M.ElementKind.VAR);
        }

        public static ReadOnlySpan<M.SegPrefixKind> SegPrefixKind
        {
            [MethodImpl(Inline), Op]
            get => Bytes.sequential<M.SegPrefixKind>(0, (byte)MaxSegPrefixKind);
        }

        public static ReadOnlySpan<RuleName> RuleNames
        {
            [MethodImpl(Inline), Op]
            get => R.RuleNames.View;
        }

        const M.ASZ MaxASZ = M.ASZ.a64;

        const M.SegPrefixKind MaxSegPrefixKind = M.SegPrefixKind.SS;

        const M.InstAttribKind MaxInstAttribKind = M.InstAttribKind.XMM_STATE_W;
    }
}