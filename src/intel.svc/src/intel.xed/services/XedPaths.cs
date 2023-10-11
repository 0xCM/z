//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;
using static Markdown;

public class XedPaths
{
    public static XedPaths Service => Instance;

    public static IDbArchive XedKit()
        => IntelPaths.service().XedKit();

    public static IDbArchive XedDb()
        => IntelPaths.Service.XedDb();

    public static IDbArchive XedBuild()
        => XedKit().Scoped("build");

    public static IDbArchive Sources()
        => XedDb().Scoped("sources");

    public static IDbArchive Targets()
        => XedDb().Targets();

    public static IDbArchive Targets(string scope)
        => Targets().Scoped(scope);

    public static IDbArchive DbTargets()
        => Targets().Targets("db");

    public static IDbArchive Imports()
        => Targets("imports");

    public static IDbArchive RuleTargets()
        => Targets("rules");

    public static IDbArchive InstTargets()
        => Targets("instructions");

    public static IDbArchive InstPages()
        => InstTargets().Targets("pages");

    public static IDbArchive RuleTables()
        => Imports().Targets("rules.tables");

    public static FilePath ImportTable<T>()
        => Imports().Table<T>();

    public static FilePath ImportTable<T>(string suffix)
        where T : struct
            => Imports().Path(Suffixed<T>(suffix));

    public static FilePath FormCatalogPath()
        => Imports().Path(FS.file(Tables.identify<FormImport>().Format(), FS.Csv));

    static FileName Suffixed<T>(string suffix)
        where T : struct
            => CsvTables.filename<T>().ChangeExtension(FS.ext(string.Format("{0}.{1}", suffix, FS.Csv)));

    public static FilePath DbTable<T>()
        where T : struct
                => DbTargets().Root + CsvTables.filename<T>("xed.db");

    public static FilePath DbTarget(string name, FileKind kind)
        => DbTargets().Root + FS.file(string.Format("xed.db.{0}",name), kind.Ext());

    public static AbsoluteLink MarkdownLink(RuleSig sig)
        => Markdown.link(string.Format("{0}::{1}()", sig.TableKind, sig.TableName), RuleTable(sig));

    public static RuleTableKind tablekind(FileName src)
    {
        return srckind(src) switch
        {
            XedDocKind.EncRuleTable => RuleTableKind.ENC,
            XedDocKind.DecRuleTable => RuleTableKind.DEC,
            _ => 0
        };
    }

    public static IDbArchive DisasmTargets(IDbArchive root)
        => root.Targets("xed.disasm");

    public static FilePath DisasmSummaryPath(FilePath src)
        => src.FolderPath + FS.file(string.Format("{0}.summary", src.FileName.WithoutExtension), FS.Csv);

    public static FilePath DisasmDetailPath(FilePath src)
        => src.FolderPath +  FS.file(string.Format("{0}.details", src.FileName.WithoutExtension), FS.Csv);

    public static FilePath DisasmFieldsPath(FilePath src)
        => src.FolderPath +  FS.file(string.Format("{0}.fields", src.FileName.WithoutExtension), FS.Txt);

    public static FilePath DisasmChecksPath(FilePath src)
        => src.FolderPath + FS.file(string.Format("{0}.checks", src.FileName.WithoutExtension), FS.Txt);

    public static FilePath DisasmOpsPath(FilePath src)
        => src.FolderPath + FS.file(string.Format("{0}.ops", src.FileName.WithoutExtension.Format()), FS.Txt);

    public static FileUri RuleTable(RuleSig sig)
        => RuleTables().Path(FS.file(sig.Format(), FS.Csv));

    public static FileUri CheckedRulePage(RuleSig sig)
    {
        var uri = RuleTable(sig);
        return uri.Exists ? uri : FileUri.Empty;
    }

    public static FileUri CheckedTableDef(RuleName rule, bit decfirst, out RuleSig sig)
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

    public static FilePath RuleSpecs()
        => RuleTargets().Path(FS.file("xed.rules.specs", FS.Csv));

    public static FilePath InstTarget(string name, FileKind kind)
        => InstTargets().Path(FS.file(string.Format("xed.inst.{0}", name), kind.Ext()));

    public static FilePath InstPagePath(InstIsa src)
        => InstPages().Path(FS.file(text.ifempty(src.Format(), "UNKNOWN"), FS.Txt));

    public static FilePath RuleTarget(string name, FileExt ext)
        => RuleTargets().Path(FS.file("xed.rules." + name, ext));

    public static FilePath Target(string name, FileExt ext)
        => Targets().Path(FS.file(name, ext));

    public static IDbArchive DocTargets()
        => Targets().Scoped("docs");

    public static FilePath DocTarget(string name, FileKind kind)
        => DocTargets().Path(FS.file(string.Format("xed.docs.{0}", name), kind.Ext()));
    
    public static FilePath InstDefSource(RuleTableKind kind)
        => kind switch {
            RuleTableKind.DEC => Sources().Path(FS.file("all-dec-instructions", FS.Txt)),
            RuleTableKind.ENC => Sources().Path(FS.file("all-enc-instructions", FS.Txt)),
            _ => FilePath.Empty
        };

    public static FilePath InstPatternSource(RuleTableKind kind)
        => kind switch {
            RuleTableKind.DEC => Sources().Path(FS.file("all-dec-patterns", FS.Txt)),
            RuleTableKind.ENC => Sources().Path(FS.file("all-enc-patterns", FS.Txt)),
            _ => Sources().Path(FS.file("all-enc-dec-patterns", FS.Txt)),
        };

    public static FilePath FieldSource()
        => Sources().Path(FS.file("all-fields", FS.Txt));

    public static FilePath DocSource(XedDocKind kind)
        => Sources().Path(kind switch{
            XedDocKind.RuleBlocks => FS.file("xed-dump", FileKind.Txt),
            XedDocKind.EncInstDef => FS.file("all-enc-instructions", FS.Txt),
            XedDocKind.DecInstDef => FS.file("all-dec-instructions", FS.Txt),
            XedDocKind.EncRuleTable => FS.file("all-enc-patterns", FS.Txt),
            XedDocKind.DecRuleTable => FS.file("all-dec-patterns", FS.Txt),
            //XedDocKind.EncDecRuleTable => FS.file("all-enc-dec-patterns", FS.Txt),
            XedDocKind.Widths => FS.file("all-widths", FS.Txt),
            XedDocKind.PointerWidths => FS.file("all-pointer-names", FS.Txt),
            XedDocKind.Fields => FS.file("all-fields", FS.Txt),
            XedDocKind.ChipMap => FS.file("cdata", FS.Txt),
            XedDocKind.FormData => FS.file("idata", FS.Txt),
            XedDocKind.CpuId => FS.file("all-cpuid", FileKind.Txt),
            XedDocKind.RuleSeq => FS.file("all-enc-patterns", FS.Txt),
            _ => FileName.Empty
        });


    static FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

    static FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

    static FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

    static FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

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
        // else if(src == EncDecRuleTable)
        //     return XedDocKind.EncDecRuleTable;
        else
            return 0;
    }


    static XedPaths Instance = new();
}
