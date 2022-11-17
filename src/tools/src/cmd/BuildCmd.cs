//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class BuildCmd : WfAppCmd<BuildCmd>
    {
        MsBuild BuildSvc => Wf.BuildSvc();

        ProjectTools Dev => Wf.Dev();

        [CmdOp("projects/list")]
        void ListProjects(CmdArgs args)
        {
            var uri = ApiCmd.uri((MethodInfo)MethodInfo.GetCurrentMethod()); 
            var flow = Channel.Running(uri);
            var files = Archives.archive(Env.cd()).Files().Where(x => FileTypes.@is(x,FileKind.CsProj));
            iter(files, file => Channel.Row(file.ToUri()));
            Channel.Ran(flow, uri);            
        }

        [CmdOp("build/libs")]
        void LoadProjects()
        {
            var sources = AppDb.Dev("z0/libs");
            var files = sources.Files(FileKind.CsProj);
            iter(files, file =>{
                var project = BuildSvc.LoadProject(file);
                var data = project.Format();    
                Write(data);
                FileEmit(data, AppDb.AppData("build/libs").Path(file.FileName.WithoutExtension.Format(), FileKind.Cfg), (ByteSize)data.Length);
            });
        }

        ReadOnlySeq<Build.Property> Exports()
        {
            var path = AppDb.Dev("projects/z0").Path("exports",FileKind.Props);
            var project = BuildSvc.LoadProject(path);
            ref readonly var props = ref project.Props;
            var dst = list<Build.Property>();
            var adding = false;
            for(var i=0; i<props.Count; i++)
            {
                ref readonly var prop = ref props[i];
                if(adding)
                {
                    dst.Add(prop);
                    if(prop.Name == "Validity")
                        break;                    
                }
                else if(prop.Name=="Agents")
                {
                    adding = true;
                    dst.Add(prop);
                }
            }
            return dst.ToArray();
        }
        
        [CmdOp("z0/exports")]
        void DirProps()
        {
            var src = Exports();
            var dst = text.emitter();
            iter(src, prop => dst.AppendLine($"dotnet sln add {prop.Value}"));
            FileEmit(dst.Emit(), AppDb.AppData().Path("sln",FileKind.Cmd));
        }

        [CmdOp("build/props")]
        void BuildProps(CmdArgs args)
        {
            var sources = Archives.archive(Env.cd());
            var files = sources.Files(FileKind.Props,true);
            iter(files, file =>{
                var project = BuildSvc.LoadProject(file);
                var data = project.Format();    
                Write(data);
                FileEmit(data, AppDb.Env().Path(file.FileName.WithoutExtension.Format(), FileKind.Cfg), (ByteSize)data.Length);
            });
        }

        [CmdOp("build/exports")]
        void BuildExports()
        {
            var sources = Archives.archive(Env.cd());
            var files = sources.Files(FileKind.Props,true).Where(f => f.FileName.WithoutExtension.Name == "exports");
            iter(files, file =>{
                var project = BuildSvc.LoadProject(file);
                var data = project.Format();    
                Write(data);
                FileEmit(data, AppDb.Env().Path(file.FileName.WithoutExtension.Format(), FileKind.Cfg), (ByteSize)data.Length);
            });
        }

        [CmdOp("dev/deps")]
        void DevImports()
        {
            //var props = Dev.DirectoryProps(AppDb.DevProject("z0"));
            //Write(props.Format());
            var deps = Dev.Deps("z0");
            foreach(var dep in deps)
            {
                FileEmit(dep.Format(), AppDb.AppData("dev/deps").Path(dep.Origin.ToFilePath().FileName.WithoutExtension.Format(), FileKind.Cfg));
            }
        }

        [CmdOp("build/libinfo")]
        void BuildProject(CmdArgs args)
        {
            var ws = AppDb.Dev("z0");
            var id = arg(args,0).Value;
            var name = $"z0.{id}";
            var src =  ws.Sources($"libs/{id}").Path(FS.file(name, FileKind.CsProj));
            var project = BuildSvc.LoadProject(src);
            var data = project.Format();
            Write(data);
            FileEmit(data, AppDb.AppData().Path(src.FileName.WithoutExtension.Format(), FileKind.Cfg), (ByteSize)data.Length);
        }

        [CmdOp("build/slninfo")]
        void BuildSln(CmdArgs args)
        {
            var ws = AppDb.Dev("z0");
            var src =  ws.Path(FS.file(arg(args,0), FileKind.Sln));
            var sln = Build.sln(src);
            var data = sln.ToString();
            Write(data);
            FileEmit(data, AppDb.AppData().Path(src.FileName.WithoutExtension.Format(), FileKind.Cfg), (ByteSize)data.Length);
        }
    }
}