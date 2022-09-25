//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class BuildCmd : AppCmdService<BuildCmd>
    {
        MsBuild BuildSvc => Wf.BuildSvc();

        Dev Dev => Wf.Dev();

        //ConcurrentDictionary<

        [CmdOp("projects/list")]
        void ListProjects(CmdArgs args)
        {
            var scope = arg(args,0).Value;
            var files = AppDb.Dev(scope).Files().Where(x => FileTypes.@is(x,FileKind.CsProj));
            iter(files, file => Write(file.ToUri()));

            var uri = Cmd.uri((MethodInfo)MethodInfo.GetCurrentMethod());
            

            //iter(files, file => Write(file.ToUri()));
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
            var sources = AppDb.Dev("z0").Sources("props");
            var files = Z0.Files.Empty;
            if(args.Count == 0)
                files = sources.Files(FileKind.Props, true);
            else
                files = array(sources.Path(FS.file(arg(args,0), FileKind.Props)));

            iter(files, file =>{
                var project = BuildSvc.LoadProject(file);
                var data = project.Format();    
                Write(data);
                FileEmit(data, AppDb.AppData("build/env").Path(file.FileName.WithoutExtension.Format(), FileKind.Cfg), (ByteSize)data.Length);
            });
        }

        [CmdOp("dev/exports")]
        void BuildExports()
        {
            var exports = Dev.Exports(AppDb.DevProject("z0"));
            Dev.EmitCfg(exports, "exports", AppDb.AppData("dev/exports"));

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