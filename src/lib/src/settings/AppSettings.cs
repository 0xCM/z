//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Settings;

    public sealed class AppSettings : SettingLookup<Name,string>
    {
        const string settings = nameof(settings);

        const string logs = nameof(logs);

        static AppSettings load()
            => new AppSettings(Settings.load(SettingsRoot().Path(FS.file("z0.settings", FileKind.Csv))));

        public static AppSettings absorb(FilePath src)
        {
            Data = new AppSettings(Settings.load(src));
            return Data;
        }

        public AppSettings Absorb(FilePath src)
        {
            var settings = Settings.load(src);
            foreach(var setting in settings)
                Data.Set(setting.Name, $"{setting.Value}");
            return Data;
        }

        static AppSettings Data = load();

        public static DbArchive EnvRoot()
            => FS.dir(System.Environment.GetEnvironmentVariable(SettingNames.EnvRoot));

        public DbArchive Sdks()
            => folder(Data.Setting(SettingNames.SdkRoot));

        public static DbArchive SettingsRoot()
            => EnvRoot().Scoped(settings);

        public DbArchive Control()
            => folder(Data.Setting(SettingNames.Control));

        public DbArchive DbRoot()
            => folder(Data.Setting(SettingNames.DbRoot));

        public DbArchive DevRoot()
            => folder(Data.Setting(SettingNames.DevRoot));

        public DbArchive DevOps()
            => folder(Data.Setting(SettingNames.DevOps));

        public DbArchive ProcDumps()
            => folder(Data.Setting(SettingNames.ProcDumps));

        public DbArchive Capture()
            => folder(Data.Setting(SettingNames.Capture));

        public DbArchive PkgRoot()
            => folder(Data.Setting(SettingNames.PkgRoot));

        public DbArchive Archives()
            => folder(Data.Setting(SettingNames.Archives));

        public DbArchive Logs() 
            => DbRoot().Scoped(logs);

        public DbArchive Control(string scope)
            => Control().Scoped(scope);

        public static ref readonly AppSettings Default
        {
            [MethodImpl(Inline)]
            get => ref Data;
        }

        public AppSettings()
        {

        }

        public AppSettings(Setting[] settings)
            : base(settings.Select(x => new Setting<Name, string>(x.Name,x.ValueText)))
        {

        }

        public string Find(string name)
            => Find(name, EmptyString);

        public Setting Setting(string name)
        {
            var dst = Z0.Setting.Empty;
            if(Find(name, out var x))
                dst = new Setting(name,x);
            return dst;
        }

        public string Format()
        {
            var dst = text.emitter();            
            iter(Keys, key => dst.AppendLine(Setting(key)));
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}