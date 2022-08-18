//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedImport;
    using static MemDb;
    using static core;

    public class XedViews
    {
        [MethodImpl(Inline)]
        public ref readonly T Load<T>(XedRecord index)
            => ref @as<object,T>(DataStores[(byte)index]);

        [MethodImpl(Inline)]
        internal void Store<T>(XedRecord kind, T data)
        {
            @as<object,T>(DataStores[(byte)kind]) = data;
            Emit.Status(FlairKind.StatusData, $"Computed {kind}");
        }

        readonly Index<object> DataStores;

        readonly XedRuntime Xed;

        readonly WfEmit Emit;

        internal XedViews(XedRuntime xed, Func<WfEmit> svc)
        {
            Emit = svc();
            Xed = xed;
            DataStores = alloc<object>(32);
        }

        public ref readonly Index<InstOpDetail> InstOpDetails
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstOpDetail>>(XedRecord.InstOpDetail);
        }

        public ref readonly Index<InstPattern> Patterns
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstPattern>>(XedRecord.InstPattern);
        }

        public ref readonly RuleTables RuleTables
        {
            [MethodImpl(Inline)]
            get => ref Load<RuleTables>(XedRecord.RuleTables);
        }

        public ref readonly Index<InstFieldRow> InstFields
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstFieldRow>>(XedRecord.InstFields);
        }

        public ref readonly CellTables CellTables
        {
            [MethodImpl(Inline)]
            get => ref Load<CellTables>(XedRecord.CellTables);
        }

        public ref readonly Index<RuleExpr> RuleExpr
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<RuleExpr>>(XedRecord.RuleExpr);
        }

        public ref readonly CellDatasets CellDatasets
        {
            [MethodImpl(Inline)]
            get => ref Load<CellDatasets>(XedRecord.CellDatasets);
        }

        public ref readonly Index<XedInstOpCode> OpCodes
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<XedInstOpCode>>(XedRecord.OpCodes);
        }

        public ref readonly Index<IsaImport> IsaImport
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<IsaImport>>(XedRecord.IsaImport);
        }

        public ref readonly Index<CpuIdImport> CpuIdImport
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<CpuIdImport>>(XedRecord.CpuIdImport);
        }

        public ref readonly Index<DbTypeTable> TypeTables
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<DbTypeTable>>(XedRecord.TypeTables);
        }

        public ref readonly Index<TypeTableRow> TypeTableRows
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<TypeTableRow>>(XedRecord.TypeTableRows);
        }

        public ref readonly ChipMap ChipMap
        {
            [MethodImpl(Inline)]
            get => ref Load<ChipMap>(XedRecord.ChipMap);
        }

        public ref readonly Index<FormImport> FormImports
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<FormImport>>(XedRecord.FormImports);
        }

        public ref readonly InstImportBlocks InstImports
        {
            [MethodImpl(Inline)]
            get => ref Load<InstImportBlocks>(XedRecord.InstImports);
        }

        public ref readonly Index<AsmBroadcast> AsmBroadcastDefs
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<AsmBroadcast>>(XedRecord.AsmBroadcastDefs);
        }

        public ref readonly Index<OpWidthRecord> OpWidths
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<OpWidthRecord>>(XedRecord.OpWidths);
        }

        public ref readonly Index<InstOpSpec> InstOpSpecs
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstOpSpec>>(XedRecord.InstOpSpecs);
        }

        public ref readonly ConstLookup<OpWidthCode,OpWidthRecord> OpWidthLookup
        {
            [MethodImpl(Inline)]
            get => ref Load<ConstLookup<OpWidthCode,OpWidthRecord>>(XedRecord.WidthLookup);
        }
    }
}