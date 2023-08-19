//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static sys;

    public class XedTables : WfSvc<XedTables>
    {
        XedFlows XedFlows => Wf.XedFlows();

        [MethodImpl(Inline)]
        public ref readonly T Load<T>(XedRecordType index)
            => ref @as<object,T>(DataStores[(byte)index]);

        [MethodImpl(Inline)]
        internal void Store<T>(XedRecordType kind, T data)
        {
            @as<object,T>(DataStores[(byte)kind]) = data;
            Channel.Row($"Computed {kind}", FlairKind.StatusData);
        }

        readonly object[] DataStores;

        public XedTables()
        {
            DataStores = alloc<object>(64);
        }


        public ref readonly XedWidths Widths
        {
            get
            {
                lock(DataStores)   
                {
                    if(skip(DataStores,(uint)XedRecordType.WidthLookup) == null)
                        seek(DataStores, (uint)XedRecordType.WidthLookup) = XedFlows.CalcWidths(XedDb.DocSource(XedDocKind.Widths));
                }
                return ref Load<XedWidths>(XedRecordType.WidthLookup);
            }
        }

        public ref readonly Index<InstOpDetail> InstOpDetails
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstOpDetail>>(XedRecordType.InstOpDetail);
        }

        public ref readonly Index<InstPattern> Patterns
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstPattern>>(XedRecordType.InstPattern);
        }

        public ref readonly XedRuleTables RuleTables
        {
            [MethodImpl(Inline)]
            get => ref Load<XedRuleTables>(XedRecordType.RuleTables);
        }

        public ref readonly Index<InstFieldRow> InstFields
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstFieldRow>>(XedRecordType.InstFields);
        }

        public ref readonly CellTables CellTables
        {
            [MethodImpl(Inline)]
            get => ref Load<CellTables>(XedRecordType.CellTables);
        }

        public ref readonly Index<RuleExpr> RuleExpr
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<RuleExpr>>(XedRecordType.RuleExpr);
        }

        public ref readonly CellDatasets CellDatasets
        {
            [MethodImpl(Inline)]
            get => ref Load<CellDatasets>(XedRecordType.CellDatasets);
        }

        public ref readonly Index<XedInstOpCode> OpCodes
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<XedInstOpCode>>(XedRecordType.OpCodes);
        }

        public ref readonly Index<InstIsaSpec> IsaImport
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstIsaSpec>>(XedRecordType.IsaImport);
        }

        public ref readonly Index<CpuIdSpec> CpuIdImport
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<CpuIdSpec>>(XedRecordType.CpuIdImport);
        }

        public ref readonly Index<DbTypeTable> TypeTables
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<DbTypeTable>>(XedRecordType.TypeTables);
        }

        public ref readonly Index<TypeTableRow> TypeTableRows
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<TypeTableRow>>(XedRecordType.TypeTableRows);
        }

        public ref readonly ChipMap ChipMap
        {
            [MethodImpl(Inline)]
            get => ref Load<ChipMap>(XedRecordType.ChipMap);
        }

        public ref readonly Index<FormImport> FormImports
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<FormImport>>(XedRecordType.FormImports);
        }

        public ref readonly XedRuleBlocks InstImports
        {
            [MethodImpl(Inline)]
            get => ref Load<XedRuleBlocks>(XedRecordType.InstImports);
        }

        public ref readonly Index<AsmBroadcast> AsmBroadcastDefs
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<AsmBroadcast>>(XedRecordType.AsmBroadcastDefs);
        }

        public ref readonly Index<InstOpSpec> InstOpSpecs
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstOpSpec>>(XedRecordType.InstOpSpecs);
        }

        public ref readonly ConstLookup<WidthCode,OpWidthDetail> OpWidthLookup
        {
            [MethodImpl(Inline)]
            get => ref Load<ConstLookup<WidthCode,OpWidthDetail>>(XedRecordType.WidthLookup);
        }
    }
}