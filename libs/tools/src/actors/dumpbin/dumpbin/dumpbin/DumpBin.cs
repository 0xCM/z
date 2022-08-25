//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static DumpBinScripts;

    [ApiHost]
    public partial class DumpBin : ToolService<DumpBin>
    {
        const string dumpbin = "dumpbin";

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

        public CmdScript Script<T>(string name, CmdName cmd, ReadOnlySeq<T> src, IDbTargets output)
            where T : IFileModule
        {
            var emitter = text.emitter();
            foreach(var module in src)
                emitter.AppendLine(Expr(cmd, module.Location, output).Format());
            return CmdScripts.create(name, emitter.Emit());
        }

        public CmdScriptExpr Expr(CmdName name, FS.FilePath src, IDbTargets dst)
        {
            var subdir = dst.Root + FS.folder(src.FileName.WithoutExtension.Name);
            subdir.Create();
            var output = subdir + src.FileName.ChangeExtension(outkind(name));
            var source = src.Format(PS);
            var target = output.Format(PS);
            var pattern = ScriptTemplate.Empty;
            switch(name)
            {
                case CmdName.EmitAsm:
                    pattern = CmdScripts.template("dumpbin.disasm", string.Format("dumpbin /DISASM:{2} /OUT:{1} {0}", source, target, "NOBYTES"));
                    break;
                case CmdName.EmitRawData:
                    pattern = CmdScripts.template("dumpbin.rawdata", string.Format("dumpbin /RAWDATA:1,32 /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitHeaders:
                    pattern = CmdScripts.template("dumpbin.headers", string.Format("dumpbin /HEADERS /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitRelocations:
                    pattern = CmdScripts.template("dumpbin.relocations", string.Format("dumpbin /RELOCATIONS /OUT:{1} {0}", src.Format(PS), output.Format(PS)));
                    break;
                case CmdName.EmitExports:
                    pattern = CmdScripts.template("dumpbin.exports", string.Format("dumpbin /EXPORTS /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitLoadConfig:
                    pattern = CmdScripts.template("dumpbin.loadconfig", string.Format("dumpbin /LOADCONFIG /OUT:{1} {0}", src.Format(PS), output.Format(PS)));
                    break;
            }
            return CmdScripts.expr(pattern);
        }

        public static FS.FileName scriptfile(FileKind kind)
            => kind switch {
                    FileKind.Obj => FS.file("dump-obj", FileKind.Cmd),
                    FileKind.Exe => FS.file("dump-exe", FileKind.Cmd),
                    FileKind.Lib => FS.file("dump-lib", FileKind.Cmd),
                    FileKind.Dll => FS.file("dump-dll", FileKind.Cmd),
                    _ => FS.FileName.Empty
            };

        public static FS.FileName scriptfile(FileModuleKind kind)
            => kind switch {
                    FileModuleKind.Obj => FS.file("dump-obj", FileKind.Cmd),
                    FileModuleKind.Exe => FS.file("dump-exe", FileKind.Cmd),
                    FileModuleKind.Lib => FS.file("dump-lib", FileKind.Cmd),
                    FileModuleKind.Dll => FS.file("dump-dll", FileKind.Cmd),
                    _ => FS.FileName.Empty
            };

        public void DumpModules(IDbSources src, string tag, FileKind kind)
        {
            var script = scriptfile(kind);

            var fk = kind switch{
                FileKind.Obj => FileKind.Obj,
                FileKind.Exe => FileKind.Exe,
                FileKind.Lib => FileKind.Lib,
                FileKind.Dll => FileKind.Dll,
                _ => FileKind.None
            };

            var dst = AppDb.DbOut().Targets(tag);
            var ws = Tooling.Home(dumpbin);
            var cmd = new CmdLine(ws.Script(script).Format(PathSeparator.BS));
            var files = src.Sources().Files(fk);

            for(var i=0; i<files.Count; i++)
            {
                ref readonly var path = ref files[i];
                var vars = WsCmdVars.create();
                vars.DstDir = dst.Root;
                vars.SrcDir = path.FolderPath;
                vars.SrcFile = path.FileName;
                CmdScripts.start(cmd, vars.ToCmdVars(), response => {});
            }
        }

        public ReadOnlySeq<FS.FilePath> GenScripts(IModuleArchive src, IDbTargets dst)
        {
            var paths = list<FS.FilePath>();
            var exe = src.NativeExe();
            var lib = src.Lib();
            var dll = src.NativeDll();
            var obj = src.Obj();
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

        FS.FilePath GenScript<T>(CmdName cmd, ReadOnlySeq<T> src, FileKind kind, IDbTargets dst)
            where T : IFileModule
        {
            var script = Script(ScriptId(cmd, kind), cmd, src, dst);
            var path = dst.Path(FS.file(script.Name.Format(), FS.Cmd));
            FileEmit(script.Format(), path);
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