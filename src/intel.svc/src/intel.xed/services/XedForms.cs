//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

using TK = XedFormToken.TokenKind;

public class XedForms : WfSvc<XedForms>
{
    public static bool match(string src, ReadOnlySpan<XedFormToken> tokens, out XedFormToken dst)
    {
        dst = XedFormToken.Empty;
        for(var i=0; i<tokens.Length; i++)
        {
            ref readonly var token = ref skip(tokens,i);
            if(token.Value == src)
            {
                dst = token;
                break;
            }
        }

        return dst.IsNonEmpty;
    }

    public static bool match(TK kind, string src, out XedFormToken dst)
    {
        var result = false;
        dst = XedFormToken.Empty;
        switch(kind)
        {
            case TK.InstClass:
            {
                result = XedParsers.parse(src, out XedInstClass c);
                if(result)
                    dst = new XedFormToken(c);
            }
            break;
            default:
            break;
        }
        return result;
    }

    public static int cmp(XedFormToken a, XedFormToken b)
    {
        var result = ((byte)a.Kind).CompareTo((byte)b.Kind);
        if(result == 0)
        {
            switch(a.Kind)
            {
                case TK.InstClass:
                    result = ((ushort)a.InstClassValue()).CompareTo((ushort)b.InstClassValue());
                break;
                case TK.Hex8Lit:
                    result = a.Hex8Value().CompareTo(b.Hex8Value());
                break;
                case TK.Hex16Lit:
                    result = a.Hex16Value().CompareTo(b.Hex16Value());
                break;
                default:
                    result = a.Value.CompareTo(b.Value);
                break;
            }
        }
        return result;
    }

    public static ReadOnlySpan<QueryResult> search(Index<FormImport> src, string monic, IWfChannel channel)
    {
        const string RenderPattern = "class:{0,-24} form:{1,-32} category:{2,-16} isa:{3,-16} ext:{4,-16} attribs:{5}";
        var types = Symbols.index<XedFormType>();
        var cats = Symbols.index<CategoryKind>();
        var _isa = Symbols.index<InstIsaKind>();
        var classes = Symbols.index<XedInstKind>();
        var extensions = Symbols.index<ExtensionKind>();
        var count = src.Length;
        var dst = list<QueryResult>();
        for(var i=0; i<count; i++)
        {
            ref readonly var form = ref src[i];
            if(form.InstForm.IsNonEmpty)
                continue;

            ref readonly var isa = ref _isa[form.IsaKind];
            ref readonly var ext = ref extensions[form.Extension];
            ref readonly var cat = ref cats[form.Category];

            if(form.InstClass.Classifier.Format().StartsWith(monic, StringComparison.InvariantCultureIgnoreCase))
            {
                var result = QueryResult.Empty;
                result.SearchPattern = monic;
                result.InstClass = form.InstClass;
                result.InstForm = form.InstForm;
                result.Isa = isa.Kind;
                result.Extension = ext.Kind;
                result.Attributes = form.Attributes;
                dst.Add(result);
            }
        }

        var path = XedPaths.DbTargets().Path(FS.file(monic, FS.Csv));
        var records = dst.ViewDeposited();
        channel.TableEmit(records, path);
        return records;
    }

    public static XedFormSyntax tokenize(XedInstForm src)
    {
        var parts = src.Format().Split(Chars.Underscore);
        var count = parts.Length;
        if(count == 0)
            return XedFormSyntax.Empty;

        var k=0u;
        var j=0u;
        var tokens = alloc<XedFormToken>(count);
        var @class = XedFormToken.Empty;

        if(first(parts).StartsWith("REP"))
        {
            var rep = XedFormToken.Empty;
            if(match(skip(parts,j++), TokenData.Tokens(TK.Rep), out rep))
                seek(tokens,k++) = rep;
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(XedFormToken), skip(parts,j-1)));

            if(count > 1)
            {
                if(match(TK.InstClass, skip(parts,j++), out @class))
                    seek(tokens, k++) = @class;
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(XedFormToken), skip(parts,j-1)));
            }
        }
        else
        {
            if(match(TK.InstClass, skip(parts,j++), out @class))
                seek(tokens, k++) = @class;
        }


        return new XedFormSyntax(tokens);
    }

    public readonly struct FormTokens
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
            var @classes = Symbols.index<XedInstKind>().Kinds;
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
        static uint tokens(ReadOnlySpan<XedInstKind> classes, ref uint i, Index<XedFormToken> dst)
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
            + (int)Symbols.index<XedInstKind>().Count;


        const TK LastKind = TK.Hex16Lit;

        const byte LastKindValue = (byte)LastKind;

        const byte KindCount = LastKindValue - 1;
    }    

    static XedFormTokens _Tokens;

    public static ref readonly XedFormTokens TokenData
    {
        [MethodImpl(Inline)]
        get => ref _Tokens;
    }

    static XedForms()
    {
        _Tokens = FormTokens.load();
    }
}
