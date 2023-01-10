//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Settings
    {
        [Op]
        public static SettingLookup parse(ReadOnlySpan<TextLine> src, char sep)
        {
            var count = src.Length;
            var buffer = span<Setting>(count);
            ref var dst = ref first(buffer);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var content = line.Content;
                var j = text.index(content, sep);
                if(j > 0)
                {
                    var name = text.left(content, j).Trim();
                    var value = text.right(content, j).Trim();
                    seek(dst, counter++) = new Setting(name, value);
                }
            }
            return new(slice(buffer,0,counter).ToArray());
        }

        [MethodImpl(Inline), Op]
        public static FolderPath folder(in Setting src)
            => FS.dir(src.ValueText);

        [MethodImpl(Inline), Op]
        public static FileUri uri(in Setting src)
            => new (src.ValueText);

        public static void store(IWfChannel channel, ReadOnlySpan<Setting> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            iter(src, x=> emitter.AppendLine(x.Format()));
            channel.FileEmit(emitter.Emit(),dst, encoding);            
        }

        public static void store<T>(IWfChannel channel, ReadOnlySpan<Setting<T>> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            iter(src, x=> emitter.AppendLine(x.Format()));
            channel.FileEmit(emitter.Emit(),dst, encoding);            
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
            var line = TextLine.Empty;
            var quoted = new Fence<char>(Chars.SQuote, Chars.SQuote);
            using var reader = src.Utf8LineReader();
            while(reader.Next(out line))
            {
                var length = line.Length;
                var content = line.Content;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                        dst.Add(new Setting(text.left(content,i), text.right(content,i)));
                }
            }
            return new SettingLookup(dst.ToArray());
        } 
        
        [Parser]
        public static Outcome parse(string src, char sep, out Setting<string> dst)
        {
            if(sys.empty(src))
            {
                dst = default;
                return (false, "!!Empty!!");
            }
            else
            {
                var i = src.IndexOf(sep);
                if(i == NotFound)
                {
                    dst = default;
                    return (false, "Setting delimiter not found");
                }
                else
                {
                    if(i == 0)
                        dst = new Setting<string>(EmptyString, text.slice(src,i+1));
                    else
                        dst = new Setting<string>(text.slice(src,0, i), text.slice(src,i+1));
                    return true;
                }
            }
        }

        public static Setting setting(string src, char sep)
        {
            var i = text.index(src, sep);
            var setting = Setting.Empty;
            if(i > 0)
                setting = new Setting(text.trim(text.left(src, i)), text.trim(text.right(src, i)));
            return setting;
        }

        public static CfgBlock cfg(FilePath src)
        {
            var dst = list<CfgEntry>();
            using var reader = src.Utf8LineReader();
            var line = TextLine.Empty;
            while(reader.Next(out line))
            {
                var i = line.Index('=');
                if(i > 0)
                {
                    var name = text.left(line.Content, i);
                    var value = text.right(line.Content,i);
                    dst.Add(new (name,value));
                }
            }
            return new (src.FileName.WithoutExtension.Format(),dst.ToArray());
        }

        public static string format(SettingMembers src, char sep)
        {
            var dst = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var member = ref src[i];
                dst.AppendLine($"{member.Name}{sep}{member.FieldType.DisplayName()}");
            }

            return dst.Emit();
        }

        [Op]
        public static SettingLookup parse(ReadOnlySpan<string> src, char sep)
        {
            var count = src.Length;
            var dst = sys.alloc<Setting>(count);
            for(var i=0; i<count; i++)
                sys.seek(dst, i) = setting(sys.skip(src,i), sep);
            return new (dst);
        }

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