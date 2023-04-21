//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public static class XSettings
    {
        public static FolderPath Folder(this Setting src)
            => FS.dir(src.ValueText);

        public static IDbArchive DbArchive(this Setting src)
            => FS.archive(src.ValueText);

        public static FileUri File(this Setting src)
            => FS.path(src.ValueText);
    }

    public sealed class AppSettings 
    {        
        public static ref readonly AppSettings Default
        {
            [MethodImpl(Inline)]
            get => ref Instance;
        }

        readonly Dictionary<@string,string> Lookup;

        const string settings = nameof(settings);

        const string logs = nameof(logs);
        
        public AppSettings()
        {

        }

        public AppSettings(Setting[] settings)
        {
            Lookup = settings.Select(x => (x.Name,x.ValueText)).ToDictionary();
        }

        public AppSettings Absorb(FilePath src)
        {
            Absorb(Settings.load(src));
            return Instance;
        }

        public IDbArchive EnvRoot()
            => _EnvRoot();

        public IDbArchive SettingsRoot()
            => _SettingsRoot();

        public static LlvmSettings LlvmSettings()
            => new (Instance.Setting(SettingNames.LlvmRoot).Folder());

        public DbArchive Control()
            => Instance.Setting(SettingNames.Control).Folder();

        public DbArchive WinKits()
            => Instance.Setting(SettingNames.WinKits).Folder();

        public DbArchive DbRoot()
            => Instance.Setting(SettingNames.DbRoot).Folder();

        public DbArchive DevRoot()
            => Instance.Setting(SettingNames.DevRoot).Folder();

        public DbArchive DevOps()
            => Instance.Setting(SettingNames.DevOps).Folder();

        public DbArchive DevPacks()
            => Instance.Setting(SettingNames.DevPacks).Folder();

        public IDbArchive BuildKits()
            => Instance.Setting(SettingNames.BuildKits).DbArchive();

        public IDbArchive BuildKits(string scope)
            => BuildKits().Scoped(scope);

        public IDbArchive DevPacks(string scope)
            => DevPacks().Scoped(scope);
            
        public DbArchive ProcDumps()
            => Instance.Setting(SettingNames.ProcDumps).Folder();

        public IEnvDb EnvDb()
            => new EnvDb(Instance.Setting(SettingNames.EnvDb).Folder());

        public DbArchive Capture()
            => Instance.Setting(SettingNames.Capture).Folder();

        public IDbArchive PkgRoot()
            => new DbArchive(Instance.Setting(SettingNames.PkgRoot).Folder());

        public IDbArchive Publications()
            => new DbArchive(Instance.Setting(SettingNames.PubRoot).Folder());

        public IDbArchive Publications(string scope)
            => Publications().Scoped(scope);

        public FileUri Dashboard()
            => Instance.Setting(SettingNames.Dashboard).File();
        
        public DbArchive Archives()
            => Instance.Setting(SettingNames.Archives).Folder();

        public DbArchive Logs() 
            => DbRoot().Scoped(logs);

        public DbArchive Control(string scope)
            => Control().Scoped(scope);

        public DbArchive XedDb()
            => Instance.Setting(SettingNames.XedDb).Folder();

        public DbArchive SdeDb()
            => Instance.Setting(SettingNames.SdeDb).Folder();

        public DbArchive Sdks()
            => Instance.Setting(SettingNames.SdkRoot).Folder();

        public DbArchive Sdk(string name)
            => Sdks().Scoped(name);
        
        public DbArchive InxDb()
            => Instance.Setting(SettingNames.InxDb).Folder();

        public DbArchive SdmDb()
            => Instance.Setting(SettingNames.SdmDb).Folder();

        public string Find(@string name, string @default)
        {
            var dst = @default;
            if(Lookup.TryGetValue(name, out var setting))
                return dst = setting;
            return dst;
        }

        public bool Find(@string name, out string dst)
            => Lookup.TryGetValue(name, out dst);

        public void Set(@string name, string value)
            => Lookup[name] = value;

        void Absorb(Setting[] src)
            => iter(src, setting => Lookup.TryAdd(setting.Name, setting.ValueText));

        public string Find(string name)
            => Find(name, EmptyString);

        public Setting Setting(string name)
        {
            var dst = Z0.Setting.Empty;
            if(Find(name, out var x))
                dst = new Setting(name, x);
            return dst;
        }

        public string Format()
        {
            var dst = text.emitter();            
            iter(Lookup.Keys, key => dst.AppendLine(Setting(key).ValueText));
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        static DbArchive _EnvRoot()
            => FS.dir(System.Environment.GetEnvironmentVariable(SettingNames.EnvRoot));

        static DbArchive _SettingsRoot()
            => _EnvRoot().Scoped(settings);

        static AppSettings load()
            => new AppSettings(Settings.load(_SettingsRoot().Path(FS.file("z0.settings", FileKind.Csv))));

        static AppSettings Instance = load();
    }
}