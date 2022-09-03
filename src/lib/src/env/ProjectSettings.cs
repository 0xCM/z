//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectSettings
    {
        public static ref readonly ProjectSettings Default
        {
            [MethodImpl(Inline)]
            get => ref _Default;
        }

        static FilePath path()
            => FS.path(ExecutingPart.Assembly.Location).FolderPath + FS.file("app.settings", FileKind.Csv);

        public static ProjectSettings load()
            => load(Settings.rows(path()));

        public static ProjectSettings load(SettingLookup src)
            => new ProjectSettings(src);

        readonly SettingLookup Data;

        ProjectSettings(SettingLookup src)
        {
            Data = src;
        }

        static ProjectSettings _Default;

        static ProjectSettings()
        {
            _Default = load();
        }

        public Setting Setting(string name)
        {
            var dst = Z0.Setting.Empty;
            var result = Data.Find(name, out dst);
            if(result)
                return dst;
            else
                return Z0.Setting.Empty;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();
    }
}