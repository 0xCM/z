//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [ApiHost]
    public class SettingLookup : Seq<SettingLookup,Setting>, ILookup<@string,Setting>
    {
        public static SettingLookup load(FilePath src)
        {
            var formatter = Tables.formatter<Setting>();
            var data = src.ReadLines(true);
            var dst = sys.alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line, Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(text.trim(skip(parts,0)), text.trim(skip(parts,1)));
            }
            return new SettingLookup(dst);
        }

        [Op]
        public static SettingLookup parse(ReadOnlySpan<string> src, char sep)
        {
            var count = src.Length;
            var dst = sys.alloc<Setting>(count);
            for(var i=0; i<count; i++)
                sys.seek(dst, i) = Setting.parse(sys.skip(src,i), sep);
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

        public SettingLookup()
        {

        }

        [MethodImpl(Inline)]
        public SettingLookup(Setting[] src)
            : base(src)
        {

        }

        public static void render(SettingLookup src, ITextEmitter dst)
        {
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i]);
        }

        public bool Find(@string key, out Setting setting)
            => search(this, key, out setting);

        public override string Format()
        {
            var dst = text.emitter();
            render(this, dst);
            return dst.Emit();
        }
    }
}