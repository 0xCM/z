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

        [CmdOp("build/projects")]
        void ProjectCfg()
        {
            var path = AppDb.Dev("z0").Sources("props").Path("projects",FileKind.Props);
            var project = BuildSvc.LoadProject(path);
            ref readonly var props = ref project.Props;
            var dst = list<Build.Property>();
            var j = -1;
            for(var i=0; i<props.Count; i++)
            {
                ref readonly var prop = ref props[i];
                var desc = prop.Format();
                if(prop.Name == "Literals")
                {
                    j=i;
                    break;
                }
            }

            if(j > 0)
            {
                for(var i=j; i<props.Count; i++)
                {
                    if(props[i].Name != "MSBuildAllProjects")
                        dst.Add(props[i]);
                }
            }

            iter(dst, prop => Emitter.Write(prop.Format()));
            var data = dst.Map(x => x.Format()).Concat("\n");
            var cfg = AppDb.DbTargets("cfg").Path("projects", FileKind.Cfg);
            FileEmit(data, cfg);
            var config = Settings.cfg(cfg);
            iter(config, entry => Emitter.Row($"dotnet sln add {FS.path(new string(entry.Value))}"));

            //Emitter.FileEmit()
        }

        [CmdOp("build/props")]
        void BuildProps(CmdArgs args)
        {
            var sources = AppDb.Dev("z0").Sources("props");
            var files = FS.Files.Empty;
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