//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class ProjectsCmd : WfAppCmd<ProjectsCmd>
    {
        Ecma Ecma => Wf.Ecma();

        EcmaEmitter EcmaEmitter => Wf.EcmaEmitter();

        ProjectModels Models => Channel.Channeled<ProjectModels>();

        ApiMd ApiMd => Wf.ApiMd();

        [CmdOp("projects/modules")]
        void EcmaMeta(CmdArgs args)
        {
            var svc = Channel.Channeled<ModuleArchives>();
            var sources = FS.dir(args[0]).DbArchive();
            using var map = svc.Map(sources,true);
        }

        [CmdOp("projects/assemblies")]
        void IndexAssemblies(CmdArgs args)
        {
            const string RenderPattern ="{0,-64} | {1,-16} | {2,-16} | {3}";
            var locations = list<string>();
            var index = Ecma.index(FS.dir(args[0]));
            iter(index.Entries(), entry => {
                locations.Add(entry.Path.Format(PathSeparator.FS));
            });
            iter(index.Distinct(), entry => {
                Channel.Row(string.Format(RenderPattern, entry.Key.Name, entry.FileSize, entry.Key.Version, entry.Key.Mvid));
            });

            iter(index.Duplicates(), entry => {
                Channel.Row(string.Format(RenderPattern, entry.Key.Name, entry.FileSize, entry.Key.Version, entry.Key.Mvid), FlairKind.StatusData);
            });

            var buffer = sys.span<byte>(2024);
            foreach(var input in locations)
            {
                try
                {
                    buffer.Clear();
                    BinaryFormatters.verify(input,buffer);
                    Channel.Status($"Verified {input}");
                }
                catch(Exception e)
                {
                    Channel.Error(e.Message);
                }
            }
        }


        [CmdOp("projects/pe")]
        void PeFiles(CmdArgs args)
        {
            var src = FS.dir(args[0]).DbArchive().Enumerate(true, FileKind.Dll, FileKind.Exe, FileKind.Obj, FileKind.Sys);
            var dst = bag<PeSectionHeader>();
            iter(src, path => {
                try
                {
                    var flow = Channel.Running($"Reading section headers from {path}");
                    using var reader = PeReader.create(path);
                    var tables = reader.Tables;
                    iter(tables.SectionHeaders, sh => dst.Add(sh));
                    Channel.Ran(flow,$"Read {tables.SectionHeaders.Count} section headers from ${path}");
                                        
                }
                catch(Exception e)
                {
                    Channel.Error(e);
                }
            });
            
            var path = EnvDb.Scoped("flows/import").Table<PeSectionHeader>();
            Channel.TableEmit(dst.Array(),path);
        }

        void ExtractEnums(Assembly src)
        {
            var symbols = map(src.Enums().NonGeneric(), e => Symbols.set(e));
            var dst = CsGen.emitter();
            var margin = 0u;
            var identifier = src.GetSimpleName();
            dst.FileHeader();
            dst.UsingNamespace(nameof(System));
            dst.AppendLine();
            dst.Namespace(margin, identifier);
            dst.AppendLine();
            iter(symbols, s => {
                dst.Symbols(margin, s, false);
                dst.AppendLine();
            });
            var output = AppSettings.EnvDb().Scoped("clr").Path($"{identifier}.enums", FileKind.Cs);
            Channel.FileEmit(dst.Emit(), output);
        }


        [CmdOp("projects/extract/enums")]
        void ExtractEnums(CmdArgs args)
        {
            ExtractEnums(typeof(Microsoft.CodeAnalysis.AssemblyIdentity).Assembly);
            ExtractEnums(typeof(Microsoft.CodeAnalysis.CSharp.CSharpCompilation).Assembly);
            ExtractEnums(typeof(System.Reflection.Metadata.MetadataReader).Assembly);            
        }

        void ExtractStructs(Assembly src)
        {
            var types = src.Structs().NonGeneric();
            var dst = CsGen.emitter();
            var identifier = src.GetSimpleName();
            dst.Namespace(identifier);
            var margin = 0u;
            iter(types, t => {
                var fields = t.DeclaredPublicInstanceFields().Where(f => !f.IsCompilerGenerated());
                if(fields.Length != 0)
                {
                    dst.OpenStruct(margin, t.Name, false);
                    margin+=4;

                    iter(fields, f => {

                    var typename = CsData.keyword(f.FieldType);
                    if(empty(typename))
                        typename = f.FieldType.Name;                
                        dst.PublicField(margin, typename, f.Name);
                    });
                    margin-=4;
                    dst.CloseStruct(margin);
                }
            });

            var output = AppSettings.EnvDb().Scoped("clr").Path($"{identifier}.structs", FileKind.Cs);
            Channel.FileEmit(dst.Emit(), output);
        }

        [CmdOp("projects/config/print")]
        void PrintConfig(CmdArgs args)
        {
            var root = FS.dir(args[0]);
            var config = Z0.ProjectFiles.load(root);
            Channel.Row(config.Format());
        }

        [CmdOp("projects/create")]
        void CreateProject(CmdArgs args)
        {
            Z0.ProjectFiles.kind(args[0], out var kind);
            var root = FS.dir(args[1]);
            var project = Models.CreateProject(kind, root);
            
        }
        [CmdOp("projects/vars")]
        void TextExpr()
        {
            //VarValidate();
            var buffer = text.emitter();
            var prefix = AsciSymbols.Dollar;
            var fence = new AsciFence(AsciSymbols.LBrace, AsciSymbols.RBrace);
            buffer.Append("abcdefgh");
            buffer.Append(text.prefix(prefix, fence.Enclose("var1")));
            buffer.Append("ijklmnop");
            buffer.Append(text.prefix(prefix, fence.Enclose("var2")));
            buffer.Append("qrstuvwx");
            buffer.Append(text.prefix(prefix, fence.Enclose("var3")));
            var script = buffer.Emit();
            Channel.Row($"Input:{script}");
            Channel.Row($"Vars:");

            var vars = Vars.extract(script, prefix, fence);
            sys.iter(vars, v => Channel.Row($"{v}"));
        }

    }
}