//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static Markdown;

    public class XedPaths
    {
        public static XedPaths Service => Instance;

        static AppDb AppDb => AppDb.Service;

        public readonly struct SvcState
        {
            public readonly FolderPath XedSources;

            public readonly FolderPath XedTargets;

            public SvcState(FolderPath src, FolderPath dst)
            {
                XedSources = src;
                XedTargets = dst;
            }
        }

        readonly SvcState State;

        public FolderPath Sources()
            => State.XedSources;

        public FolderPath Output()
            => State.XedTargets;

        public IDbTargets Targets()
            => new DbTargets(State.XedTargets);

        public IDbTargets Targets(string scope)
            => new DbTargets(State.XedTargets, scope);

        public IDbTargets DbTargets()
            => Targets().Targets("db");

        public IDbTargets Imports()
            => Targets("imports");

        public IDbTargets RuleTargets()
            => Targets("rules");

        public IDbTargets Refs()
            => Targets("refs");

        public IDbTargets InstTargets()
            => Targets("instructions");

        public IDbTargets InstPages()
            => InstTargets().Targets("pages");

        public IDbTargets RulePages()
            => RuleTargets().Targets("pages");

        public FilePath Table<T>()
            where T : struct
                => Targets().Table<T>();

        public FilePath Table<T>(string suffix)
            where T : struct
                => Targets().Path(Suffixed<T>(suffix));

        public FilePath RuleTable<T>()
            where T : struct
                => RuleTargets().Table<T>();

        public FilePath FormCatalogPath()
            => Imports().Path(FS.file(Tables.identify<FormImport>().Format(), FS.Csv));

        static FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

        static FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

        static FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

        static FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

        static FileName EncDecRuleTable = FS.file("all-enc-dec-patterns", FS.Txt);

        static FileName Suffixed<T>(string suffix)
            where T : struct
                => Tables.filename<T>().ChangeExtension(FS.ext(string.Format("{0}.{1}", suffix, FS.Csv)));

        public FilePath DbTable<T>()
            where T : struct
                 => DbTargets().Root + Tables.filename<T>("xed.db");

        public FilePath DbTarget(string name, FileKind kind)
            => DbTargets().Root + FS.file(string.Format("xed.db.{0}",name), kind.Ext());

        public AbsoluteLink MarkdownLink(RuleSig sig)
            => Markdown.link(string.Format("{0}::{1}()", sig.TableKind, sig.TableName), RulePage(sig));

        public static RuleTableKind tablekind(FileName src)
        {
            return srckind(src) switch
            {
                XedDocKind.EncRuleTable => RuleTableKind.ENC,
                XedDocKind.DecRuleTable => RuleTableKind.DEC,
                _ => 0
            };
        }

        public IDbTargets DisasmTargets(ProjectId project)
            => AppDb.EtlTargets(project).Targets("xed.disasm");

        public FilePath DisasmDetailPath(ProjectId project, in FileRef src)
            => DisasmTargets(project).Path(FS.file(string.Format("{0}.details", src.Path.FileName.WithoutExtension), FS.Csv));

        public FilePath DisasmFieldsPath(ProjectId project, in FileRef src)
            => DisasmTargets(project).Path(FS.file(string.Format("{0}.fields", src.Path.FileName.WithoutExtension), FS.Txt));

        public FilePath DisasmChecksPath(ProjectId project, in FileRef src)
            => DisasmTargets(project).Path(FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt));

        public FilePath DisasmOpsPath(ProjectId project, in FileRef src)
            => DisasmTargets(project).Path(FS.file(string.Format("{0}.ops", src.Path.FileName.WithoutExtension.Format()), FS.Txt));

        public FileUri RulePage(RuleSig sig)
            => RulePages().Path(FS.file(sig.Format(), FS.Csv));

        public FileUri CheckedRulePage(RuleSig sig)
        {
            var uri = RulePage(sig);
            return uri.Path.Exists ? uri : FileUri.Empty;
        }

        public FileUri CheckedTableDef(RuleName rule, bit decfirst, out RuleSig sig)
        {
            var dst = FileUri.Empty;
            if(decfirst)
            {
                sig = new RuleSig(RuleTableKind.DEC, rule);
                dst = CheckedRulePage(sig);
                if(dst.IsEmpty)
                {
                    sig = new RuleSig(RuleTableKind.ENC,rule);
                    dst = CheckedRulePage(sig);
                }
            }
            else
            {
                sig = new RuleSig(RuleTableKind.ENC,rule);
                dst = CheckedRulePage(sig);
                if(dst.IsEmpty)
                {
                    sig = new RuleSig(RuleTableKind.DEC,rule);
                    dst = CheckedRulePage(sig);
                }
            }
            return dst;
        }

        public FilePath RuleSpecs()
            => RuleTargets().Path(FS.file("xed.rules.specs", FS.Csv));

        public FilePath InstTable<T>()
            where T : struct
                => InstTargets().Path(Tables.filename<T>());

        public FilePath InstTable<T>(string suffix)
            where T : struct
                => InstTargets().Path(Suffixed<T>(suffix));

        public FilePath InstTarget(string name, FileKind kind)
            => InstTargets().Path(FS.file(string.Format("xed.inst.{0}", name), kind.Ext()));

        public FilePath InstPagePath(InstIsa src)
            => InstPages().Path(FS.file(text.ifempty(src.Format(), "UNKNOWN"), FS.Txt));

        public FilePath RuleSource(RuleTableKind kind)
        {
            var name = kind switch
            {
                RuleTableKind.ENC => EncRuleTable,
                RuleTableKind.DEC => DecRuleTable,
                _ => FileName.Empty
            };

            return Sources() + name;
        }

        public FilePath RuleTarget(string name, FileExt ext)
            => RuleTargets().Path(FS.file("xed.rules." + name, ext));

        public FilePath Target(string name, FileExt ext)
            => Output() + FS.file(name, ext);

        public FolderPath DocTargets()
            => Output() + FS.folder("docs");

        public FilePath DocTarget(string name, FileKind kind)
            => DocTargets() + FS.file(string.Format("xed.docs.{0}", name), kind.Ext());

        public static XedDocKind srckind(FileName src)
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

        public FilePath SourcePath(string name, FileKind kind)
            => Sources() + FS.file(name,kind.Ext());

        public FilePath CpuIdSource()
            => SourcePath("all-cpuid", FileKind.Txt);

        public FilePath ChipMapSource()
            => SourcePath("xed-cdata", FileKind.Txt);

        public FilePath DocSource(XedDocKind kind)
            => Sources() + (kind switch{
                XedDocKind.EncInstDef => EncInstDef,
                XedDocKind.DecInstDef => DecInstDef,
                XedDocKind.EncRuleTable => EncRuleTable,
                XedDocKind.DecRuleTable => DecRuleTable,
                XedDocKind.EncDecRuleTable => EncDecRuleTable,
                XedDocKind.Widths => FS.file("all-widths", FS.Txt),
                XedDocKind.PointerWidths => FS.file("all-pointer-names", FS.Txt),
                XedDocKind.Fields => FS.file("all-fields", FS.Txt),
                XedDocKind.FormData => FS.file("xed-idata", FS.Txt),
                XedDocKind.ChipData => FS.file("xed-cdata", FS.Txt),
                XedDocKind.RuleSeq => FS.file("all-enc-patterns", FS.Txt),
                _ => FileName.Empty
            });


        XedPaths()
        {
            State = new (AppDb.DbIn("intel/xed.primary").Root, AppDb.DbOut("xed").Root);
        }

        static XedPaths Instance = new();
    }
}