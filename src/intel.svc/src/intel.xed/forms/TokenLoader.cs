//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using TK = XedFormToken.TokenKind;

    partial class XedForms
    {
        public readonly struct TokenLoader
        {
            public static XedFormTokens load()
            {
                var index = alloc<XedFormToken>(TokenCount);
                var i=0u;
                var names = dict<TK,HashSet<string>>();
                var tk = TK.RegClass;
                tokens(tk, RegClassNames, ref i, index);
                names[tk] = RegClassNames;

                tk = TK.OpClass;
                tokens(tk, OpClassNames, ref i, index);
                names[tk] = OpClassNames;

                tk = TK.AddressClass;
                tokens(tk, AddressClassNames, ref i, index);
                names[tk] = RegClassNames;

                tk = TK.SegRegLit;
                tokens(tk, SegRegLitNames, ref i, index);
                names[tk] = SegRegLitNames;

                tk = TK.DbRegLit;
                tokens(tk, DbRegLitNames, ref i, index);
                names[tk] = DbRegLitNames;

                tk = TK.CrRegLit;
                tokens(tk, CrRegLitNames, ref i, index);
                names[tk] = RegClassNames;

                tk = TK.Gp8RegLit;
                tokens(tk, Gp8RegLitNames, ref i, index);
                names[tk] = Gp8RegLitNames;

                tk = TK.Gp16RegLit;
                tokens(tk, Gp16RegLitNames, ref i, index);
                names[tk] = Gp16RegLitNames;

                tk = TK.Gp32RegLit;
                tokens(tk, Gp32RegLitNames, ref i, index);
                names[tk] = Gp32RegLitNames;

                tk = TK.Gp64RegLit;
                tokens(tk, Gp64RegLitNames, ref i, index);
                names[tk] = Gp64RegLitNames;

                tk = TK.IsaKind;
                tokens(tk, IsaKindNames, ref i, index);
                names[tk] = IsaKindNames;

                tk = TK.Cpuid;
                tokens(tk, CpuidNames, ref i, index);
                names[tk] = CpuidNames;

                tk = TK.NonTerm;
                tokens(tk, NonTermNames, ref i, index);
                names[tk] = NonTermNames;

                tk = TK.Field;
                tokens(tk, FieldNames, ref i, index);
                names[tk] = FieldNames;

                tk = TK.InstCategory;
                tokens(tk, InstCategoryNames, ref i, index);
                names[tk] = InstCategoryNames;

                tk = TK.RegIndex;
                tokens(tk, RegIndexNames, ref i, index);
                names[tk] = RegIndexNames;

                tk = TK.Rep;
                tokens(tk, RepNames, ref i, index);
                names[tk] = RepNames;

                tk = TK.InstClass;
                var @classes = Symbols.index<AsmInstKind>().Kinds;
                tokens(@classes, ref i, index);
                names[tk] = map(@classes, c => c.ToString()).ToHashSet();

                var ti = index.Sort();
                return new XedFormTokens(ti, offsets(ti), Symbols.index<TK>().Kinds.ToArray(), names);
            }

            static Index<TK,uint> offsets(Index<XedFormToken> src)
            {
                var kind = TK.None;
                var dst = alloc<uint>(KindCount);
                var j=0u;
                for(var i=0u; i<src.Count; i++)
                {
                    ref readonly var token = ref src[i];
                    if(token.Kind != kind)
                    {
                        kind = token.Kind;
                        seek(dst,j++) = i;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline)]
            static uint tokens(TK kind, HashSet<string> names, ref uint i, Index<XedFormToken> dst)
            {
                var i0 = i;
                var src = names.Index().Sort();
                for(var j=0; j<src.Count; j++, i++)
                    dst[i] = new XedFormToken(kind, src[j]);
                return i - i0;
            }

            [MethodImpl(Inline)]
            static uint tokens(ReadOnlySpan<AsmInstKind> classes, ref uint i, Index<XedFormToken> dst)
            {
                var i0 = i;
                for(var j=0; j<classes.Length; j++, i++)
                    dst[i] = new XedFormToken(skip(classes,j));
                return i - i0;
            }

            static HashSet<string> RegClassNames = hashset(new string[]{"GPR", "VGPR", "XMM", "YMM", "ZMM", "MASK", "DR", "CR", "SEG", "ST0", "BND"});

            static HashSet<string> OpClassNames = hashset(new string[]{"IMM", "PTR", "MEM"});

            static HashSet<string> AddressClassNames = hashset(new string[]{"NEAR", "FAR"});

            static HashSet<string> CpuidNames = hashset(new string[]{"SHA", "AVX512", "AVX512CD", "AVX512ER", "AVX512PF", "SSE4", "MMX"});

            static HashSet<string> SegRegLitNames = hashset(new string[]{"CS", "DS", "ES", "FS", "GS", "SS"});

            static HashSet<string> Gp32RegLitNames = hashset(new string[]{"EAX","ECX","EDX"});

            static HashSet<string> Gp64RegLitNames = hashset(new string[]{"RAX","RCX","RDX"});

            static HashSet<string> DbRegLitNames = hashset(new string[]{"D0", "D1", "D2", "D3"});

            static HashSet<string> CrRegLitNames = hashset(new string[]{"C0", "C1", "D5", "C6"});

            static HashSet<string> Gp16RegLitNames = hashset(new string[]{"DX", "AX"});

            static HashSet<string> Gp8RegLitNames = hashset(new string[]{"AL", "CL",});

            static HashSet<string> RegIndexNames = hashset(new string[]{"r0", "r1", "r2", "r3", "r4", "r5", "r6", "r7"});

            static HashSet<string> FieldNames = hashset(new string[]{"VL", "AGEN", "RELBR"});

            static HashSet<string> IsaKindNames = hashset(new string[]{"AMD", "XOP", "X87"});

            static HashSet<string> NonTermNames = hashset(new string[]{"OeAX", "OrAX"});

            static HashSet<string> InstCategoryNames = hashset(new string[]{"LOCK","REP", "REPE", "RESERVED", "EXCLUSIVE", "TMM", "ONE", "NOP"});

            static HashSet<string> RepNames = hashset(new string[]{"REP", "REPE", "REPNE"});

            static int TokenCount =
                  RegClassNames.Count + OpClassNames.Count + AddressClassNames.Count
                + SegRegLitNames.Count + DbRegLitNames.Count + CrRegLitNames.Count
                + Gp8RegLitNames.Count + Gp16RegLitNames.Count + Gp32RegLitNames.Count + Gp64RegLitNames.Count + RegIndexNames.Count
                + IsaKindNames.Count + CpuidNames.Count
                + NonTermNames.Count + FieldNames.Count + InstCategoryNames.Count + RepNames.Count
                + (int)Symbols.index<AsmInstKind>().Count;


            const TK LastKind = TK.Hex16Lit;

            const byte LastKindValue = (byte)LastKind;

            const byte KindCount = LastKindValue - 1;
        }
    }
}