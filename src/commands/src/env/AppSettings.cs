//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Settings;

    public sealed class AppSettings : SettingStore<Name,string>
    {
        const string settings = nameof(settings);

        const string logs = nameof(logs);

        static AppSettings load()
            => new AppSettings(Settings.load(SettingsRoot().Path(FS.file("z0.settings", FileKind.Csv))));

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

        public static T lookup<T>(FilePath src)
            where T : ISettings, new()
                => AppSettings.lookup<T>(lookup(src, Chars.Eq));

        public static SettingLookup<T> lookup<T>(T src)
            where T : new()
                => new (typeof(T).PublicInstanceFields().Select(f => new Setting(f.Name, f.GetValue(src))));
 
        public static SettingLookup lookup(FilePath src, char sep)
        {
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            var quoted = new Fence<AsciCode>(AsciCode.SQuote, AsciCode.SQuote);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var value = Asci.format(SQ.right(content,i));
                        dst.Add(new Setting(name, value));
                    }
                }
            }
            return new SettingLookup(dst.ToArray());
        } 


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

        public IDbArchive PkgRoot()
            => new DbArchive(folder(Data.Setting(SettingNames.PkgRoot)));

        public FileUri Dashboard()
            =>  uri(Data.Setting(SettingNames.Dashboard));
        
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