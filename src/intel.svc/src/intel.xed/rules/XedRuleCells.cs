//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;
using static XedRules;

public class XedRuleCells
{
    public static XedRuleCells create(Dictionary<RuleSig,Index<RuleCell>> src, string desc)
    {
        var dst = new XedRuleCells();
        var keys = src.Keys;
        var tables = keys.Select(sig => table(src.ToConcurrentDictionary(), sig)).Array();
        dst._RawFormat = desc;
        dst.TableCount = (uint)tables.Length;
        dst.RowCount = tables.Select(x => x.RowCount).Sum();
        dst.CellCount = tables.Select(x => x.CellCount).Sum();
        dst._Tables = tables.Sort();
        dst._Cells = tables.SelectMany(x => x.Rows.SelectMany(x => x.Cells)).Sort();
        dst._Sigs = tables.Select(x => x.Sig).Sort();
        dst._TableCells = Tuples.pairings(src.Map(x => Tuples.paired(x.Key,x.Value)));
        return dst;
    }

    static CellTable table(ConcurrentDictionary<RuleSig,Index<RuleCell>> src, RuleSig rule)
    {
        var dst = CellTable.Empty;
        if(src.TryGetValue(rule, out var cells))
        {
            var i = z16;
            if(cells.Count !=0)
            {
                i = cells.First.TableIndex;
                var rows = cells.GroupBy(x => x.RowIndex).Select(x => (new CellRow(rule, i, x.Key, x.ToIndex()))).ToIndex();
                dst = new CellTable(rule, i, rows);
            }
        }
        return dst;
    }

    XedRuleCells()
    {
        _Tables = sys.empty<CellTable>();
        _Cells = sys.empty<RuleCell>();
        _Sigs = sys.empty<RuleSig>();
        _RawFormat = EmptyString;
        _TableCells = Pairings.empty<RuleSig,Index<RuleCell>>();
    }

    Index<CellTable> _Tables;

    Index<RuleCell> _Cells;

    Index<RuleSig> _Sigs;

    Pairings<RuleSig,Index<RuleCell>> _TableCells;

    string _RawFormat;

    public uint TableCount;

    public uint RowCount;

    public uint CellCount;

    public ref readonly string RawFormat
    {
        [MethodImpl(Inline)]
        get => ref _RawFormat;
    }

    [MethodImpl(Inline)]
    public ref readonly Index<CellTable> Tables()
        => ref _Tables;

    [MethodImpl(Inline)]
    public ref readonly Index<RuleSig> Sigs()
        => ref _Sigs;

    [MethodImpl(Inline)]
    public ref readonly Index<RuleCell> Cells()
        => ref _Cells;

    [MethodImpl(Inline)]
    public ref readonly Pairings<RuleSig,Index<RuleCell>> TableCells()
        => ref _TableCells;

    public static XedRuleCells Empty => new();
}
