//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

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
                FileEmit(data, AppDb.AppData("build/libs").Path(file.FileName.WithoutExtension.Format(), FileKind.Env), (ByteSize)data.Length);
            });
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
                FileEmit(data, AppDb.AppData("build/env").Path(file.FileName.WithoutExtension.Format(), FileKind.Env), (ByteSize)data.Length);
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
            FileEmit(data, AppDb.AppData().Path(src.FileName.WithoutExtension.Format(), FileKind.Env), (ByteSize)data.Length);
        }

        [CmdOp("build/slninfo")]
        void BuildSln(CmdArgs args)
        {
            var ws = AppDb.Dev("z0");
            var src =  ws.Path(FS.file(arg(args,0), FileKind.Sln));
            var sln = Build.sln(src);
            var data = sln.ToString();
            Write(data);
            FileEmit(data, AppDb.AppData().Path(src.FileName.WithoutExtension.Format(), FileKind.Env), (ByteSize)data.Length);
        }
    }
}