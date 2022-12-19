//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class SettingsApi
    {
        public static Seq<Setting> load(FilePath src)
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

            return dst;
        }

        public static @string name(Type src)
            => src.Tag<SettingsAttribute>().MapValueOrElse(tag => tag.Name, () => (@string)src.DisplayName());

        public static @string name<T>()
            => name(typeof(T));

        [Op]
        public static uint store(SettingLookup src, char sep, StreamWriter dst)
        {
            var settings = src.View;
            var count = (uint)settings.Length;
            if(count == 0)
                return count;

            for(var i = 0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                dst.WriteLine(string.Format("{0}{1}{2}", setting.Name, sep, setting.Value));
            }
            return count;
        }
        
        [MethodImpl(Inline), Op]
        public static SettingMembers members(Type src)
            => new (src.PublicInstanceFields().Where(f => !f.IsInitOnly));

        public static SettingMembers<T> members<T>()
            where T : new()
                => new SettingMembers<T>(members(typeof(T)));        
        public static SettingType<T> type<T>(T src)
            => type(src.GetType());

        public static SettingLookup<T> lookup<T>(T src)
            where T : new()
                => new (typeof(T).PublicInstanceFields().Select(f => new Setting(f.Name, f.GetValue(src))));

        public static string format(ISettings src)
        {
            var dst = text.emitter();
            dst.AppendLine($"[{src.Name}]");
            render(src.Lookup,dst);
            return dst.Emit();
        }

        public static void render(SettingLookup src, ITextEmitter dst)
        {
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i]);
        }

        public static string format(Index<Setting> src, char sep)
        {
            var dst = text.emitter();
            iter(src, x => dst.AppendLine(x.Format(sep)));
            return dst.Emit();
        }

         public static string format<T>(in T src, char sep)
            where T : ISettings
        {
            var fields = typeof(T).PublicInstanceFields();
            var count = fields.Length;
            var dst = text.emitter();
            dst.AppendLine($"[{src.Name}]");
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendLineFormat("{0}{1}{2}",field.Name, sep, field.GetValue(src));
            }
            return dst.Emit();
        }

        [Op]
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

        public static string json(Setting src)
            => string.Concat(RP.enquote(src.Name), Chars.Colon, Chars.Space, src.ValueText.Enquote());
    }
}