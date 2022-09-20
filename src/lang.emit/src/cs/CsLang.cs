//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static sys;

    using static MsBuild;

    public partial class CsLang : WfSvc<CsLang>
    {
        public static CsEmitter emitter()
            => new();

        ConstLookup<CgTarget,string> TargetExpressions;

        const string ArrayPackLine = "x{0:x}[{1:D5}:{2:D5}]={3}";

        public ShellGen Shells()
            => Service(() => ShellGen.create(Wf));

        [Op]
        public static string hexarray(in MemorySeg src, uint index, Span<char> dst)
        {
            var memory = src.ToSpan();
            var count = Hex.convert(memory.View, dst);
            return string.Format(ArrayPackLine, memory.BaseAddress, index, (uint)memory.Size, text.format(slice(dst, 0, count)));
        }

        [MethodImpl(Inline)]
        public static uint hexarray(W8 w, in MemoryBlock src, Span<char> dst)
            => Hex.convert(src.View, dst);

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

        public void EmitSymSpan<E>(FilePath dst)
            where E : unmanaged, Enum
        {
            var result = Outcome.Success;
            var emitting = EmittingFile(dst);
            var container = string.Format("{0}Data", typeof(E).Name);
            using var writer = dst.AsciWriter();
            EmitSymSpan<E>(container, writer);
        }

        void EmitSymSpan<E>(Identifier container, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var buffer = text.buffer();
            GSpanRes.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
        }

        public StringLitEmitter StringLits()
            => Wf.GenLiterals();

        public GAsciLookup AsciLookups()
            => Service(Wf.GenAsciLookups);

        public InterfaceEmitter Interfaces()
            => Service(() => InterfaceEmitter.create(Wf));

        public GBinaryKind BinaryKinds(uint max = 0xFF)
            => new GBinaryKind(max);

        public GLiteralProvider LiteralProviders()
            => Wf.GenLitProviders();

        public GHexStrings HexStrings()
            => Service(() => GHexStrings.create(Wf));

        public SwitchMapEmitter SwitchMap()
            => Service(()=> SwitchMapEmitter.create(Wf));

        public GSpanRes SpanRes()
            => Service(() => GSpanRes.create(Wf));

        public void EmitArrayInitializer<T>(ItemList<Constant<T>> src, ITextBuffer dst)
        {
            var count = src.Count;
            var keyword = CsData.keyword(typeof(T));
            dst.AppendFormat("{0} = new {1}[{2}]{{", src.Name, keyword, count);
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref src[i];
                dst.AppendFormat("{0},", item.Value.Format());
            }
            dst.Append("};");
        }

        public Index<Type> LoadTypes(FilePath src)
        {
            var running = Running(string.Format("Loading enum types from {0}", src.ToUri()));
            var buffer = list<Type>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var name = line.Content.Trim();
                var type = Type.GetType(name);
                if(type != null)
                    buffer.Add(type);
                else
                    Warn(string.Format("Unable to load {0}", name));
            }

            var dst = buffer.ToArray();
            Ran(running, string.Format("Loaded {0} enum types from {1}", dst.Length, src.ToUri()));
            return dst;
        }

        string TargetExpr(CgTarget target)
            => TargetExpressions[target];

        public FolderPath CgRoot
            => AppDb.CgRoot().Root;

        public FolderPath ProjectRoot(CgTarget target)
            => CgRoot + FS.folder(TargetExpr(target));

        public FolderPath SourceRoot(CgTarget target)
            => ProjectRoot(target) + FS.folder("src");

        public FilePath SourceFile(string name, IDbArchive dst)
            => dst.Path(FS.file(name, FS.Cs));

        public FilePath SourceFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Cs);

        public FilePath SourceFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Cs));

        public FilePath DataFile(FolderPath dst, string name)
            => dst + FS.file(name, FS.Csv);

        public FilePath SourceFile(FolderPath dst ,string name)
            => dst + FS.file(name, FS.Cs);

        public FilePath DataFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Csv);

        public FilePath DataFile(string name, string scope, IDbArchive dst)
            => dst.Targets(scope).Path(FS.file(name, FS.Csv));

        public void EmitFile(string src, string name, IDbArchive dst)
            => FileEmit(src, SourceFile(name, dst));

        public void RenderHeader(Timestamp ts, ITextEmitter dst)
            => dst.AppendLineFormat(HeaderFormat, ts);

        static Index<string> HeaderCells = new string[]{
            "//-----------------------------------------------------------------------------",
            "// Copyright   :  (c) Chris Moore, 2022",
            "// License     :  MIT",
            "// Generated   : {0}",
            "//-----------------------------------------------------------------------------",
            };


        static string HeaderFormat = HeaderCells.Join(Chars.Eol);
    }
}