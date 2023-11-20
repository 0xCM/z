//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using static XedModels;
using static XedFields;
using static MachineModes;
using static MachineModes.MachineModeClass;
using static XedModels.EASZ;
using static XedModels.EOSZ;
using static XedModels.SMODE;
using static XedModels.SegPrefixKind;
using static VexMapKind;
using static Asm.BroadcastKind;
using static bit;

using K = XedRules.FieldKind;
using M = XedRules.RuleMacroKind;
using P = XedModels.RepPrefix;
using D = XedModels.SegDefaultKind;
using V = XedVexKind;
using X = XopMapKind;

using static sys;

partial class XedRules
{
    [MethodImpl(Inline), Op, Closures(Closure)]
    static MacroSpec macro<T>(M name, K field, T value)
        where T : unmanaged
            => new (name, field, new MacroExpansion(field, OperatorKind.Eq, new FieldValue(field, bw64(value))));

    [MethodImpl(Inline), Op]
    static MacroSpec macro(M name, K field, MachineModeClass value)
        => new (name, field, new MacroExpansion(field, OperatorKind.Eq, new FieldValue(field, value)));

    [MethodImpl(Inline), Op]
    static MacroExpansion expansion(K field, ushort value)
        => new (field, OperatorKind.Eq, new FieldValue(field, value));

    [MethodImpl(Inline), Op]
    static MacroSpec macro(M name, K field, EASZ value)
        => new (name, field, expansion(field, (ushort)value));

    [MethodImpl(Inline), Op]
    static MacroSpec macro(M name, params FieldAssign[] a0)
        => new (name, 0, a0.Map(x => new MacroExpansion(x.Field, OperatorKind.Eq, x.Value)));

