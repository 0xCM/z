//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedModels;

    [ApiHost,Free]
    public unsafe partial class XedRuleSeq
    {
        [MethodImpl(Inline), Op]
        public static SeqDef bind(asci32 name, RuleName[] rules)
            => new SeqDef(name, SeqEffect.BIND, rules, RuleTableKind.ENC);

        [MethodImpl(Inline), Op]
        public static SeqDef emit(asci32 name, RuleName[] rules)
            => new SeqDef(name, SeqEffect.EMIT, rules, RuleTableKind.ENC);

        [MethodImpl(Inline), Op]
        public static SeqDef def(asci32 name, RuleTableKind kind, params RuleName[] rules)
            => new SeqDef(name, SeqEffect.None, rules, kind);

        [MethodImpl(Inline), Op]
        public static SeqControl control(asci32 name, params SeqDef[] src)
            => new SeqControl(name, src);

        public static Index<SeqDef> defs()
        {
            var src = typeof(XedRuleSeq).StaticMethods().Public().WithArity(0).Where(x => x.ReturnType == typeof(SeqDef));
            var dst = alloc<SeqDef>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = (SeqDef)skip(src,i).Invoke(null, null);
            return dst;
        }

        public static Index<SeqControl> controls()
        {
            var src = typeof(XedRuleSeq).StaticMethods().Public().WithArity(0).Where(x => x.ReturnType == typeof(SeqControl));
            var dst = alloc<SeqControl>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = (SeqControl)skip(src,i).Invoke(null, null);
            return dst;
        }

        /*


        /*
        SEQUENCE XOP_ENC_BIND
            XOP_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            XOP_REXXB_ENC_BIND
            XOP_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND
        */

        /*
        SEQUENCE XOP_ENC_EMIT
            XOP_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            XOP_REXXB_ENC_EMIT
            XOP_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT

        */

/* DISP_NT()::
	DISP_WIDTH=8 DISP[dddddddd]=*  ->	emit dddddddd emit_type=letters nbits=8
	DISP_WIDTH=16 DISP[dddddddddddddddd]=*  ->	emit dddddddddddddddd emit_type=letters nbits=16
	DISP_WIDTH=32 DISP[dddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddd emit_type=letters nbits=32
	DISP_WIDTH=64 DISP[dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd emit_type=letters nbits=64
 */


        // xed_uint_t xed_encode_nonterminal_VEXED_REX_EMIT(xed_encoder_request_t* xes)
        // {
        // /* VEXED_REX()::
        // 	VEXVALID=3  ->	nt NT[XOP_ENC]
        // 	VEXVALID=0  ->	nt NT[REX_PREFIX_ENC]
        // 	VEXVALID=1  ->	nt NT[NEWVEX_ENC]
        // 	VEXVALID=2  ->	nt NT[EVEX_ENC]
        //  */
        // xed_uint_t okay=1;
        // unsigned int iform = xed_encoder_request_iforms(xes)->x_VEXED_REX;
        // /* 4 */ if (iform==4) {
        //     xed_encode_nonterminal_XOP_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // /* 1 */ if (iform==1) {
        //     xed_encode_nonterminal_REX_PREFIX_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // /* 2 */ if (iform==2) {
        //     xed_encode_nonterminal_NEWVEX_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // /* 3 */ if (iform==3) {
        //     xed_encode_nonterminal_EVEX_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // if (1) { /*otherwise*/
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // return 0; /*pacify the compiler*/
        // (void) okay;
        // (void) xes;
        // (void) iform;
        /*

        SEQUENCE NEWVEX3_ENC_BIND unused?
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND

        */
    }
}