//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [ApiHost]
    public class SettingLookup : Seq<SettingLookup,Setting>, ILookup<@string,Setting>
    {
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
            => api.search(this, key, out setting);

        public override string Format()
        {
            var dst = text.emitter();
            render(this, dst);
            return dst.Emit();
        }
    }
}