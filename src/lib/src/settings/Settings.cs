//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class Settings
    {
        const NumericKind Closure = UnsignedInts;
        [Op]
        public static bool search(SettingLookup src, string key, out Setting value)
        {
            value = Setting.Empty;
            var result = false;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var setting = ref src[i];
                if(string.Equals(setting.Name, key, NoCase))
                {
                    value = setting;
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static FilePath path()
            => FS.path(ExecutingPart.Assembly.Location).FolderPath + FS.file($"{ExecutingPart.Name.Format()}.settings", FileKind.Csv);

        public static Settings64 from(params Setting64[] src)
            => new Settings64(src);
    }
}