//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [ApiHost]
    public class SettingLookup : Seq<SettingLookup,Setting>, ILookup<Name,Setting>
    {
        public SettingLookup()
        {

        }

        [MethodImpl(Inline)]
        public SettingLookup(Setting[] src)
            : base(src)
        {

        }

        public bool Find(Name key, out Setting setting)
            => api.search(this, key, out setting);

        public override string Format()
        {
            var dst = text.emitter();
            api.render(this,dst);
            return dst.Emit();
        }
    }
}