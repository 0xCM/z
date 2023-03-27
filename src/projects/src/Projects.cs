//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdExpr;
    using static ProjectModels;

    using Names = Projects.SettingNames;

    public partial class Projects
    {
        public static ExecToken save(IWfChannel channel, WorkspaceFile src)   
        {
            var buffer = text.emitter();
            var emitter = Json.emitter(buffer);
            emitter.Serialize(new {
                folders = src.Folders.Storage
            });
            return channel.FileEmit(buffer.Emit(), src.Path);
        }

        public static ExecToken save(IWfChannel channel, LaunchScript src)   
            => channel.FileEmit(src.Script.Body, src.Path);

        public static ExecToken save(IWfChannel channel, ConfigFile src)
        {
            var buffer = text.emitter();
            iter(src.Body, setting => buffer.AppendLine(setting.Format()));
            return channel.FileEmit(buffer.Emit(), src.Path);
        }        

        public static void kind(string src, out ProjectKind dst)
        {
            dst = ProjectKind.None;
            switch(src.ToLower())
            {
                case "binary":
                    dst = ProjectKind.Binary;
                break;
            }
        }        

        public static ConfigFile configuration(FolderPath root)
            => new ConfigFile(root + FS.file("config", FileKind.Cmd), Z0.Settings.cmd(root + FS.file("config", FileKind.Cmd)));   

        public static ConfigFile configure(ProjectKind kind, FolderPath root)
        {
            var path = root + FS.file("config", FileKind.Cmd);
            var settings = list<CmdSetting>();
            settings.Add(new (SettingNames.ProjectKind, kind.ToString()));
            settings.Add(new (SettingNames.SlnName, root.FolderName.Format()));
            settings.Add(new (SettingNames.SlnRoot, $"%~dp0..\\%{SettingNames.SlnName}%"));
            settings.Add(new (SettingNames.SlnCmd, $"%{SettingNames.SlnRoot}%\\cmd"));
            return new ConfigFile(path,settings.Array());
        }

        public static LaunchScript launcher(FolderPath root)
        {
            var dst = text.emitter();
            dst.AppendLine(call(cwd(script("config"))));
            dst.AppendLine(set(EnvTokens.PATH, (@string)$"{var(Names.SlnPaths)};{var(EnvTokens.PATH)}"));
            dst.AppendLine(set(Names.WsRoot, cwd()));
            dst.AppendLine(set(Names.WsPath, cwd()));
            dst.AppendLine(var(Names.VsCode));
            return new LaunchScript(root + FS.file("develop", FileKind.Cmd), new CmdScript("develop", dst.Emit()));
        }

        public static FilePath flowpath(IProject src)
            => src.Build().Path(FS.file($"{src.Name}.build.flows",FileKind.Csv));

        public static ProjectContext context(IProject src)
            => new ProjectContext(src, flows(src));

        static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }

        static CmdFlows flows(IProject src)
        {
            var path = Projects.flowpath(src);
            if(path.Exists)
            {
                var lines = path.ReadLines(TextEncodingKind.Asci,true);
                var buffer = sys.alloc<CmdFlow>(lines.Length - 1);
                var reader = lines.Storage.Reader();
                reader.Next(out _);
                var i = 0u;
                while(reader.Next(out var line))
                {
                    var parts = text.trim(text.split(line, Chars.Pipe));
                    Require.equal(parts.Length, CmdFlow.FieldCount);
                    var cells = parts.Reader();
                    ref var dst = ref seek(buffer,i++);
                    parse(cells.Next(), out dst.Tool).Require();
                    DataParser.parse(cells.Next(), out dst.SourceName).Require();
                    DataParser.parse(cells.Next(), out dst.TargetName).Require();
                    DataParser.parse(cells.Next(), out dst.SourcePath).Require();
                    DataParser.parse(cells.Next(), out dst.TargetPath).Require();
                }
                return new(FileCatalog.load(src.Files().Array().ToSortedSpan()), buffer);
            }
            else
                return CmdFlows.Empty;
        }

        static IProject Project;

        public static ref readonly IProject project()
        {
            if(Project == null)
                sys.@throw("Project is null");
            return ref Project;
        }

        [MethodImpl(Inline)]
        public static ref readonly IProject project(IProject src)
        {
            Project = src;
            return ref Project;
        }
    }
}