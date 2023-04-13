//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    using static sys;

    class EcmaCmd : WfAppCmd<EcmaCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ApiMd ApiMd => Wf.ApiMd();

        DataAnalyzer Analyzer => Wf.Analyzer();

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("ecma/emit")]
        void EcmaEmit()
            => EcmaEmitter.Emit(ApiAssemblies.Components, EcmaEmissionSettings.Default, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/emit/parts")]
        void EmitPartEcma()
            => EcmaEmitter.EmitCatalogs(ApiAssemblies.Components, AppDb.ApiTargets());

        [CmdOp("ecma/emit/hex")]
        void EmitApiHex()
            => EcmaEmitter.EmitLocatedMetadata(ApiAssemblies.Components, AppDb.ApiTargets("ecma/hex"), 64);

        [CmdOp("ecma/emit/assembly-refs")]
        void EmitAssmeblyRefs(CmdArgs args)
            => EcmaEmitter.EmitAssemblyRefs(ApiAssemblies.Components, AppDb.ApiTargets("ecma"));

        [CmdOp("ecma/emit/method-defs")]
        void EmitMethodDefs(CmdArgs args)
            => EcmaEmitter.EmitMethodDefs(ApiAssemblies.Components, AppDb.ApiTargets("ecma/methods.defs").Delete());

        [CmdOp("ecma/emit/member-refs")]
        void EmitMemberRefs(CmdArgs args)
            => EcmaEmitter.EmitMemberRefs(ApiAssemblies.Components, AppDb.ApiTargets("ecma/members.refs"));

        [CmdOp("ecma/emit/strings")]
        void EmitStrings(CmdArgs args)
            => EcmaEmitter.EmitStrings(ApiAssemblies.Components, AppDb.ApiTargets("ecma/strings"));

        [CmdOp("ecma/emit/blobs")]
        void EmitBlobs(CmdArgs args)
            => EcmaEmitter.EmitBlobs(ApiAssemblies.Components, AppDb.ApiTargets("ecma/blobs"));

        [CmdOp("ecma/emit/msil")]
        void EmitMsil()
        {
            var src = ApiMd.ApiHosts.GroupBy(x => x.Assembly).Map(x => (x.Key,x.Array())).ToDictionary();
            Ecma.EmitMsil(src, AppDb.ApiTargets("ecma/msil"));
        }

        [CmdOp("ecma/emit/msildat")]
        void EmitMsilData()
            => EcmaEmitter.EmitMsilMetadata(ApiAssemblies.Components, AppDb.ApiTargets("ecma/msil.dat"));

        [CmdOp("ecma/emit/literals")]
        void EmitLiterals()
            => ApiMd.Emitter(AppDb.ApiTargets()).EmitLiterals(ApiAssemblies.Components);

        [CmdOp("ecma/emit/headers")]
        void EmitHeaders()
            => EcmaEmitter.EmitSectionHeaders(sys.controller().RuntimeArchive(), Dst);

        [CmdOp("ecma/tables/kinds")]
        void EmitEcmaTables()
        {
            var src = Ecma.TableKinds();
            iter(src, x => {
                Channel.Row(string.Format("{0:x2} {1}", (byte)x.Value, x.Name));
            });
        }
        
        [CmdOp("db/typetables")]
        void TypeTables()
        {
            using var dispenser = Dispense.composite();
            var formatter = CsvTables.formatter<TypeTableRow>();
            var buffer = bag<TypeTableRow>();
            iter(ApiAssemblies.Components, assembly => {
                var tables = MemDb.typetables(assembly, dispenser);
                iter(tables, t => iter(t.Rows, row => buffer.Add(row)));
            },true);

            Channel.TableEmit(buffer.Array().Sort(), EnvDb.Scoped("tables").Table<TypeTableRow>(), TextEncodingKind.Unicode);
        }

        [CmdOp("ecma/streams")]
        void EmitEcmaStreams(CmdArgs args)
        {
            var src = Ecma.index(Channel, FS.dir(args[0]));
            var dst = bag<EcmaStreamHeader>();
            iter(src.Distinct(), a => {
                using var file = EcmaFile.open(a.Path);
                var reader = file.EcmaReader();
                var memory = reader.Memory(reader.AssemblyKey());
                var root = memory.ReadMetadataRoot();
                var tables = EcmaStreams.tables(root);
                var blobs = EcmaStreams.blobs(root);
                var strings = EcmaStreams.strings(root,false);
                var guids = EcmaStreams.guids(root);
                Channel.Row(RP.PageBreak180, FlairKind.StatusData);
                Channel.Row(a.Path);
                Channel.Row($"Strings: {strings.BaseAddress}:{strings.Size}");
                Channel.Row($"Blobs:   {blobs.BaseAddress}:{blobs.Size}");
                Channel.Row($"Guids:   {guids.BaseAddress}:{guids.Size}");

                var counts = tables.RowCounts;
                var b = new bits<ulong>(64, (ulong)tables.Present);
                var j=0;
                for(byte i=0; i<64; i++)
                {
                    if(b[i])
                    {
                        var table = (TableIndex)i;
                        var count = counts[j++];
                        Channel.Row(string.Format("{0,-24} {1}", table, count));
                    }
                }
            });
        }
        
        [CmdOp("ecma/dump")]
        void EmitCliDump(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var index = Ecma.index(Channel,src);
            var dst = EnvDb.Nested("ecma.dumps", src);
            iter(index.Distinct(), entry => {
                if(!entry.Path.Contains("resources.dll"))
                {
                    using var file = Ecma.file(entry.Path);
                    var reader = file.EcmaReader();
                    var name = reader.AssemblyName();
                    var hash = entry.ContentHash;
                    EcmaEmitter.EmitDump(reader.MetadataReader, dst.Path($"{name.SimpleName()}.{name.Version}.{entry.Path.Ext}.{hash}", FileKind.Txt));
                }
            },true);
        }

        [CmdOp("coff/modules")]
        void ExportCoffInfo(CmdArgs args)
        {            
            var src = FS.dir(args[0]);
            var targets = EnvDb;
            var modules = bag<CoffObjectData>();
            var peinfo = cdict<FilePath, PeFileInfo>();
            var coffheaders = cdict<FilePath, CoffHeader>();
            var corheadrs = dict<FilePath, PeCorHeader>();
            var secheaders = dict<FilePath, List<SectionHeaderRow>>();
            var index = FS.index(Archives.modules(src).Members().Select(x => x.Path));
            var emitter = text.emitter();
            iter(index.Distinct(), entry => {
                try
                {
                    using var reader = PeReader.create(entry.Path);
                    var module = reader.ModuleInfo();
                    peinfo.TryAdd(entry.Path, module.PeInfo);
                    coffheaders.TryAdd(entry.Path, module.CoffHeader);
                    if(module.CorHeader != null)
                        corheadrs.TryAdd(entry.Path, module.CorHeader);
                    var secheaerlist = new List<SectionHeaderRow>();
                    secheaders.TryAdd(entry.Path, secheaerlist);
                    iter(module.Sections, sec => secheaerlist.Add(sec));
                

                    emitter.AppendLine(module);
                }
                catch(Exception e)
                {
                    Channel.Warn($"{e.Message}: {entry.Path}");
                }
            });

            iter(peinfo.Keys, path => {


            });

        }

        void MapPeHeaders(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var modules = Archives.modules(src);
            iter(modules.Members(), member => {
                using var map = PeMap.create(member.Path);
                if(PeFiles.test(map.Segment()))
                {
                    var memory = map.PeMemory();
                    var dos = memory.DosHeader;
                    var coff = memory.CoffHeader;
                    Channel.Row(coff);
                }

            });
        }


        [CmdOp("ecma/dump")]
        void EcmaEmitMetaDumps(CmdArgs args)
            => EcmaEmitter.EmitDump(FS.dir(args[0]).DbArchive(), EnvDb);

        [CmdOp("ecma/compile")]
        void Compilations(CmdArgs args)
        {
            var src = Archives.modules(FS.dir(args[0]), false).AssemblyFiles();
            var identifer = "test.a";
            var refs = list<PortableExecutableReference>();
            var dst = CsGen.emitter();
            var namespaces = hashset<string>();
            refs.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
            iter(src, file => {
                refs.Add(MetadataReference.CreateFromFile(file.Path.Format()));
                using var ecma = Ecma.file(file.Path);                
                var reader = ecma.EcmaReader();
                namespaces.AddRange(reader.ReadNamespaceNames().View);
             });

            iter(namespaces, ns => dst.UsingNamespace(0,ns));                                                    

            dst.AppendLine(@"
                class App
                {
                    static void Main(string[] args)
                    {
                        
                    }
                }
            ");

            var code = dst.Emit().Join(Chars.NL);
            Channel.Row(code);
            var syntax = CSharpSyntaxTree.ParseText(code);
            var compOptions = new CSharpCompilationOptions(OutputKind.ConsoleApplication, allowUnsafe:true, metadataImportOptions:MetadataImportOptions.All);                    
            var compilation = CSharpCompilation.Create(identifer, syntaxTrees: new []{syntax}, references: refs, options:compOptions);            
            var output = AppSettings.EnvDb().Scoped("clr").Path(identifer, FileKind.Exe).Delete();
            var emitOptions = new EmitOptions(false, DebugInformationFormat.Embedded, includePrivateMembers:true);
            using var stream = output.Stream();            
            var result = compilation.Emit(stream,options:emitOptions);          
        }

const string SyntaxTest = @"
// The PE signature bytes that follows the DOS stub header.
static const char PEMagic[] = {'P', 'E', '\0', '\0'};

static const char BigObjMagic[] = {
    '\xc7', '\xa1', '\xba', '\xd1', '\xee', '\xba', '\xa9', '\x4b',
    '\xaf', '\x20', '\xfa', '\xf6', '\x6a', '\xa4', '\xdc', '\xb8',
};

static const char ClGlObjMagic[] = {
    '\x38', '\xfe', '\xb3', '\x0c', '\xa5', '\xd9', '\xab', '\x4d',
    '\xac', '\x9b', '\xd6', '\xb6', '\x22', '\x26', '\x53', '\xc2',
};

// The signature bytes that start a .res file.
static const char WinResMagic[] = {
    '\x00', '\x00', '\x00', '\x00', '\x20', '\x00', '\x00', '\x00',
    '\xff', '\xff', '\x00', '\x00', '\xff', '\xff', '\x00', '\x00',
};

// Sizes in bytes of various things in the COFF format.
enum {
  Header16Size = 20,
  Header32Size = 56,
  NameSize = 8,
  Symbol16Size = 18,
  Symbol32Size = 20,
  SectionSize = 40,
  RelocationSize = 10
};

";
        [CmdOp("csharp/parse")]
        void ParseCSharp(CmdArgs args)
        {

            var src = FS.archive(args[0]);         
            var parser = new SyntaxNodeParser(Channel);
            
            parser.ParseNode(CSharpSyntaxTree.ParseText(SyntaxTest).GetRoot());
            // iter(src.Files(FileKind.Cs), path => {
            //     var syntax = CSharpSyntaxTree.ParseText(path.ReadText());
            //     var root = syntax.GetRoot();
            //     iter(root.ChildNodes(), child => parser.ParseNode(child));
                                    
            // });

        }
        static FilePath[] CodeAnalysis
            => FS.path(ExecutingPart.Assembly.Location).FolderPath.DbArchive().Files(FileKind.Dll,true).Where(f => f.FileName.StartsWith("Microsoft.CodeAnalysis")).Array();

        [CmdOp("roslyn/nodes")]
        void RoslnNodes()
        {
            iter(CodeAnalysis, path => {
                using var ecma = Ecma.file(path);
                var data = ecma.ImageData.ToArray();
                
                var reader = ecma.EcmaReader();

                var key = reader.AssemblyKey();
                var counter = 0u;
                var depscount = 0u;
                var types = dict<string,EcmaTypeDef>();
                Channel.Row(key.AssemblyName, FlairKind.StatusData);                
                var deps = Ecma.CalcDependencies(ecma);
                iter(deps.NativeDependencies, d =>  Channel.Row(string.Format("{0:D5} {1} --> {2}", depscount++, d.SourceName, d.TargetName), FlairKind.StatusData));
                iter(deps.ManagedDependencies, d => Channel.Row(string.Format("{0:D5} {1} --> {2}/{3}",depscount++, d.SourceName, d.TargetName,d.TargetVersion), FlairKind.StatusData));
                var typedefs = reader.ReadTypeDefs();
                iter(typedefs, t => {
                    if(!t.Name.Contains("<") && !t.Name.Contains("."))
                    {
                        types[t.FullName] = t;
                    }
                });

                iter(types.Keys, name => {
                    var type = types[name];         
                    var def = text.emitter();      
                    if(type.BaseName.IsNonEmpty)                     
                    {
                        def.Append(string.Format("{0:D5} {1} -> {2}", counter++, type.FullName, type.BaseName));
                    }
                    else
                    {
                        def.Append(string.Format("{0:D5} {1}", counter++, type.FullName));
                    }
                    Channel.Row(def.Emit());
                });
            });
        }

        [CmdOp("files/analyze")]
        void Analyze(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive();
            var dst = FS.dir(args[1]).DbArchive();
            Analyzer.Run(src,dst);            
        }

        [CmdOp("loop/run")]
        void CheckLoops()
        {
            var psi = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true, 
                UseShellExecute = false,
                FileName = "cmd.exe",
            };
            using var process = sys.process(psi);
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += OnOutput;
            process.ErrorDataReceived += OnError;
            process.Exited += OnExit;
            process.Start();

            var writer = process.StandardInput;
            var reader = process.StandardOutput;
            var running = true;

            void OnExit(object sender, EventArgs e)
            {
                Channel.Babble("Received exit event");
                running = false;
            }
            
            void OnOutput(object sender, DataReceivedEventArgs e)
            {

            }

            void OnError(object sender, DataReceivedEventArgs e)
            {

            }

            void Read()
            {
                while(running)   
                {
                    var line = reader.ReadLine();
                    if(line == "stop")
                    {
                        running = false;
                        Channel.Status("Received stop signal", FlairKind.StatusData);
                        writer.WriteLineAsync("exit");
                    }
                    else
                    {
                        Channel.Write(line);
                    }
                }
            }

            void Run()
            {
                var flow = Channel.Running();
                writer.WriteLine("dir");
                writer.WriteLine("c:");
                writer.WriteLine("dir");
                writer.WriteLine("echo stop");
                process.WaitForExit();
                Channel.Ran(flow);
                running = false;
            }
            var reading = sys.start(Read);
            var runner = sys.start(Run);            
            var waiting = Channel.Running($"Waiting for {process.Id} exit");
            runner.Wait();
            Channel.Ran(waiting, $"Process finished");
        }
    }
}