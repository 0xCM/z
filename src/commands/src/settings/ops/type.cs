//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
       public static SettingType<T> type<T>(T src)
            => type(src.GetType());

        public static SettingType type(Type src)
        {
            var dst = SettingType.None;
            if(src == typeof(bool))
                dst = SettingType.Bool;
            else if(src == typeof(string))
                dst = SettingType.String;
            else if(src == typeof(FilePath) || src == typeof(_FileUri))
                dst = SettingType.File;
            else if(src == typeof(FolderPath))
                dst = SettingType.Folder;
            return dst;
        }
    }
}