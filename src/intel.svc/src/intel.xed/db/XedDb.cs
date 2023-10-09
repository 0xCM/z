//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    public partial class XedDb : WfSvc<XedDb>
    {
        static readonly ConcurrentDictionary<FilePath,MemoryFile> _MemoryFiles = new();

        public static MemoryFile MemoryFile(FilePath src)
            => _MemoryFiles.GetOrAdd(src, path => path.MemoryMap(true));

        public static MemoryFile RuleDumpFile()
            => MemoryFile(XedPaths.DocSource(XedDocKind.RuleBlocks));
        
        IMemDb _Store;

        XedRuntime Xed => Wf.XedRuntime();

        object _StoreLock = new();
        
        public IMemDb Store
        {
            [MethodImpl(Inline)]
            get 
            {
                lock(_StoreLock)
                {
                    if(_Store == null)
                    {
                        _Store = MemDb.open(AppDb.DbTargets("memdb").Path("runtime", FileKind.Bin), new Gb(1));
                    }
                }
                return _Store;
            }
        }

        public void EmitLayouts(ReadOnlySeq<InstPattern> src)
            => Emit(CalcLayouts(src));

        void Emit(InstLayouts src)
        {
            Channel.FileEmit(src.Format(), 0, XedPaths.InstTarget("layouts.vectors", FileKind.Csv));
            Channel.TableEmit(src.Records.View, XedPaths.ImportTable<InstLayoutRecord>(), TextEncodingKind.Asci);
        }

        public InstLayouts CalcLayouts(ReadOnlySeq<InstPattern> src)
            => Data(nameof(CalcLayouts), () => LayoutCalcs.layouts(src));

        public LayoutVectors CalcLayoutVectors(InstLayouts src)
            => Data(nameof(CalcLayoutVectors), () => LayoutCalcs.vectors(src));

    }
}