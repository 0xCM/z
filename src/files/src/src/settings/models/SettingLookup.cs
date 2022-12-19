//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class SettingLookup : Seq<SettingLookup,Setting>, ILookup<@string,Setting>
    {
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