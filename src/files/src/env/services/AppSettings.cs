//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class AppSettings 
    {        
        public static ref readonly AppSettings Default
        {
            [MethodImpl(Inline)]
            get => ref Instance;
        }

        [MethodImpl(Inline), Op]
        static FolderPath folder(in Setting src)
            => FS.dir(src.ValueText);

        [MethodImpl(Inline), Op]
        static FileUri uri(in Setting src)
            => new (src.ValueText);

        readonly Dictionary<@string,string> Lookup;

        const string settings = nameof(settings);

        const string logs = nameof(logs);

        public static T lookup<T>(SettingLookup src)
            where T : new()
        {
            var dst = new T();
            var members = Settings.members<T>();
            for(var i=0; i<members.Count; i++)
            {
                ref readonly var member = ref members[i];
                if(src.Find(member.Name, out var setting))
                {
                    member.SetValue(dst, setting.Value);
                }
            }

            return dst;
        }
        
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

        public static DbArchive EnvRoot()
            => FS.dir(System.Environment.GetEnvironmentVariable(SettingNames.EnvRoot));

        public static DbArchive SettingsRoot()
            => EnvRoot().Scoped(settings);

        public DbArchive Control()
            => folder(Instance.Setting(SettingNames.Control));

        public DbArchive DbRoot()
            => folder(Instance.Setting(SettingNames.DbRoot));

        public DbArchive DevRoot()
            => folder(Instance.Setting(SettingNames.DevRoot));

        public DbArchive DevOps()
            => folder(Instance.Setting(SettingNames.DevOps));

        public DbArchive ProcDumps()
            => folder(Instance.Setting(SettingNames.ProcDumps));

        public DbArchive EnvDb()
            => folder(Instance.Setting(SettingNames.EnvDb));

        public DbArchive Capture()
            => folder(Instance.Setting(SettingNames.Capture));

        public IDbArchive PkgRoot()
            => new DbArchive(folder(Instance.Setting(SettingNames.PkgRoot)));

        public FileUri Dashboard()
            => uri(Instance.Setting(SettingNames.Dashboard));
        
        public DbArchive Archives()
            => folder(Instance.Setting(SettingNames.Archives));

        public DbArchive Logs() 
            => DbRoot().Scoped(logs);

        public DbArchive Control(string scope)
            => Control().Scoped(scope);

        public DbArchive XedDb()
            => folder(Instance.Setting(SettingNames.XedDb));

        public DbArchive SdeDb()
            => folder(Instance.Setting(SettingNames.SdeDb));

        public DbArchive Sdks()
            => folder(Instance.Setting(SettingNames.SdkRoot));

        public DbArchive Sdk(string name)
            => Sdks().Scoped(name);
        
        public DbArchive InxDb()
            => folder(Instance.Setting(SettingNames.InxDb));

        public DbArchive SdmDb()
            => folder(Instance.Setting(SettingNames.SdmDb));

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

        static AppSettings load()
            => new AppSettings(Settings.load(SettingsRoot().Path(FS.file("z0.settings", FileKind.Csv))));

        static AppSettings Instance = load();
    }
}