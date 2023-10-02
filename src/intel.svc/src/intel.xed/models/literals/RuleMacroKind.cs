//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public enum RuleMacroKind : byte
    {
        None = 0,

        nothing,

        mod0,

        mod1,

        mod2,

        mod3,

        not64,

        mode64,

        mode32,

        mode16,

        eanot16,

        eamode16,

        eamode32,

        eamode64,

        smode16,

        smode32,

        smode64,

        eosz8,

        eosz16,

        eosz32,

        eosz64,

        not_eosz16,

        eosznot64,

        rex_reqd,

        no_rex,

        reset_rex,

        rexb_prefix,

        norexb_prefix,

        rexx_prefix,

        norexx_prefix,

        rexr_prefix,

        norexr_prefix,

        rexw_prefix,

        norexw_prefix,

        W0,

        W1,

        f2_prefix,

        f3_prefix,

        repne,

        repe,

        norep,

        [Symbol("66_prefix")]
        x66_prefix,

        nof3_prefix,

        no66_prefix,

        not_refining,

        refining_f2,

        refining_f3,

        not_refining_f3,

        no_refining_prefix,

        osz_refining_prefix,

        f2_refining_prefix,

        f3_refining_prefix,

        no67_prefix,

        [Symbol("67_prefix")]
        x67_prefix,

        lock_prefix,

        nolock_prefix,

        default_ds,

        default_ss,

        default_es,

        no_seg_prefix,

        cs_prefix,

        ds_prefix,

        es_prefix,

        fs_prefix,

        gs_prefix,

        ss_prefix,

        nrmw,

        df64,

        enc,

        no_return,

        [Symbol("true")]
        @true,

        XMAP8,

        XMAP9,

        XMAPA,

        XOPV,

        VL128,

        VL256,

        VV1,

        VV0,

        VMAP0,

        V0F,

        otherwise,

        V0F38,

        V0F3A,

        VNP,

        V66,

        VF2,

        VF3,

        NOVSR,

        VL512,

        VLBAD,

        KVV,

        NOEVSR,

        NO_SPARSE_EVSR,

        EVV,

        EVEXRR_ONE,

        EMX_BROADCAST_1TO4_32,

        EMX_BROADCAST_1TO4_64,

        EMX_BROADCAST_1TO8_32,

        EMX_BROADCAST_2TO4_64,

        EMX_BROADCAST_1TO2_64,

        EMX_BROADCAST_1TO8_16,

        EMX_BROADCAST_1TO16_16,

        EMX_BROADCAST_1TO16_8,

        EMX_BROADCAST_1TO32_8,

        EMX_BROADCAST_1TO16_32,

        EMX_BROADCAST_4TO16_32,

        EMX_BROADCAST_1TO8_64,

        EMX_BROADCAST_4TO8_64,

        EMX_BROADCAST_2TO16_32,

        EMX_BROADCAST_2TO8_64,

        EMX_BROADCAST_8TO16_32,

        EMX_BROADCAST_1TO32_16,

        EMX_BROADCAST_1TO64_8,

        EMX_BROADCAST_4TO8_32,

        EMX_BROADCAST_2TO4_32,

        EMX_BROADCAST_2TO8_32,

        EMX_BROADCAST_1TO2_32,

        EMX_BROADCAST_1TO2_8,

        EMX_BROADCAST_1TO4_8,

        EMX_BROADCAST_1TO8_8,

        EMX_BROADCAST_1TO2_16,

        EMX_BROADCAST_1TO4_16,
    }
}