    [ApiHost("xed.rules.macros")]
    public class RuleMacros
    {
        public static ReadOnlySeq<MacroDef> defs()
        {
            var src = RuleMacros.specs();
            var count = src.Length;
            var buffer = alloc<MacroDef>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var m = ref src[i];
                var expansions = m.Expansions;
                var j=0;
                var k = m.Expansions.Count;
                ref var dst = ref seek(buffer,i);
                dst.Seq = i;
                dst.Fields = (byte)expansions.Count;
                dst.MacroName = m.Name;
                if(k >= 1)
                {
                    var e = expansions[j++];
                    dst.E0 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
                if(k >= 2)
                {
                    var e = expansions[j++];
                    dst.E1 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
                if(k >= 3)
                {
                    var e = expansions[j++];
                    dst.E2 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
                if(k >= 4)
                {
                    var e = expansions[j++];
                    dst.E3 = new MacroExpansion(e.Field, e.Operator, e.Value);

                }
                if(k >= 5)
                {
                    var e = expansions[j++];
                    dst.E4 = new MacroExpansion(e.Field, e.Operator, e.Value);
                }
            }

            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static ConstLookup<string,MacroMatch> matches()
            => Matches;

        [MethodImpl(Inline), Op]
        public static Index<MacroSpec> specs()
            => Specs;

        static Symbols<RuleMacroKind> KindSymbols;

        static Index<MacroSpec> Specs;

        static ConstLookup<RuleMacroKind,MacroSpec> Lookup;

        static ConstLookup<string,MacroMatch> Matches;

        static RuleMacros()
        {
            KindSymbols = Symbols.index<RuleMacroKind>();
            Specs = _specs();
            Matches = matches(Specs);
            Lookup = Specs.Storage.Map(x => (x.Name, x)).ToDictionary();
        }

        static Index<MacroSpec> _specs()
        {
            var src = typeof(RuleMacros).StaticMethods().Where(x => x.ReturnType == typeof(MacroSpec) && x.Parameters().Length == 0);
            var count = src.Length;
            var dst = alloc<MacroSpec>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (MacroSpec)skip(src,i).Invoke(null, sys.empty<object>());
            return dst.Sort();
        }

        [MethodImpl(Inline)]
        static MacroMatch match(RuleMacroKind macro, FieldKind field, MacroMatchKind match, string value, string expansion)
            => new (0, macro, field, match, value, expansion);

        static string expand(in MacroSpec spec)
        {
            var buffer = text.buffer();
            for(var i=0; i<spec.Expansions.Count; i++)
            {
                if(i != 0)
                    buffer.Append(Chars.Space);
                buffer.Append(spec.Expansions[i].Format());
            }
            return Require.nonempty(buffer.Emit());
        }

        static void matches(MacroSpec spec, Dictionary<string,MacroMatch> dst)
        {
            var value = XedRender.format(spec.Name);
            dst[value] = match(spec.Name, spec.Field, MacroMatchKind.Literal, value, expand(spec));
        }

        static ConstLookup<string,MacroMatch> matches(Index<MacroSpec> src)
        {
            var dst = dict<string,MacroMatch>();
            var values = list<string>();
            for(var i=0; i<src.Count; i++)
                matches(src[i], dst);
            return dst;
        }

        public static bool match(string src, out MacroMatch dst)
            => Matches.Find(src, out dst);

        public static string expand(string src)
        {
            var input = Require.nonempty(text.trim(text.despace(src)));
            var parts = sys.empty<string>();
            if(!text.contains(input,Chars.Space))
                parts = new string[]{input};
            else
                parts = text.trim(text.split(input, Chars.Space));

            var count = parts.Length;
            var output = alloc<string>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                if(Matches.Find(part, out var match))
                {
                    seek(output,i) = match.Expansion;
                }
                else
                    seek(output,i) = part;
            }

            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                if(i!=0)
                    buffer.Append(Chars.Space);
                buffer.Append(skip(output,i));
            }

            return Require.nonempty(buffer.Emit());
        }

        public static bool spec(string name, out MacroSpec dst)
        {
            if(KindSymbols.Lookup(name, out var sym))
                return Lookup.Find(sym.Kind, out dst);
            dst = MacroSpec.Empty;
            return false;
        }

        [MethodImpl(Inline), Op]
        static MacroSpec not64()
            => macro(M.not64, K.MODE, Not64);

        [MethodImpl(Inline), Op]
        static MacroSpec mode16()
            => macro(M.mode16, K.MODE, Mode16);

        [MethodImpl(Inline), Op]
        static MacroSpec mode32()
            => macro(M.mode32, K.MODE, Mode32);

        [MethodImpl(Inline), Op]
        static MacroSpec mode64()
            => macro(M.mode64, K.MODE, Mode64);

        [MethodImpl(Inline), Op]
        static MacroSpec mod0()
            => macro(M.mod0, K.MOD, 0);

        [MethodImpl(Inline), Op]
        static MacroSpec mod1()
            => macro(M.mod1, K.MOD, 1);

        [MethodImpl(Inline), Op]
        static MacroSpec mod2()
            => macro(M.mod2, K.MOD, 2);

        [MethodImpl(Inline), Op]
        static MacroSpec mod3()
            => macro(M.mod3, K.MOD, 2);

        [MethodImpl(Inline), Op]
        static MacroSpec eanot16()
            => macro(M.eanot16, K.EASZ, EASZNot16);

        [MethodImpl(Inline), Op]
        static MacroSpec eamode16()
            => macro(M.eamode16, K.EASZ, EASZ16);

        [MethodImpl(Inline), Op]
        static MacroSpec eamode32()
            => macro(M.eamode32, K.EASZ, EASZ32);

        [MethodImpl(Inline), Op]
        static MacroSpec eamode64()
            => macro(M.eamode64, K.EASZ, EASZ64);

        [MethodImpl(Inline), Op]
        static MacroSpec smode16()
            => macro(M.smode16, K.SMODE, SMode16);

        [MethodImpl(Inline), Op]
        static MacroSpec smode32()
            => macro(M.smode32, K.SMODE, SMode32);

        [MethodImpl(Inline), Op]
        static MacroSpec smode64()
            => macro(M.smode64, K.SMODE, SMode64);

        [MethodImpl(Inline), Op]
        static MacroSpec eosz8()
            => macro(M.eosz8, K.EOSZ, EOSZ8);

        [MethodImpl(Inline), Op]
        static MacroSpec eosz16()
            => macro(M.eosz16, K.EOSZ, EOSZ16);

        [MethodImpl(Inline), Op]
        static MacroSpec eosz32()
            => macro(M.eosz32, K.EOSZ, EOSZ32);

        [MethodImpl(Inline), Op]
        static MacroSpec eosz64()
            => macro(M.eosz64, K.EOSZ, EOSZ64);

        [MethodImpl(Inline), Op]
        static MacroSpec nrmw()
            => macro(M.nrmw, K.DF64, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec df64()
            => macro(M.df64, K.DF64, On);

        [MethodImpl(Inline), Op]
        public static MacroSpec rex_reqd()
            => macro(M.rex_reqd, K.REX, On);

        [MethodImpl(Inline), Op]
        static MacroSpec no_rex()
            => macro(M.no_rex, K.REX, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec reset_rex()
            =>  macro(M.reset_rex,
                assign(K.REX, Off),
                assign(K.REXW, Off),
                assign(K.REXB, Off),
                assign(K.REXR, Off),
                assign(K.REXX, Off)
                );

        [MethodImpl(Inline), Op]
        static MacroSpec rexb_prefix()
            => macro(M.rexb_prefix, K.REXB, On);

        [MethodImpl(Inline), Op]
        static MacroSpec norexb_prefix()
            => macro(M.norexb_prefix, K.REXB, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec rexx_prefix()
            => macro(M.rexx_prefix, K.REXX, On);

        [MethodImpl(Inline), Op]
        static MacroSpec norexx_prefix()
            => macro(M.norexx_prefix, K.REXX, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec rexr_prefix()
            => macro(M.rexr_prefix, K.REXR, On);

        [MethodImpl(Inline), Op]
        static MacroSpec norexr_prefix()
            => macro(M.norexr_prefix, K.REXR, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec rexw_prefix()
            => macro(M.rexw_prefix, K.REXW, On);

        [MethodImpl(Inline), Op]
        static MacroSpec norexw_prefix()
            => macro(M.norexw_prefix, K.REXW, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec W0()
            => macro(M.W0, K.REXW, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec W1()
            => macro(M.W1, K.REXW, On);

        [MethodImpl(Inline), Op]
        static MacroSpec VL128()
            => macro(M.VL128, K.VL, AsmVL.VL128);

        [MethodImpl(Inline), Op]
        static MacroSpec VL256()
            => macro(M.VL256, K.VL, AsmVL.VL256);

        [MethodImpl(Inline), Op]
        static MacroSpec VL512()
            => macro(M.VL512, K.VL, AsmVL.VL512);

        [MethodImpl(Inline), Op]
        static MacroSpec VV0()
            => macro(M.VV0, K.VEXVALID, VexValid.None);

        [MethodImpl(Inline), Op]
        static MacroSpec VV1()
            => macro(M.VV1, K.VEXVALID, VexValid.VV1);

        [MethodImpl(Inline), Op]
        static MacroSpec EVV()
            => macro(M.EVV, K.VEXVALID, VexValid.EVV);

        [MethodImpl(Inline), Op]
        static MacroSpec XOPV()
            => macro(M.XOPV, K.VEXVALID, VexValid.XOPV);

        [MethodImpl(Inline), Op]
        static MacroSpec VNP()
            => macro(M.VNP, K.VEX_PREFIX, V.VNP);

        [MethodImpl(Inline), Op]
        static MacroSpec V66()
            => macro(M.V66, K.VEX_PREFIX, V.V66);

        [MethodImpl(Inline), Op]
        static MacroSpec VF2()
            => macro(M.VF2, K.VEX_PREFIX, V.VF2);

        [MethodImpl(Inline), Op]
        static MacroSpec VF3()
            => macro(M.VF3, K.VEX_PREFIX, V.VF3);

        [MethodImpl(Inline), Op]
        static MacroSpec NOVSR()
            => macro(M.NOVSR, assign(K.VEXDEST3, 1), assign(K.VEXDEST210, 0b111));

        [MethodImpl(Inline), Op]
        static MacroSpec NOEVSR()
            => macro(M.NOEVSR, assign(K.VEXDEST3, 1), assign(K.VEXDEST210, 0b111), assign(K.VEXDEST4,0));

        [MethodImpl(Inline), Op]
        static MacroSpec NO_SPARSE_EVSR()
            => macro(M.NO_SPARSE_EVSR, assign(K.VEXDEST3, 1), assign(K.VEXDEST210, 0b111));

        [MethodImpl(Inline), Op]
        static MacroSpec EVEXRR_ONE()
            => macro(M.EVEXRR_ONE, K.REXRR, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec VLBAD()
            => macro(M.VLBAD, K.VL, AsmVL.Invalid);

        [MethodImpl(Inline), Op]
        static MacroSpec VMAP0()
            => macro(M.VMAP0, K.MAP, 0);

        [MethodImpl(Inline), Op]
        static MacroSpec V0F()
            => macro(M.V0F, K.MAP, VEX_MAP_0F);

        [MethodImpl(Inline), Op]
        static MacroSpec V0F38()
            => macro(M.V0F38, K.MAP, VEX_MAP_0F38);

        [MethodImpl(Inline), Op]
        static MacroSpec V0F3A()
            => macro(M.V0F3A, K.MAP, VEX_MAP_0F3A);

        [MethodImpl(Inline), Op]
        static MacroSpec XMAP8()
            => macro(M.XMAP8, K.MAP, X.Xop8);

        [MethodImpl(Inline), Op]
        static MacroSpec XMAP9()
            => macro(M.XMAP9, K.MAP, X.Xop9);

        [MethodImpl(Inline), Op]
        static MacroSpec XMAPA()
            => macro(M.XMAPA, K.MAP, X.XopA);

        [MethodImpl(Inline), Op]
        static MacroSpec no67_prefix()
            => macro(M.no67_prefix, K.ASZ, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec x67_prefix()
            => macro(M.x67_prefix, K.ASZ, On);

        [MethodImpl(Inline), Op]
        static MacroSpec x66_prefix()
            => macro(M.x66_prefix, K.OSZ, EOSZ16);

        [MethodImpl(Inline), Op]
        static MacroSpec no66_prefix()
            => macro(M.no66_prefix, K.OSZ, EOSZ8);

        [MethodImpl(Inline), Op]
        static MacroSpec f2_prefix()
            => macro(M.f2_prefix, K.REP, P.REPF2);

        [MethodImpl(Inline), Op]
        static MacroSpec f3_prefix()
            => macro(M.f3_prefix, K.REP, P.REPF3);

        [MethodImpl(Inline), Op]
        static MacroSpec repne()
            => macro(M.repne, K.REP, P.REPF2);

        [MethodImpl(Inline), Op]
        static MacroSpec repn()
            => macro(M.repe, K.REP, P.REPF3);

        [MethodImpl(Inline), Op]
        static MacroSpec norep()
            => macro(M.norep, K.REP, P.None);

        [MethodImpl(Inline), Op]
        static MacroSpec nof3_prefix()
            => macro(M.nof3_prefix, K.REP, P.NOF3);

        [MethodImpl(Inline), Op]
        static MacroSpec not_refining()
            => macro(M.not_refining, K.REP, P.None);

        [MethodImpl(Inline), Op]
        static MacroSpec refining_f2()
            => macro(M.refining_f2, K.REP, P.REPF2);

        [MethodImpl(Inline), Op]
        static MacroSpec refining_f3()
            => macro(M.refining_f3, K.REP, P.REPF3);

        [MethodImpl(Inline), Op]
        static MacroSpec not_refining_f3()
            => macro(M.not_refining_f3, K.REP, P.NOF3);

        [MethodImpl(Inline), Op]
        static MacroSpec no_refining_prefix()
            => macro(M.no_refining_prefix,
                assign(K.REP, P.None),
                assign(K.EOSZ, EOSZ16)
                );

        [MethodImpl(Inline), Op]
        static MacroSpec osz_refining_prefix()
            => macro(M.osz_refining_prefix,
                assign(K.REP, P.None),
                assign(K.EOSZ, EOSZ8)
                );

        [MethodImpl(Inline), Op]
        static MacroSpec f2_refining_prefix()
            => macro(M.f2_refining_prefix, K.REP, P.REPF2);

        [MethodImpl(Inline), Op]
        static MacroSpec f3_refining_prefix()
            => macro(M.f3_refining_prefix, K.REP, P.REPF3);

        [MethodImpl(Inline), Op]
        static MacroSpec lock_prefix()
            => macro(M.lock_prefix, K.LOCK, On);

        [MethodImpl(Inline), Op]
        static MacroSpec nolock_prefix()
            => macro(M.nolock_prefix, K.LOCK, Off);

        [MethodImpl(Inline), Op]
        static MacroSpec default_ds()
            => macro(M.default_ds, K.DEFAULT_SEG, D.DefaultDS);

        [MethodImpl(Inline), Op]
        static MacroSpec default_ss()
            => macro(M.default_ss, K.DEFAULT_SEG, D.DefaultSS);

        [MethodImpl(Inline), Op]
        static MacroSpec default_es()
            => macro(M.default_es, K.DEFAULT_SEG, D.DefaultES);

        [MethodImpl(Inline), Op]
        static MacroSpec no_seg_prefix()
            => macro(M.no_seg_prefix, K.SEG_OVD, 0);

        [MethodImpl(Inline), Op]
        static MacroSpec cs_prefix()
            => macro(M.cs_prefix, K.SEG_OVD, CS);

        [MethodImpl(Inline), Op]
        static MacroSpec ds_prefix()
            => macro(M.ds_prefix, K.SEG_OVD, DS);

        [MethodImpl(Inline), Op]
        static MacroSpec es_prefix()
            => macro(M.es_prefix, K.SEG_OVD, ES);

        [MethodImpl(Inline), Op]
        static MacroSpec fs_prefix()
            => macro(M.fs_prefix, K.SEG_OVD, SegPrefixKind.FS);

        [MethodImpl(Inline), Op]
        static MacroSpec gs_prefix()
            => macro(M.gs_prefix, K.SEG_OVD, GS);

        [MethodImpl(Inline), Op]
        static MacroSpec ss_prefix()
            => macro(M.ss_prefix, K.SEG_OVD, SS);

        [MethodImpl(Inline), Op]
        static MacroSpec enc()
            => macro(M.enc, K.ENCODER_PREFERRED, 1);

        [MethodImpl(Inline), Op]
        static MacroSpec no_return()
            => macro(M.no_return, K.NO_RETURN, 1);

        [MethodImpl(Inline), Op]
        static MacroSpec @true()
            => macro(M.@true, K.DUMMY, 0);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO2_8()
            => macro(M.EMX_BROADCAST_1TO2_8, K.BCAST, BCast_1TO2_8);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO4_8()
            => macro(M.EMX_BROADCAST_1TO4_8, K.BCAST, BCast_1TO4_8);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO8_8()
            => macro(M.EMX_BROADCAST_1TO8_8, K.BCAST, BCast_1TO8_8);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO16_8()
            => macro(M.EMX_BROADCAST_1TO16_8, K.BCAST, BCast_1TO16_8);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO32_8()
            => macro(M.EMX_BROADCAST_1TO32_8, K.BCAST, BCast_1TO32_8);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO64_8()
            => macro(M.EMX_BROADCAST_1TO64_8, K.BCAST, BCast_1TO64_8);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO2_16()
            => macro(M.EMX_BROADCAST_1TO2_16, K.BCAST, BCast_1TO2_16);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO4_16()
            => macro(M.EMX_BROADCAST_1TO4_16, K.BCAST, BCast_1TO4_16);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO8_16()
            => macro(M.EMX_BROADCAST_1TO8_16, K.BCAST, BCast_1TO8_16);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO16_16()
            => macro(M.EMX_BROADCAST_1TO16_16, K.BCAST, BCast_1TO16_16);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO32_16()
            => macro(M.EMX_BROADCAST_1TO32_16, K.BCAST, BCast_1TO32_16);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO2_32()
            => macro(M.EMX_BROADCAST_1TO2_32, K.BCAST, BCast_1TO2_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO4_32()
            => macro(M.EMX_BROADCAST_1TO4_32, K.BCAST, BCast_1TO4_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO8_32()
            => macro(M.EMX_BROADCAST_1TO8_32, K.BCAST, BCast_1TO8_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO16_32()
            => macro(M.EMX_BROADCAST_1TO16_32, K.BCAST, BCast_1TO16_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_2TO4_32()
            => macro(M.EMX_BROADCAST_2TO4_32, K.BCAST, BCast_2TO4_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_2TO8_32()
            => macro(M.EMX_BROADCAST_2TO8_32, K.BCAST, BCast_2TO8_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_2TO16_32()
            => macro(M.EMX_BROADCAST_2TO16_32, K.BCAST, BCast_2TO16_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_4TO8_32()
            => macro(M.EMX_BROADCAST_4TO8_32, K.BCAST, BCast_4TO8_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_4TO16_32()
            => macro(M.EMX_BROADCAST_4TO16_32, K.BCAST, BCast_4TO16_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_8TO16_32()
            => macro(M.EMX_BROADCAST_8TO16_32, K.BCAST, BCast_8TO16_32);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO2_64()
            => macro(M.EMX_BROADCAST_1TO2_64, K.BCAST, BCast_1TO2_64);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO4_64()
            => macro(M.EMX_BROADCAST_1TO4_64, K.BCAST, BCast_1TO4_64);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_1TO8_64()
            => macro(M.EMX_BROADCAST_1TO8_64, K.BCAST, BCast_1TO8_64);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_2TO4_64()
            => macro(M.EMX_BROADCAST_2TO4_64, K.BCAST, BCast_2TO4_64);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_2TO8_64()
            => macro(M.EMX_BROADCAST_2TO8_64, K.BCAST, BCast_2TO8_64);

        [MethodImpl(Inline), Op]
        static MacroSpec EMX_BROADCAST_4TO8_64()
            => macro(M.EMX_BROADCAST_4TO8_64, K.BCAST, BCast_4TO8_64);
    }
}
