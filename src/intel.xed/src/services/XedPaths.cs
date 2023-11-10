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

    public static FilePath DbTarget(string name, FileKind kind)
        => DbTargets().Root + FS.file(string.Format("xed.db.{0}",name), kind.Ext());

    public static AbsoluteLink MarkdownLink(RuleIdentity sig)
        => Markdown.link(string.Format("{0}::{1}()", sig.TableKind, sig.TableName), RuleTable(sig));

    public static FileUri RuleTable(RuleIdentity sig)
    {
        var dst = RuleTables();
        return dst.Path(FS.file(sig.Format(), FS.Csv));
    }

    public static FileUri CheckedRulePage(RuleIdentity sig)
    {
        var uri = RuleTable(sig);
        return uri.Exists ? uri : FileUri.Empty;
    }

    public static FileUri CheckedTableDef(RuleName rule, bit decfirst, out RuleIdentity sig)
    {
        var dst = FileUri.Empty;
        if(decfirst)
        {
            sig = new RuleIdentity(RuleTableKind.DEC, rule);
            dst = CheckedRulePage(sig);
            if(dst.IsEmpty)
            {
                sig = new RuleIdentity(RuleTableKind.ENC,rule);
                dst = CheckedRulePage(sig);
            }
        }
        else
        {
            sig = new RuleIdentity(RuleTableKind.ENC,rule);
            dst = CheckedRulePage(sig);
            if(dst.IsEmpty)
            {
                sig = new RuleIdentity(RuleTableKind.DEC,rule);
                dst = CheckedRulePage(sig);
            }
        }
        return dst;
    }

    public static IDbArchive DocTargets()
        => Targets().Scoped("docs");

    public static FilePath DocTarget(string name, FileKind kind)
        => DocTargets().Path(FS.file(string.Format("xed.docs.{0}", name), kind.Ext()));
    
    public static FilePath EncInstDef()
        => Sources().Path(FS.file("all-enc-instructions", FS.Txt));

    public static FilePath DecInstDef()
        => Sources().Path(FS.file("all-dec-instructions", FS.Txt));

    public static FilePath InstPatternSource(RuleTableKind kind)
        => kind switch {
            RuleTableKind.DEC => Sources().Path(FS.file("all-dec-patterns", FS.Txt)),
            RuleTableKind.ENC => Sources().Path(FS.file("all-enc-patterns", FS.Txt)),
            _ => throw new Exception($"Unknown: {kind}")
        };

    public static FilePath FieldSource()
        => Sources().Path(FS.file("all-fields", FS.Txt));

    public static FilePath CpuidSource()
        => Sources().Path(FS.file("all-cpuid", FileKind.Txt));

    public static FilePath ChipMapSource()
        => Sources().Path(FS.file("cdata", FS.Txt));

    public static FilePath WidthSource()
        => Sources().Path(FS.file("all-widths", FS.Txt));

    public static FilePath RuleBlockSource()
        => Sources().Path(FS.file("xed-dump", FileKind.Txt));

    public static FilePath InstFormSource()
        => Sources().Path(FS.file("idata", FS.Txt));

    public static FilePath RuleSeqSource()
        => Sources().Path(FS.file("all-enc-patterns", FS.Txt));


    static XedPaths Instance = new();
}
