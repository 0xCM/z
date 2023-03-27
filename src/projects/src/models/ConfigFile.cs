//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public record class ConfigFile : ProjectFile<ConfigFile>
        {
            public static FilePath path(FolderPath root) => root + FS.file("config", FileKind.Cmd);

            public FilePath Path {get;}
         
            public Seq<CmdExpr> Body {get;}

            public ConfigFile()
            {
                Path = FilePath.Empty;
                Body = sys.empty<CmdExpr>();
            }

            public ConfigFile(FilePath path, params CmdExpr[] settings)
            {
                Path = path;
                Body = settings;
            }     
            
            // public ProjectKind Kind()
            // {
            //     var kind = ProjectKind.None;
            //     var settings = Body.Where(x => x is ISetting s && s.Name == ProjectServices.SettingNames.ProjectKind);
            //     if(settings.IsNonEmpty)
            //         ProjectServices.kind((settings.First as ISetting).Name, out kind);
            //     return kind;
            // }

            public string Format()
            {
                var dst = text.emitter();
                sys.iter(Body, setting => dst.AppendLine(setting.Format()));
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static ConfigFile Empty => new ConfigFile(FilePath.Empty, sys.empty<CmdSetting>());
        }
    }
}