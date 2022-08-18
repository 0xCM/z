//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using EN = SettingNames;

    public class ProjectSettings
    {
        public static ref readonly ProjectSettings Default
        {
            [MethodImpl(Inline)]
            get => ref _Default;
        }

        public static ProjectSettings load()
            => load(ConfigSets.app());

        public static ProjectSettings load(SettingLookup src)
            => new ProjectSettings(src);

        readonly SettingLookup Data;

        internal ProjectSettings(SettingLookup src)
        {
            Data = src;
        }

        static ProjectSettings _Default;

        static ProjectSettings()
        {
            _Default = load();
        }

        public FS.FolderPath EnvSource()
            => Settings.setting(Path(EN.EnvConfig), FS.dir);

        public FS.FilePath EnvPath(string name)
            => EnvSource() + FS.file(name, FileKind.Env);

        public Setting Path(string name)
        {
            var dst = Setting.Empty;
            var result = Data.Find(name, out dst);
            if(result)
                return dst;
            else
                return Setting.Empty;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();


    }
}