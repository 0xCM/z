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
        static XedPaths Paths => XedPaths.Service;


        static readonly ConcurrentDictionary<FilePath,MemoryFile> _MemoryFiles = new();

        public static MemoryFile MemoryFile(FilePath src)
            => _MemoryFiles.GetOrAdd(src, path => path.MemoryMap(true));

        public static MemoryFile RuleDumpFile()
            => MemoryFile(DocSource(XedDocKind.RuleBlocks));
        
        //public IDbArchive Sources() => Paths.DbTargets
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

        public static IDbArchive Targets()
            => Paths.Targets();

        public static IDbArchive Sources()
            => Paths.Sources();

        public static IDbArchive DocTargets()
            => Targets().Scoped("docs");

        public static FilePath DocTarget(string name, FileKind kind)
            => DocTargets().Path(FS.file(string.Format("xed.docs.{0}", name), kind.Ext()));

        static readonly FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

        static readonly FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

        static readonly FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

        static readonly FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

        static readonly FileName EncDecRuleTable = FS.file("all-enc-dec-patterns", FS.Txt);

        public static FilePath RuleSource(RuleTableKind kind)
        {
            var tk = kind switch
            {
                RuleTableKind.ENC => XedDocKind.EncRuleTable,
                RuleTableKind.DEC => XedDocKind.DecRuleTable,
                _ => XedDocKind.None
            };

            return DocSource(tk);
        }

        public static RuleTableKind tablekind(FileName src)
        {
            return srckind(src) switch
            {
                XedDocKind.EncRuleTable => RuleTableKind.ENC,
                XedDocKind.DecRuleTable => RuleTableKind.DEC,
                _ => 0
            };
        }

        static XedDocKind srckind(FileName src)
        {
            if(src == EncInstDef)
                return XedDocKind.EncInstDef;
            else if(src == DecInstDef)
                return XedDocKind.DecInstDef;
            else if(src == EncRuleTable)
                return XedDocKind.EncRuleTable;
            else if(src == DecRuleTable)
                return XedDocKind.DecRuleTable;
            else if(src == EncDecRuleTable)
                return XedDocKind.EncDecRuleTable;
            else
                return 0;
        }

        public static FilePath DocSource(XedDocKind kind)
            => Sources().Path(kind switch{
                XedDocKind.RuleBlocks => FS.file("xed-dump",FileKind.Txt),
                XedDocKind.EncInstDef => FS.file("all-enc-instructions", FS.Txt),
                XedDocKind.DecInstDef => FS.file("all-dec-instructions", FS.Txt),
                XedDocKind.EncRuleTable => FS.file("all-enc-patterns", FS.Txt),
                XedDocKind.DecRuleTable => FS.file("all-dec-patterns", FS.Txt),
                XedDocKind.EncDecRuleTable => FS.file("all-enc-dec-patterns", FS.Txt),
                XedDocKind.Widths => FS.file("all-widths", FS.Txt),
                XedDocKind.PointerWidths => FS.file("all-pointer-names", FS.Txt),
                XedDocKind.Fields => FS.file("all-fields", FS.Txt),
                XedDocKind.ChipMap => FS.file("cdata", FS.Txt),
                XedDocKind.FormData => FS.file("idata", FS.Txt),
                XedDocKind.CpuId => FS.file("all-cpuid", FileKind.Txt),
                XedDocKind.RuleSeq => FS.file("all-enc-patterns", FS.Txt),
                _ => FileName.Empty
            });

        public XedRules Rules => Xed.Rules;
    }
}