//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public partial class Settings
    {
        const NumericKind Closure = UnsignedInts;

        public static uint parse<T>(ReadOnlySpan<string> src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var counter = 0u;
            var settings = SettingLookup.parse(src, sep);
            var fields = typeof(T).PublicInstanceFields().Select(x => (x.Name,x)).ToDictionary();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                if(setting.IsEmpty)
                    continue;

                if(fields.TryGetValue(setting.Name, out var field))
                {
                    if(ValueDynamic.parse(setting.ValueText, field.FieldType, out var x))
                    {
                        field.SetValue(dst, x);
                        counter++;
                    }
                }
            }
            return counter;
        }

        public static T lookup<T>(FilePath src)
            where T : ISettings, new()
                => AppSettings.lookup<T>(Settings.lookup(src, Chars.Eq));

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
        
    }
}