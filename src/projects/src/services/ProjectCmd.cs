//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class ProjectServices
    {
        internal class ProjectCmd : WfAppCmd<ProjectCmd>
        {
            ProjectModels Models => Channel.Channeled<ProjectModels>();
        
            [CmdOp("projects/modules")]
            void EcmaMeta(CmdArgs args)
            {
                var svc = Channel.Channeled<ModuleArchives>();
                var sources = FS.dir(args[0]).DbArchive();
                using var map = svc.Map(sources,true);
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
                var config = configuration(root);
                Channel.Row(config.Format());
            }

            [CmdOp("projects/create")]
            void CreateProject(CmdArgs args)
            {
                kind(args[0], out var k);
                var root = FS.dir(args[1]);
                var project = Models.CreateProject(k, root);
                
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
}