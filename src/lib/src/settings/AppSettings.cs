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

        static AppSettings _Service = load(SettingsRoot().Path(FS.file("z0.settings", FileKind.Csv)));

        public static AppSettings load(WfEmit channel)
            => load(SettingsRoot().Path(FS.file("z0.settings", FileKind.Csv)), channel);

        public static DbArchive EnvRoot()
            => FS.dir(System.Environment.GetEnvironmentVariable(SettingNames.EnvRoot));

        public DbArchive Sdks()
            => folder(_Service.Setting(SettingNames.SdkRoot));

        public static DbArchive SettingsRoot()
            => EnvRoot().Scoped(settings);

        public DbArchive Control()
            => folder(_Service.Setting(SettingNames.Control));

        public DbArchive DbRoot()
            => folder(_Service.Setting(SettingNames.DbRoot));

        public DbArchive DevRoot()
            => folder(_Service.Setting(SettingNames.DevRoot));

        public DbArchive DevOps()
            => folder(_Service.Setting(SettingNames.DevOps));

        public DbArchive ProcDumps()
            => folder(_Service.Setting(SettingNames.ProcDumps));

        public DbArchive Capture()
            => folder(_Service.Setting(SettingNames.Capture));

        public DbArchive DevPacks()
            => folder(_Service.Setting(SettingNames.DevPacks));

        public DbArchive Archives()
            => folder(_Service.Setting(SettingNames.Archives));

        public DbArchive DevTools()
            => folder(_Service.Setting(SettingNames.DevTools));

        public DbArchive Logs() 
            => DbRoot().Scoped(logs);

        public DbArchive Control(string scope)
            => Control().Scoped(scope);

        public static ref readonly AppSettings Default
        {
            [MethodImpl(Inline)]
            get => ref _Service;
        }

        public AppSettings()
        {

        }

        public AppSettings(Setting[] settings)
            : base(settings.Select(x => new Setting<Name, string>(x.Name,x.ValueText)))
        {

        }

        public AppSettings(Setting<Name,string>[] settings)
            : base(settings)
        {

        }

        public static AppSettings load(FilePath src)
        {
            var data = src.ReadLines(true);
            var dst = sys.alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line, Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(text.trim(sys.skip(parts,0)), text.trim(sys.skip(parts,1)));
            }

            return new AppSettings(dst);
        }

        public static AppSettings load(FilePath src, WfEmit channel)
        {
            var flow = channel.Running($"Loading application settings from {src.ToUri()}");
            var dst = load(src);
            channel.Ran(flow,$"Read {dst.Length} settings from {src.ToUri()}");
            return dst;
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

        public override string Format()
        {
            var dst = text.emitter();            
            iter(Data, s => dst.AppendLine(s));
            return dst.Emit();
        }
    }
}