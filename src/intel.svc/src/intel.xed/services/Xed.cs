//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;    
using static XedModels;
using static XedRules;

using K = XedModels.OpKind;
using I = Asm.RFlagSymbol;

public partial class Xed : WfSvc<Xed>
{
    [MethodImpl(Inline), Op]
    public static NontermCall<T> call<T>(T src, RuleSig dst)
        where T : unmanaged, IComparable<T>
            => new (src,dst);

    public static XedInstClass classifier(XedInstClass src)
    {
        var dst = src;
        var name = src.Format();
        if(name.EndsWith("_LOCK"))
            XedParsers.parse(name.Remove("_LOCK"), out dst);
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static int cmp(in CellKey a, in CellKey b)
    {
        var result = a.Table.CompareTo(b.Table);
        if(result == 0)
        {
            result = a.Row.CompareTo(b.Row);
            if(result == 0)
                result = a.Col.CompareTo(b.Col);
        }
        return result;
    }

    [MethodImpl(Inline), Op]
    public static int cmp(LogicKind a, LogicKind b)
        => ((byte)a).CompareTo((byte)b);

    [MethodImpl(Inline), Op]
    public static int cmp(RuleName a, RuleName b)
        => ((ushort)a).CompareTo((ushort)b);

    [MethodImpl(Inline), Op]
    public static int cmp(XedModels.RepPrefix a, XedModels.RepPrefix b)
        => ((byte)a).CompareTo((byte)b);

    [MethodImpl(Inline), Op]
    public static int cmp(RuleTableKind a, RuleTableKind b)
        => ((byte)b).CompareTo((byte)a);

    [MethodImpl(Inline), Op]
    public static int cmp(OperatorKind a, OperatorKind b)
        => ((byte)b).CompareTo((byte)a);

    [MethodImpl(Inline), Op]
    public static int cmp(FieldKind a, FieldKind b)
        => ((byte)a).CompareTo((byte)b);

    [MethodImpl(Inline), Op]
    public static int cmp(OpKind a, OpKind b)
    {
        ref readonly var x = ref skip(OpKindOrder,(byte)a);
        ref readonly var y = ref skip(OpKindOrder,(byte)b);
        return x.CompareTo(y);
    }

    [MethodImpl(Inline), Op]
    public static int cmp(WidthCode a, WidthCode b)
        => ((byte)a).CompareTo((byte)b);

    public static int cmp(InstOpClass a, InstOpClass b)
    {
        var result = Xed.cmp(a.Kind,b.Kind);
        if(result == 0)
            result = a.BitWidth.CompareTo(b.BitWidth);
        if(result == 0)
            result = a.IsRegLit.CompareTo(b.IsRegLit);
        if(result == 0)
            result = a.IsRule.CompareTo(b.IsRule);
        if(result == 0)
            result = a.ElementCount.CompareTo(b.ElementCount);
        if(result == 0)
            result = a.ElementType.CompareTo(b.ElementType);
        if(result == 0)
            result = cmp(a.WidthCode, b.WidthCode);
        return result;
    }

    [MethodImpl(Inline)]
    public static int cmp(in XedInstOpCode a, in XedInstOpCode b)
        => new PatternOrder().Compare(a,b);

    static ReadOnlySpan<byte> OpKindOrder => new byte[(byte)K.Seg + 1]{
        0,   // None:0 -> 0
        7,   // Agen:1 -> 7
        5,   // Base:2 -> 5
        11,  // Disp:3 -> 11
        3,   // Imm:4 -> 3
        9,   // Index:5 -> 9
        2,   // Mem:6 -> 2,
        8,   // Ptr:7 -> 8,
        1,   // Reg:8 -> 1,
        4,   // RelBr:9 -> 4,
        10,  // Scale:10 -> 10,
        6,   // Seg:11 -> 6
        };


        [Op]
    public static bool convert(XedFlagEffect src, out FlagEffect dst)
    {
        var index = z8i;
        switch(src.Flag)
        {
            case XedRegFlag._if:
                index = (sbyte)I.IF;
            break;
            case XedRegFlag.ac:
                index = (sbyte)I.AC;
            break;

            case XedRegFlag.af:
                index = (sbyte)I.AF;
            break;

            case XedRegFlag.cf:
                index = (sbyte)I.CF;
            break;

            case XedRegFlag.df:
                index = (sbyte)I.DF;
            break;

            case XedRegFlag.id:
                index = (sbyte)I.ID;
            break;
            case XedRegFlag.of:
                index = (sbyte)I.OF;
            break;
            case XedRegFlag.pf:
                index = (sbyte)I.PF;
            break;
            case XedRegFlag.rf:
                index = (sbyte)I.RF;
            break;
            case XedRegFlag.sf:
                index = (sbyte)I.SF;
            break;
            case XedRegFlag.tf:
                index = (sbyte)I.TF;
            break;
            case XedRegFlag.vif:
                index = (sbyte)I.VIF;
            break;
            case XedRegFlag.vip:
                index = (sbyte)I.VIP;
            break;
            case XedRegFlag.vm:
                index = (sbyte)I.VM;
            break;
            case XedRegFlag.zf:
                index = (sbyte)I.ZF;
            break;

            case XedRegFlag.nt:
            case XedRegFlag.iopl:
            case XedRegFlag.fc0:
            case XedRegFlag.fc1:
            case XedRegFlag.fc2:
            case XedRegFlag.fc3:
            break;
        }

        var result = index >= 0;
        if(result)
            dst = new FlagEffect(RFlags.bits((I)index), src.Effect);
        else
            dst = default;
        return result;
    }

    [Op]
    public static Index<RuleSig> sigs(params (RuleTableKind kind, RuleName rule)[] src)
        => src.Select(x => new RuleSig(x.kind,x.rule));

    [MethodImpl(Inline), Op]
    public static CellExpr expr(OperatorKind op, FieldValue value)
        => new (op,value);

    [MethodImpl(Inline), Op]
    public static RowExpr expr(Index<RuleCell> src)
        => new RowExpr(src);

    public static XedKit kit()
        => new XedKit(AppSettings.Sdks().Scoped("intel/xed"));

    public static Index<FieldUsage> fields(CellTables src)
    {
        var buffer = sys.bag<FieldUsage>();
        iter(src.View, table => collect(table,buffer),true);
        return buffer.Index().Sort();
    }

    static void collect(in CellTable src, ConcurrentBag<FieldUsage> dst)
    {
        ref readonly var rows = ref src.Rows;
        var usage = hashset<FieldUsage>();
        var sig = src.Sig;
        for(var i=0; i<rows.Count; i++)
        {
            ref readonly var row = ref rows[i];
            var antecedants = row.Antecedants();
            for(var j=0; j<antecedants.Length; j++)
            {
                ref readonly var antecedant = ref skip(antecedants,j);
                if(antecedant.Field != 0)
                    usage.Add(FieldUsage.left(sig, antecedant.Field));
            }

            var consequents = row.Consequents();
            for(var j=0; j<consequents.Length; j++)
            {
                ref readonly var consequent = ref skip(consequents,j);
                if(consequent.Field != 0)
                    usage.Add(FieldUsage.right(sig, consequent.Field));
            }
        }

        iter(usage, u => dst.Add(u));
    }
        
    public static Index<RuleTableBlock> blocks(RuleTableKind kind)
    {
        var src = XedDb.RuleSource(kind);
        var lines = src.ReadNumberedLines();
        var offsets = list<LineNumber>();
        var names = list<string>();
        for(var i=0u; i<lines.Count; i++)
        {
            ref readonly var line = ref lines[i];
            var data = text.trim(text.despace(line.Content));
            if(text.empty(data) || text.begins(data, Chars.Hash))
                continue;

            var j = text.index(data,Chars.Hash);
            var content = (j > 0 ? text.left(data,j) : data).Trim();
            if(text.ends(content,"()::"))
            {
                var k = text.index(content, Chars.LParen);
                var name = text.left(content,k);
                names.Add(name.Remove("xed_reg_enum_t").Trim());
                offsets.Add(line.LineNumber);
            }
        }

        var dst = alloc<RuleTableBlock>(names.Count);
        var pos = 0;
        var view = lines.View;
        for(var i=0; i<names.Count; i++)
        {
            var name = names[i];
            var i0 = offsets[i];
            ref var target = ref seek(dst,i);
            if(i < names.Count - 1)
            {
                var i1 = offsets[i+1];
                var seg = sys.segment(view, i0, i1 - 1);
                var parts = list<TextLine>();
                for(var j=0; j<seg.Length; j++)
                {
                    ref readonly var line = ref skip(seg,j);
                    var part = text.trim(text.despace(line.Content));
                    if(text.empty(part) || text.begins(part,Chars.Hash) || text.ends(part, "::") || text.ends(part, "()") || text.begins(part, "SEQUENCE "))
                        continue;

                    var k = text.index(part,Chars.Hash);
                    if(k>0)
                        parts.Add((line.LineNumber,text.left(part,k)));
                    else
                        parts.Add((line.LineNumber,part));
                }
                target = new RuleTableBlock(kind, name, i0, parts.ToArray());
            }
            else
            {
                var seg = sys.slice(view, i0);
                var parts = list<TextLine>();
                for(var j=0; j<seg.Length; j++)
                {
                    ref readonly var line = ref skip(seg,j);
                    var part = text.trim(text.despace(line.Content));
                    if(text.empty(part) || text.begins(part,Chars.Hash))
                        continue;
                    parts.Add((line.LineNumber,part));
                }
                target = new RuleTableBlock(kind, name, i0, parts.ToArray());
            }
        }

        return dst.Sort();
    }    
}