//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    
    public sealed class AppSettings : SettingLookup<Name,string>
    {
        static AppSettings _Service = AppSettings.load();

        public static ref readonly AppSettings Service()
            => ref _Service;

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

        public override string Format()
        {
            var dst = text.emitter();            
            iter(Data, s => dst.AppendLine(s));
            return dst.Emit();
        }

        public static AppSettings load(FS.FilePath src)
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

        public string Find(Name name)
            => Find(name, EmptyString);

        public static AppSettings load()
            => load(path());

        public static FS.FilePath path()
            => FS.path(sys.controller().Location).FolderPath + FS.file("app.settings", FileKind.Csv);
    }
}