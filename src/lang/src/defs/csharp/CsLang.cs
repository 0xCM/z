//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class CsLang : Channeled<CsLang>
    {

        public StringLitEmitter StringLits()
            => Channel.Channeled<StringLitEmitter>();
        

        string TargetExpr(CgTarget target)
            => TargetExpressions[target];


        public FolderPath ProjectRoot(CgTarget target)
            => CgRoot + FS.folder(TargetExpr(target));

        public FolderPath SourceRoot(CgTarget target)
            => ProjectRoot(target) + FS.folder("src");

        public FilePath SourceFile(string name, IDbArchive dst)
            => dst.Path(FS.file(name, FS.Cs));

        public FilePath SourceFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Cs);

        public static FilePath SourceFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Cs));

        public static FilePath DataFile(FolderPath dst, string name)
            => dst + FS.file(name, FS.Csv);

        public static FilePath SourceFile(FolderPath dst ,string name)
            => dst + FS.file(name, FS.Cs);

        public FilePath DataFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Csv);

        public static FilePath DataFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Csv));

        public void EmitFile(string src, string name, IDbArchive dst)
            => Channel.FileEmit(src, SourceFile(name, dst));

        public void RenderHeader(Timestamp ts, ITextEmitter dst)
            => dst.AppendLineFormat(HeaderFormat, ts);

        static Index<string> HeaderCells = new string[]{
            "//-----------------------------------------------------------------------------",
            "// Copyright   :  (c) Chris Moore, 2023",
            "// License     :  MIT",
            "// Generated   : {0}",
            "//-----------------------------------------------------------------------------",
            };


        static FilePath ReplicantCodePath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Cs);

        static FilePath ReplicantDataPath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Csv);

       static string HeaderFormat = HeaderCells.Join(Chars.Eol);            
 
        ConstLookup<CgTarget,string> TargetExpressions;

        public FolderPath CgRoot => FolderPath.Empty;

        public CsLang()
        {
            var symbols = Symbols.index<CgTarget>();
            var count = symbols.Count;
            var targets = dict<CgTarget,string>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref symbols[i];
                targets[sym.Kind] = sym.Expr.Format();
            }
            TargetExpressions = targets;
        }

    }


}