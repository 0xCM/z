//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedRules
{
    public class CellTables
    {
        public static Index<RuleCellRecord> records(CellTables src)
        {
            var seq = z16;
            var dst = alloc<RuleCellRecord>(src.CellCount);
            for(var i=0; i<src.TableCount; i++)
            {
                ref readonly var table = ref src[i];
                for(var j=z16; j<table.RowCount; j++)
                {
                    ref readonly var row = ref table[j];
                    for(var k=0; k<row.CellCount; k++, seq++)
                        seek(dst,seq) = record(seq, row[k]);
                }
            }
            return dst;
        }

        static RuleCellRecord record(ushort seq, in RuleCell cell)
        {
            ref readonly var value = ref cell.Value;
            var dst = RuleCellRecord.Empty;
            dst.Seq = seq++;
            dst.Index = cell.Key.Index;
            dst.Table = cell.TableIndex;
            dst.Row = cell.RowIndex;
            dst.Col = cell.CellIndex;
            dst.Logic = cell.Logic;
            dst.Type = value.CellKind;
            dst.Kind = cell.TableKind;
            dst.Rule = cell.Rule.TableName;
            dst.Field = cell.Field;
            dst.Value = value;
            dst.Expression = XedRender.format(cell.Value);
            dst.Op = cell.Operator();
            return dst;
        }

        Index<CellTable> _Tables;

        Index<RuleCell> _Cells;

        Index<RuleIdentity> _Sigs;

        Pairings<RuleIdentity,Index<RuleCell>> _TableCells;

        public CellTables(XedRuleCells src)
        {
            TableCount = src.TableCount;
            RowCount = src.RowCount;
            CellCount = src.CellCount;
            _Tables = src.Tables();
            _Cells = src.Cells();
            _Sigs = src.Sigs();
            _TableCells = src.TableCells();
        }

        public static CellTables Empty => new CellTables(XedRuleCells.Empty);

        /// <summary>
        /// Specifies the number of defined tables
        /// </summary>
        public readonly uint TableCount;

        /// <summary>
        /// Specifies the aggregate number of table-defind rows
        /// </summary>
        public readonly uint RowCount;

        /// <summary>
        /// Specifies the aggregate number of row-defind cells
        /// </summary>
        public readonly uint CellCount;

        public ReadOnlySpan<CellTable> View
        {
            [MethodImpl(Inline)]
            get => _Tables.Edit;
        }

        public ref readonly CellTable this[int i]
        {
            [MethodImpl(Inline)]
            get => ref _Tables[i];
        }

        public ref readonly CellTable this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Tables[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => _Tables.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Tables.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => _Tables.IsNonEmpty;
        }

        /// <summary>
        /// Specifies the <see cref='RuleIdentity'/> for each defined table
        /// </summary>
        public ref readonly Index<RuleIdentity> Sigs
        {
            [MethodImpl(Inline)]
            get => ref _Sigs;
        }

        /// <summary>
        /// Returns the defined <cref='RuleCell'/> values
        /// </summary>
        [MethodImpl(Inline)]
        public ref readonly Index<RuleCell> Cells()
            => ref _Cells;

        /// <summary>
        /// Returns <see cref='RuleCell'/> values in a <see cref='CellTable'/> paired with the identifying and index-defined <see cref='RuleIdentity'>
        /// </summary>
        [MethodImpl(Inline)]
        public ref readonly Pairings<RuleIdentity,Index<RuleCell>> TableCells()
            => ref _TableCells;

        /// <summary>
        /// Returns <see cref='RuleCell'/> values in an index-identified <see cref='CellTable'/> paired with the identifying and index-defined <see cref='RuleIdentity'>
        /// </summary>
        [MethodImpl(Inline)]
        public ref readonly Paired<RuleIdentity,Index<RuleCell>> TableCells(int i)
            => ref _TableCells[i];

        /// <summary>
        /// Returns <see cref='RuleCell'/> values in an index-identified <see cref='CellTable'/> paired with the identifying and index-defined <see cref='RuleIdentity'>
        /// </summary>
        [MethodImpl(Inline)]
        public ref readonly Paired<RuleIdentity,Index<RuleCell>> TableCells(uint i)
            => ref _TableCells[i];

        /// <summary>
        /// Returns the see <cref='RuleSig'/> that is a logical identifier for an index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        [MethodImpl(Inline)]
        public ref readonly RuleIdentity Sig(int table)
            => ref _Tables[table].Sig;

        /// <summary>
        /// Returns the see <cref='RuleSig'/> that is a logical identifier for an index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        [MethodImpl(Inline)]
        public ref readonly RuleIdentity Sig(uint table)
            => ref _Tables[table].Sig;

        /// <summary>
        /// Returns the rows defined by an index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        [MethodImpl(Inline)]
        public ref readonly Index<CellRow> Rows(int table)
            => ref _Tables[table].Rows;

        /// <summary>
        /// Returns the rows defined by an index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        [MethodImpl(Inline)]
        public ref readonly Index<CellRow> Rows(uint table)
            => ref _Tables[table].Rows;

        /// <summary>
        ///  Returns the index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        /// <param name="row">The table-relative row index</param>
        [MethodImpl(Inline)]
        public ref readonly CellRow Row(int table, int row)
            => ref _Tables[table].Rows[row];

        /// <summary>
        ///  Returns the index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        /// <param name="row">The table-relative row index</param>
        [MethodImpl(Inline)]
        public ref readonly CellRow Row(uint table, uint row)
            => ref _Tables[table].Rows[row];

        /// <summary>
        /// Returns the <see cref='RuleCell'/> values defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        /// <param name="row">The table-relative row index</param>
        [MethodImpl(Inline)]
        public ref readonly Index<RuleCell> Cells(int table, int row)
            => ref _Tables[table].Rows[row].Cells;

        /// <summary>
        /// Returns the <see cref='RuleCell'/> values defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        /// <param name="row">The table-relative row index</param>
        [MethodImpl(Inline)]
        public ref readonly Index<RuleCell> Cells(uint table, uint row)
            => ref _Tables[table].Rows[row].Cells;

        /// <summary>
        /// Returns the index-identified <see cref='RuleCell'/> defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        /// <param name="row">The table-relative row index</param>
        /// <param name="cell">The row-relative cell index</param>
        [MethodImpl(Inline)]
        public ref readonly RuleCell Cell(uint table, uint row, uint cell)
            => ref _Tables[table].Rows[row].Cells[cell];

        /// <summary>
        /// Returns the index-identified <see cref='RuleCell'/> defined by an index-identified <see cref='CellRow'/> defined in index-identified <see cref='CellTable'/>
        /// </summary>
        /// <param name="table">The table index</param>
        /// <param name="row">The table-relative row index</param>
        /// <param name="cell">The row-relative cell index</param>
        [MethodImpl(Inline)]
        public ref readonly RuleCell Cell(int table, int row, int cell)
            => ref _Tables[table].Rows[row].Cells[cell];

        public string Format()
            => CellRender.Tables.format(this);

        public override string ToString()
            => Format();
    }
}
