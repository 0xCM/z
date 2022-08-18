//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedDb : WfSvc<XedDb>
    {
        static XedPaths Paths => XedPaths.Service;

        static ConcurrentDictionary<FS.FilePath,MemoryFile> _MemoryFiles = new();

        static FS.FilePath InstDumpSource()
            => Paths.Sources() + FS.file("xed-dump", FileKind.Txt.Ext());

        public static MemoryFile MemoryFile(FS.FilePath src)
            => _MemoryFiles.GetOrAdd(src, path => path.MemoryMap(true));

        public static MemoryFile InstDumpFile()
            => MemoryFile(InstDumpSource());

        IMemDb _Store;

        XedRuntime Xed;

        public XedDb With(XedRuntime xed)
        {
            Xed = xed;
            _Store = MemDb.open(AppDb.DbOut("memdb").Path("runtime", FileKind.Bin), new Gb(1));
            return this;
        }

        public IMemDb Store
        {
            [MethodImpl(Inline)]
            get => _Store;
        }

        ref readonly CellTables CellTables => ref Xed.Views.CellTables;

        ref readonly Index<InstPattern> Patterns => ref Xed.Views.Patterns;

        public void EmitLayouts()
            => Emit(CalcLayouts(Patterns));

        void Emit(InstLayouts src)
        {
            FileEmit(src.Format(), 0, Paths.InstTarget("layouts.vectors", FileKind.Csv));
            TableEmit(src.Records.View, InstLayoutRecord.RenderWidths, Paths.InstTable<InstLayoutRecord>());
        }

        public InstLayouts CalcLayouts(Index<InstPattern> src)
            => Data(nameof(CalcLayouts), () => LayoutCalcs.layouts(src));

        public LayoutVectors CalcLayoutVectors(InstLayouts src)
            => Data(nameof(CalcLayoutVectors), () => LayoutCalcs.vectors(src));

        public XedRules Rules => Xed.Rules;
    }
}