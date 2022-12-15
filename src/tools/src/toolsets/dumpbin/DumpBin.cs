//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static DumpBin.Scripts;
    using static Pow2x32;

    [ApiHost]
    public partial class DumpBin : ToolService<DumpBin>
    {
        const string dumpbin = "dumpbin";

        public enum CmdName : byte
        {
            None = 0,

            [Symbol("rawdata")]
            EmitRawData,

            [Symbol("loadconfig")]
            EmitLoadConfig,

            [Symbol("relocations")]
            EmitRelocations,

            [Symbol("exports")]
            EmitExports,

            [Symbol("disasm")]
            EmitAsm,

            [Symbol("headers")]
            EmitHeaders,
        }

        [Flags]
        public enum Flag : ulong
        {
            ARCHIVEMEMBERS = P2ᐞ00,

            CLRHEADER = P2ᐞ01,

            DEPENDENTS = P2ᐞ02,

            DIRECTIVES = P2ᐞ03,

            DISASM = P2ᐞ04,

            EXPORTS = P2ᐞ05,

            FPO = P2ᐞ06,

            HEADERS = P2ᐞ07,

            IMPORTS = P2ᐞ08,

            LINENUMBERS = P2ᐞ09,

            LINKERMEMBER = P2ᐞ10,

            LOADCONFIG = P2ᐞ11,

            RAWDATA = P2ᐞ12,

            RELOCATIONS = P2ᐞ13,

            SUMMARY = P2ᐞ14,

            SYMBOLS = P2ᐞ15,

            TLS = P2ᐞ16,

            OUT = P2ᐞ17,

            NOBYTES = P2ᐞ18,
        }
        internal class Scripts
        {
            public static ToolScript DumpObj(FilePath input, IDbTargets dst)
                => Cmd.script(dst.Path("dump-obj",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

            public static ToolScript DumpDll(FilePath input, IDbTargets dst)
                => Cmd.script(dst.Path("dump-dll",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

            public static ToolScript DumpExe(FilePath input, IDbTargets dst)
                => Cmd.script(dst.Path("dump-exe",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

            public static ToolScript DumpLib(FilePath input, IDbTargets dst)
                => Cmd.script(dst.Path("dump-lib",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

            static CmdVars vars(FolderPath SrcDir, FileName SrcFile, FolderPath DstDir)
                => CmdVars.load(
                    ("SrcDir", SrcDir.Format(PathSeparator.BS)),
                    ("SrcFile", SrcFile.Format()),
                    ("DstDir", DstDir.Format(PathSeparator.BS))
                    );
        }

        public static FileKind outkind(CmdName name)
        {
            var dst = FileKind.None;
            switch(name)
            {
                case CmdName.EmitAsm:
                    dst = FileKind.DisAsm;
                    break;
                case CmdName.EmitRawData:
                    dst = FileKind.HexDat;
                    break;
                case CmdName.EmitHeaders:
                    dst = FileKind.CoffHeader;
                    break;
                case CmdName.EmitRelocations:
                    dst = FileKind.CoffReloc;
                    break;
                case CmdName.EmitExports:
                    dst = FileKind.CoffExports;
                    break;
                case CmdName.EmitLoadConfig:
                    dst = FileKind.LoadConfig;
                    break;
            }

            return dst;
        }

        public static ReadOnlySeq<ToolScript> scripts(IDbSources src, FileKind kind, IDbTargets dst)
        {
            var files = src.Files(kind);
            var count = files.Count;
            var scripts = sys.alloc<ToolScript>(count);
            for(var i=0; i<count; i++)
            {
                switch(kind)
                {
                    case FileKind.Dll:
                        seek(scripts,i) = DumpDll(files[i], dst);
                    break;
                    case FileKind.Exe:
                        seek(scripts,i) = DumpExe(files[i], dst);
                    break;
                    case FileKind.Obj:
                        seek(scripts,i) = DumpObj(files[i], dst);
                    break;
                    case FileKind.Lib:
                        seek(scripts,i) = DumpLib(files[i], dst);
                    break;
                }
            }
            return scripts;
        }

        Tooling Tooling => Wf.Tooling();

        public Identifier ScriptId(CmdName cmd, FileKind kind)
            => string.Format("{0}.{1}.{2}", Id, kind.Format(), CmdSymbols[cmd].Expr);

        public CmdScript Script<T>(string name, CmdName cmd, IEnumerable<T> src, IDbTargets output)
            where T : IBinaryModule
        {
            var emitter = text.emitter();
            foreach(var module in src)
                emitter.AppendLine(Expr(cmd, module.Location, output).Format());
            return ProcessControl.script(name, emitter.Emit());
        }

        public CmdScriptExpr Expr(CmdName name, FilePath src, IDbTargets dst)
        {
            var subdir = dst.Root + FS.folder(src.FileName.WithoutExtension.Name);
            subdir.Create();
            var output = subdir + src.FileName.ChangeExtension(outkind(name));
            var source = src.Format(PS);
            var target = output.Format(PS);
            var pattern = PScript.Empty;
            switch(name)
            {
                case CmdName.EmitAsm:
                    pattern = PScript.create("dumpbin.disasm", string.Format("dumpbin /DISASM:{2} /OUT:{1} {0}", source, target, "NOBYTES"));
                    break;
                case CmdName.EmitRawData:
                    pattern = PScript.create("dumpbin.rawdata", string.Format("dumpbin /RAWDATA:1,32 /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitHeaders:
                    pattern = PScript.create("dumpbin.headers", string.Format("dumpbin /HEADERS /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitRelocations:
                    pattern = PScript.create("dumpbin.relocations", string.Format("dumpbin /RELOCATIONS /OUT:{1} {0}", src.Format(PS), output.Format(PS)));
                    break;
                case CmdName.EmitExports:
                    pattern = PScript.create("dumpbin.exports", string.Format("dumpbin /EXPORTS /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitLoadConfig:
                    pattern = PScript.create("dumpbin.loadconfig", string.Format("dumpbin /LOADCONFIG /OUT:{1} {0}", src.Format(PS), output.Format(PS)));
                    break;
            }
            return PScript.expr(pattern);
        }

        public static FileName scriptfile(FileKind kind)
            => kind switch {
                    FileKind.Obj => FS.file("dump-obj", FileKind.Cmd),
                    FileKind.Exe => FS.file("dump-exe", FileKind.Cmd),
                    FileKind.Lib => FS.file("dump-lib", FileKind.Cmd),
                    FileKind.Dll => FS.file("dump-dll", FileKind.Cmd),
                    _ => FileName.Empty
            };

        public static FileName scriptfile(FileModuleKind kind)
            => kind switch {
                    FileModuleKind.Obj => FS.file("dump-obj", FileKind.Cmd),
                    FileModuleKind.Exe => FS.file("dump-exe", FileKind.Cmd),
                    FileModuleKind.Lib => FS.file("dump-lib", FileKind.Cmd),
                    FileModuleKind.Dll => FS.file("dump-dll", FileKind.Cmd),
                    _ => FileName.Empty
            };

        public ReadOnlySeq<FilePath> GenScripts(IModuleArchive src, IDbTargets dst)
        {
            var paths = list<FilePath>();
            var dll = src.NativeDll();
            var sid = Identifier.Empty;
            var cmd = DumpBin.CmdName.None;
            var ext = FileExt.Empty;

            cmd = DumpBin.CmdName.EmitHeaders;
            paths.Add(GenScript(cmd, dll, FileKind.Dll, dst));

            cmd = DumpBin.CmdName.EmitAsm;
            paths.Add(GenScript(cmd, dll, FileKind.Dll, dst));

            cmd = DumpBin.CmdName.EmitRawData;
            paths.Add(GenScript(cmd, dll, FileKind.Dll, dst));

            cmd = DumpBin.CmdName.EmitRelocations;
            paths.Add(GenScript(cmd, dll, FileKind.Dll, dst));

            cmd = DumpBin.CmdName.EmitLoadConfig;
            paths.Add(GenScript(cmd, dll, FileKind.Dll, dst));

            cmd = DumpBin.CmdName.EmitExports;
            paths.Add(GenScript(cmd, dll, FileKind.Dll, dst));

            return paths.ToArray();
        }

        FilePath GenScript<T>(CmdName cmd, IEnumerable<T> src, FileKind kind, IDbTargets dst)
            where T : IBinaryModule
        {
            var script = Script(ScriptId(cmd, kind), cmd, src, dst);
            var path = dst.Path(FS.file(script.Name.Format(), FS.Cmd));
            Channel.FileEmit(script.Format(), path);
            return path;
        }

        uint ArgIndex;

        const PathSeparator PS = PathSeparator.BS;

        Symbols<CmdName> CmdSymbols {get;}

        [MethodImpl(Inline)]
        public DumpBin()
            :base(dumpbin)
        {
            ArgIndex = 0;
            CmdSymbols = Symbols.index<CmdName>();
        }
    }
}