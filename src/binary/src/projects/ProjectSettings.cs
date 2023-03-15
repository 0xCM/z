//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static ProjectModels;

    public class ProjectSettings
    {
        class SettingNames 
        {
            public const string SlnRoot = nameof(SlnRoot);

            public const string SlnName = nameof(SlnName);

            public const string SlnSite = nameof(SlnSite);

            public const string SlnBuild = nameof(SlnBuild);

            public const string SlnVendor = nameof(SlnVendor);

            public const string SlnPub = nameof(SlnPub);

            public const string SlnCmd = nameof(SlnCmd);
            
            public const string ProjectKind = nameof(ProjectKind);
        }

        public class ConfigFile
        {
            public Seq<Setting> Settings {get;}

            public ConfigFile(Seq<Setting> settings)
            {
                Settings = settings;
            }     
            
            // public IEnumerable<Setting> Vars()
            // {
            //     foreach(var setting in Settings)
            //     {
                    
            //     }
            // }

            public string Format()
            {
                var dst = text.emitter();
                sys.iter(Settings, setting => dst.AppendLine(setting.Format()));
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static ConfigFile Empty => new ConfigFile(sys.empty<Setting>());
        }

        public static ConfigFile configure(ProjectKind kind, FolderPath root)
        {
            var path = root + FS.file("config", FileKind.Cmd);
            var settings = list<Setting>();
            settings.Add(new (SettingNames.ProjectKind, kind));
            settings.Add(new (SettingNames.SlnName, root.FolderName.Format()));
            settings.Add(new (SettingNames.SlnRoot, $"%~dp0..\\%{SettingNames.SlnName}%"));
            settings.Add(new (SettingNames.SlnCmd, $"%{SettingNames.SlnRoot}%\\cmd"));
            return new ConfigFile(settings.Array());
        }

        public static ExecToken save(IWfChannel channel, ConfigFile src, FilePath dst)
        {
            var buffer = text.emitter();
            iter(src.Settings, setting => buffer.AppendLine(setting.Format()));
            return channel.FileEmit(buffer.Emit(), dst);
        }

        public static ConfigFile load(FolderPath root)
            => new ConfigFile(Settings.config(root + FS.file("config", FileKind.Cmd)));
    }
}